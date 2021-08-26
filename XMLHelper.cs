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

        public XMLHelper(string settingsName)
        {
            if (File.Exists(settingsName + ".xml"))
                doc = XDocument.Load(settingsName + ".xml");
            else
                doc = new XDocument();
        }
    }
}
