using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LocalTestPortal
{
    class XMLHelper
    {
        private XDocument doc { get; set; }
        private string filePath { get; set; }

        public XMLHelper(string settingsName)
        {
            filePath = settingsName + ".xml";

            if (File.Exists(filePath))
                doc = XDocument.Load(filePath);
            else
            {
                doc = new XDocument();
                doc.Add(new XElement("LocalTestPortalSettings"));
            }
        }

        internal void SaveSetting(string groupName, string setting, string text)
        {             
            var root = doc.Root;

            if (!root.Descendants(groupName).Any())
                root.Add(new XElement(groupName));

            var element = root.Element(groupName).Element(setting);
            if (element == null)
                root.Element(groupName).Add(new XElement(setting, text));
            else
                root.Element(groupName).Element(setting).Value = text;

            doc.Save(filePath);            
        }

        internal string ReadSetting(string groupName, string setting)
        {
            var root = doc.Root;
            var element = root.Element(groupName)?.Element(setting);
            return element == null ? "" : element.Value;

        }

        internal void SaveSelectedTest(string name, bool selected)
        {
            var root = doc.Root;

            if (!root.Descendants(SettingGroup.Tests).Any())
                root.Add(new XElement(SettingGroup.Tests));

            var group = root.Element(SettingGroup.Tests).Elements(Setting.TestName);
            var existing = group.Where(x => (string)x.Attribute("Name") == name).FirstOrDefault();

            if (selected)
            {
                if (existing == null)
                {
                    var element = new XElement(Setting.TestName);
                    element.Add(new XAttribute("Name", name));
                    root.Element(SettingGroup.Tests).Add(element);
                }
            }
            else
            {
                if(existing != null)
                {
                    existing.Remove();
                }
            }
            doc.Save(filePath);
        }

        internal List<String> ReadSelectedTests()
        {
            var root = doc.Root;

            if (!root.Descendants(SettingGroup.Tests).Any())
                return new List<string>();

            return root.Element(SettingGroup.Tests).Elements(Setting.TestName)
                .Select(x => (string)x.Attribute("Name")).ToList();
        }

        internal void BuildRunnerExample(string testName)
        {
            var runner = new XDocument();
            runner.Add(new XElement("config"));
            var config = runner.Root;

            var general = new XElement("general");
            general.Add(new XElement("browserbin", ReadSetting(SettingGroup.Browser, Setting.BrowserPath)));
            general.Add(new XElement("browserheadless", ReadSetting(SettingGroup.Browser, Setting.Headless)));

            var site_dst = new XElement("site_dst");
            site_dst.Add(new XElement("rmhost"));
            site_dst.Add(new XElement("url", ReadSetting(SettingGroup.Browser, Setting.URL)));
            site_dst.Add(new XElement("login", ReadSetting(SettingGroup.Browser, Setting.AcuUser)));
            site_dst.Add(new XElement("pswd", ReadSetting(SettingGroup.Browser, Setting.AcuPassword)));
            site_dst.Add(new XElement("lang", "English"));
            site_dst.Add(new XElement("cmpid"));
            general.Add(site_dst);

            var logging = new XElement("logging");
            var logStorage = new XElement("logStorage");
            logStorage.Add(new XAttribute("type", "txtfile"));
            logStorage.Add(new XAttribute("level", "DEBUG"));
            logStorage.Add(new XAttribute("outputFolder", ReadSetting(SettingGroup.Logging, Setting.OutputPath)));
            logStorage.Add(new XAttribute("screenshotActive", "true"));
            logStorage.Add(new XAttribute("screenshotOutputFolder", ReadSetting(SettingGroup.Logging, Setting.ScreenshotPath)));
            logging.Add(logStorage);
            general.Add(logging);
            config.Add(general);

            var testing = new XElement("testing");
            var check = new XElement("Check");
            check.Add(new XAttribute("Name", testName));
            testing.Add(check);
            config.Add(testing);

            runner.Save("RunnerExample.xml");
        }
    }
}
