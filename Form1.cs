using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace LocalTestPortal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            loadSettingsButton.BackColor = SystemColors.Control;
            try
            {
                string dfltSetting = null;
                var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
                var existingSettings = directory.GetFiles().Where(x => x.Extension == ".xml"
                && x.Name != "RunnerExample.xml").OrderByDescending(x => x.LastWriteTime).ToList();
                for (var i = 0; i < existingSettings.Count(); i++)
                {
                    var setting = existingSettings[i];
                    var settingName = Path.GetFileNameWithoutExtension(setting.Name);
                    cSettings.Items.Add(settingName);
                    if (i == 0)
                    {
                        dfltSetting = settingName;
                        cSettings.SelectedIndex = cSettings.FindStringExact(settingName);
                    }
                }

                if (dfltSetting != null)
                {
                    LoadSetting(dfltSetting);
                }
            }
            catch (Exception ex)
            {
                loadSettingsButton.BackColor = Color.Yellow;
                ShowMessageBox($"{ex.Source} - Error loading settings", ex);
            }
        }

        private void ShowMessageBox(string title, Exception ex)
        {
            ShowMessageBox(title, ex, null);
        }

        private void ShowMessageBox(string title, Exception ex, string message)
        {
            var sb = new System.Text.StringBuilder();

            if(!string.IsNullOrWhiteSpace(message))
            {
                sb.AppendLine(message);
                sb.AppendLine();
            }

            sb.AppendLine(ex.GetType().Name);
            sb.AppendLine();
            sb.AppendLine(ex.Message);
            sb.AppendLine();
            sb.AppendLine(ex.StackTrace);

            MessageBox.Show(
                    sb.ToString(), 
                    title, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
        }

        private void LoadSetting(string dfltSetting)
        {
            var settings = new SettingsModel(dfltSetting);

            //General
            txtTestProjectPath.Text = settings.TestProjectPath;
            txtTestDllFileNames.Text = settings.TestDllFileNames.ToJoinedString();
            txtPlaySound.Text = settings.PlaySound;

            //Database
            txtSQLServer.Text = settings.SQLServer;
            txtDBName.Text = settings.DBName;
            txtBackupFile.Text = settings.BackupFile;

            //Browser
            txtBrowserPath.Text = settings.BrowserPath;
            chkHeadless.Checked = settings.Headless;
            txtURL.Text = settings.URL;
            txtAcuUser.Text = settings.AcuUser;
            txtAcuPassword.Text = settings.Password;

            //Logging
            txtOutputPath.Text = settings.OutputPath;
            txtScreenshotPath.Text = settings.ScreenShotPath;
            chkDeleteLogs.Checked = settings.DeleteLogs;

            LoadTests(settings);
        }

        private void LoadTests(SettingsModel settings)
        {
            string logPath;
            gridTests.Rows.Clear();

            if (!Directory.Exists(settings.TestProjectPath))
            {
                throw new DirectoryNotFoundException($"Test project path is invalid: {settings.TestProjectPath}");
            }

            var testProjectExe = Path.Combine(settings.TestProjectPath, settings.TestProjectExe);

            if (!File.Exists(testProjectExe))
            {
                throw new FileNotFoundException($"Test project executable not found: {testProjectExe}");
            }

            if(settings.TestDllFileNames == null || settings.TestDllFileNames.Count == 0)
            {
                throw new Exception("No test dll file names provided");
            }

            var testReader = new TestReader(settings.TestProjectPath);
            
            foreach (var testDllName in settings.TestDllFileNames)
            {
                testReader.LoadTestDll(testDllName);
            }

            var selectedTests = settings.Tests;

            foreach (var test in testReader.Tests)
            {
                var lastStatus = GetTestStatus(settings, test.Name, out logPath);

                var rowIndex = this.gridTests.Rows.Add();
                var row = this.gridTests.Rows[rowIndex];

                row.Cells[this.Selected.Name].Value = selectedTests.Contains(test.Name);
                row.Cells[this.TestName.Name].Value = test.Name;
                row.Cells[this.Result.Name].Value = string.IsNullOrWhiteSpace(lastStatus) ? "Not Run" : lastStatus;
                row.Cells[this.LogFile.Name].Value = logPath;
                row.Cells[this.TestDescription.Name].Value = test.Description;
                row.Cells[this.TestModule.Name].Value = test.Module;
                
            }

            gridTests.Sort(this.Selected, ListSortDirection.Descending);

            lblTestGridInfo.Text = $"Grid Results: {testReader.TestsSimple?.Count} tests loaded from: {testReader.DllFileNames?.ToJoinedString()}";
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            var settingsName = cSettings.Text;
            if (string.IsNullOrEmpty(settingsName))
                return;

            var settings = new SettingsModel(settingsName);

            //Tests
            foreach (DataGridViewRow row in gridTests.Rows)
            {
                settings.SaveSelectedTest((string)row.Cells[this.TestName.Name].Value, Convert.ToBoolean(row.Cells[this.Selected.Name].Value));
            }

            //General
            settings.TestProjectPath = txtTestProjectPath.Text;
            settings.TestDllFileNames = !string.IsNullOrWhiteSpace(txtTestDllFileNames.Text) ? txtTestDllFileNames.Text.Split(',').ToList() : null;
            settings.PlaySound = txtPlaySound.Text;

            //Database
            settings.SQLServer = txtSQLServer.Text;
            settings.DBName = txtDBName.Text;
            settings.BackupFile = txtBackupFile.Text;

            //Browser
            settings.BrowserPath = txtBrowserPath.Text;
            settings.Headless = chkHeadless.Checked;
            settings.URL = txtURL.Text;
            settings.AcuUser = txtAcuUser.Text;
            settings.Password = txtAcuPassword.Text;

            //Logging
            settings.OutputPath = txtOutputPath.Text;
            settings.ScreenShotPath = txtScreenshotPath.Text;
            settings.DeleteLogs = chkDeleteLogs.Checked;
            settings.Save();

            if (!cSettings.Items.Cast<string>().Any(x => x.Equals(settingsName)))
                cSettings.Items.Add(settingsName);
        }

        private void cSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSetting(cSettings.SelectedItem.ToString());
        }

        private void btnRunTests_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.WindowState = FormWindowState.Minimized;
            var settings = new SettingsModel(cSettings.Text);

            if(settings.DeleteLogs)
            {
                DeleteFiles(settings.OutputPath, ".txt");
                DeleteFiles(settings.ScreenShotPath, ".jpg");
            }

            var testRunnerExe = Path.Combine(settings.TestProjectPath, settings.TestProjectExe);

            foreach (DataGridViewRow row in gridTests.Rows)
            {
                if (!Convert.ToBoolean(row.Cells[this.Selected.Name].Value))
                {
                    row.Cells[this.Result.Name].Value = "Not Run";
                    row.Cells[this.LogFile.Name].Value = "";
                    continue;
                }
                    
                var testName = (string)row.Cells[this.TestName.Name].Value;
                this.Text = testName;
                row.Cells[this.Result.Name].Value = "In Progress";

                //build the XML file to pass to TestProject
                settings.BuildRunnerExample(testName);

                //backup the Database
                Process cmd = new Process();

                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.CreateNoWindow = true;

                cmd.Start();

                using (StreamWriter sw = cmd.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        sw.WriteLine($@"sqlcmd -E -S {settings.SQLServer} -Q ""ALTER DATABASE[{settings.DBName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE""");
                        sw.WriteLine($@"sqlcmd -E -S {settings.SQLServer} -Q ""RESTORE DATABASE[{settings.DBName}] from disk= '{settings.BackupFile}' WITH REPLACE""");
                        sw.WriteLine($@"sqlcmd -E -S {settings.SQLServer} -Q ""ALTER DATABASE[{settings.DBName}] SET MULTI_USER""");

                        //Call TestProject 
                        sw.WriteLine($@"{testRunnerExe} /config ""{Directory.GetCurrentDirectory()}\RunnerExample.xml""");
                    }
                }
                cmd.WaitForExit();
                string logFile;
                row.Cells[this.Result.Name].Value = GetTestStatus(settings, testName, out logFile);
                row.Cells[this.LogFile.Name].Value = logFile;
            }

            if (!string.IsNullOrEmpty(settings.PlaySound))
            {
                SoundPlayer sound = new SoundPlayer(settings.PlaySound);
                sound.Play();
            }
            this.WindowState = FormWindowState.Normal;
            this.Text = "Local Test Portal";

            // We need to move off the run button to avoid on finish the screen will pop up in front and could accidentally run again
            this.tabControl1.Focus();
        }

        private string GetTestStatus(SettingsModel settings, string testName, out string logFile)
        {
            string line;
            DirectoryInfo di = new DirectoryInfo(settings.OutputPath);
            FileInfo file = di.GetFiles(testName + "_*.txt").OrderByDescending(x => x.LastWriteTime).FirstOrDefault();
            if(file != null)
            {
                logFile = file.FullName;
                var sr = new StreamReader(file.FullName);
                while((line = sr.ReadLine()) != null)
                {
                    if (line.ToUpper().Contains(" ERROR:"))
                        return "Failed";
                }
                return "Success";
            }
            logFile = "";
            return "";
        }

        private void DeleteFiles(string folder, string extension)
        {
            DirectoryInfo di = new DirectoryInfo(folder);
            FileInfo[] files = di.GetFiles("*" + extension)
                                 .Where(p => p.Extension == extension).ToArray();
            foreach (FileInfo file in files)
                try
                {
                    file.Attributes = FileAttributes.Normal;
                    File.Delete(file.FullName);
                }
                catch
                {
                    continue;
                }
        }

        private void gridTests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                var filePath = gridTests.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (!string.IsNullOrEmpty(filePath))
                    Process.Start(filePath);
            }
        }

        private void loadSettingsButton_Click(object sender, EventArgs e)
        {
            lblTestGridInfo.Text = "Grid Results: Pending";
            LoadSettings();
        }
    }
}
