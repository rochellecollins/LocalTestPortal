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
            string dfltSetting = null;
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory());
            var existingSettings = directory.GetFiles().Where(x => x.Extension == ".xml"
            && x.Name != "RunnerExample.xml").OrderByDescending(x => x.LastWriteTime).ToList();
            for(var i = 0; i < existingSettings.Count(); i++)
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

            if(dfltSetting != null)
            {
                LoadSetting(dfltSetting);
            }
        }

        private void LoadSetting(string dfltSetting)
        {
            var settings = new SettingsModel(dfltSetting);

            //General
            txtTestProjectPath.Text = settings.TestProjectPath;
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

            var testProjectPath = settings.TestProjectPath;
            if (string.IsNullOrEmpty(testProjectPath))
                return;

            var selectedTests = settings.Tests;

            testProjectPath = Path.GetFullPath(Path.Combine(testProjectPath, @"..\..\..\..\TestsManufacturing\Tests"));
            var tests = Directory.GetFiles(testProjectPath, "*.cs", SearchOption.AllDirectories);
            foreach(var test in tests.OrderBy(x => x))
            {
                var testName = Path.GetFileNameWithoutExtension(test);
                var lastStatus = GetTestStatus(settings, testName, out logPath);
                if(lastStatus == "")
                    gridTests.Rows.Add(new object[] {selectedTests.Contains(testName), testName, "Not Run" });
                else
                    gridTests.Rows.Add(new object[] { selectedTests.Contains(testName), testName, lastStatus, logPath });
            }
            gridTests.Sort(gridTests.Columns[0], ListSortDirection.Descending);
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
                settings.SaveSelectedTest((string)row.Cells[1].Value, Convert.ToBoolean(row.Cells[0].Value));
            }

            //General
            settings.TestProjectPath = txtTestProjectPath.Text;
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

            foreach (DataGridViewRow row in gridTests.Rows)
            {
                if (!Convert.ToBoolean(row.Cells[0].Value))
                    continue;

                var testName = (string)row.Cells[1].Value;
                this.Text = testName;
                row.Cells[2].Value = "In Progress";

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
                        sw.WriteLine(@"sqlcmd -E -S {0} -Q ""ALTER DATABASE[{1}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE""", settings.SQLServer, settings.DBName);
                        sw.WriteLine(@"sqlcmd -E -S {0} -Q ""RESTORE DATABASE[{1}] from disk= '{2}' WITH REPLACE""", settings.SQLServer, settings.DBName, settings.BackupFile);
                        sw.WriteLine(@"sqlcmd -E -S {0} -Q ""ALTER DATABASE[{1}] SET MULTI_USER""", settings.SQLServer, settings.DBName);

                        //Call TestProject 
                        sw.WriteLine(@"{0}TestProject.exe /config ""{1}\RunnerExample.xml""", settings.TestProjectPath, Directory.GetCurrentDirectory());
                    }
                }
                cmd.WaitForExit();
                string logFile;
                row.Cells[2].Value = GetTestStatus(settings, testName, out logFile);
                row.Cells[3].Value = logFile;
            }

            if (!string.IsNullOrEmpty(settings.PlaySound))
            {
                SoundPlayer sound = new SoundPlayer(settings.PlaySound);
                sound.Play();
            }
            this.WindowState = FormWindowState.Normal;
            this.Text = "Local Test Portal";

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
                    if (line.ToUpper().Contains("PM Error:"))
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
    }
}
