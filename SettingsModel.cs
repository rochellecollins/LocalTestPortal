using System.Collections.Generic;

namespace LocalTestPortal
{
    public class SettingsModel
    {

        public SettingsModel(string settingsName)
        {
            xmlHelper = new XMLHelper(settingsName);

            Name = settingsName;
            TestProjectPath = xmlHelper.ReadSetting(SettingGroup.General, Setting.TestProjectPath);
            TestDllFileNames = xmlHelper.ReadSetting(SettingGroup.General, Setting.TestDllFileNames).ToSplitList();
            PlaySound = xmlHelper.ReadSetting(SettingGroup.General, Setting.PlaySound);

            SQLServer = xmlHelper.ReadSetting(SettingGroup.Database, Setting.SQLServer);
            DBName = xmlHelper.ReadSetting(SettingGroup.Database, Setting.DBName);
            BackupFile = xmlHelper.ReadSetting(SettingGroup.Database, Setting.BackupFile);

            BrowserPath = xmlHelper.ReadSetting(SettingGroup.Browser, Setting.BrowserPath);
            Headless = xmlHelper.ReadSetting(SettingGroup.Browser, Setting.Headless) == "True";
            URL = xmlHelper.ReadSetting(SettingGroup.Browser, Setting.URL);
            AcuUser = xmlHelper.ReadSetting(SettingGroup.Browser, Setting.AcuUser);
            Password = xmlHelper.ReadSetting(SettingGroup.Browser, Setting.AcuPassword);

            OutputPath = xmlHelper.ReadSetting(SettingGroup.Logging, Setting.OutputPath);
            ScreenShotPath = xmlHelper.ReadSetting(SettingGroup.Logging, Setting.ScreenshotPath);
            DeleteLogs = xmlHelper.ReadSetting(SettingGroup.Logging, Setting.DeleteLogs) == "True";

            Tests = xmlHelper.ReadSelectedTests();
        }

        internal XMLHelper xmlHelper { get;  set; }
        public string Name { get; private set; }
        /// <summary>
        /// Root path where the TestProject.exe and Test dll files exist
        /// </summary>
        public string TestProjectPath { get; set; }
        public string TestProjectExe => "TestProject.exe";
        /// <summary>
        /// All dll test file names to use to load tests from
        /// </summary>
        public List<string> TestDllFileNames { get; set; }
        public string PlaySound { get;  set; }
        public string SQLServer { get;  set; }
        public string DBName { get;  set; }
        public string BackupFile { get;  set; }
        public string BrowserPath { get;  set; }
        public bool Headless { get;  set; }
        public string URL { get;  set; }
        public string AcuUser { get;  set; }
        public string Password { get;  set; }
        public string OutputPath { get;  set; }
        public string ScreenShotPath { get;  set; }
        public bool DeleteLogs { get;  set; }
        public List<string> Tests { get;  set; }

        internal void SaveSelectedTest(string testName, bool selected)
        {
            xmlHelper.SaveSelectedTest(testName, selected);
        }

        internal void Save()
        {
            xmlHelper.SaveSetting(SettingGroup.General, Setting.TestProjectPath, TestProjectPath);
            xmlHelper.SaveSetting(SettingGroup.General, Setting.TestDllFileNames, TestDllFileNames.ToJoinedString());
            xmlHelper.SaveSetting(SettingGroup.General, Setting.PlaySound, PlaySound);

            xmlHelper.SaveSetting(SettingGroup.Database, Setting.SQLServer, SQLServer);
            xmlHelper.SaveSetting(SettingGroup.Database, Setting.DBName, DBName);
            xmlHelper.SaveSetting(SettingGroup.Database, Setting.BackupFile, BackupFile);

            xmlHelper.SaveSetting(SettingGroup.Browser, Setting.BrowserPath, BrowserPath);
            xmlHelper.SaveSetting(SettingGroup.Browser, Setting.Headless, Headless.ToString());
            xmlHelper.SaveSetting(SettingGroup.Browser, Setting.URL, URL);
            xmlHelper.SaveSetting(SettingGroup.Browser, Setting.AcuUser, AcuUser);
            xmlHelper.SaveSetting(SettingGroup.Browser, Setting.AcuPassword, Password);

            xmlHelper.SaveSetting(SettingGroup.Logging, Setting.OutputPath, OutputPath);
            xmlHelper.SaveSetting(SettingGroup.Logging, Setting.ScreenshotPath, ScreenShotPath);
            xmlHelper.SaveSetting(SettingGroup.Logging, Setting.DeleteLogs, DeleteLogs.ToString());
        }

        internal void BuildRunnerExample(string testName)
        {
            xmlHelper.BuildRunnerExample(testName);
        }
    }
}