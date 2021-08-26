using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalTestPortal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            var settingsName = cSettings.Text;
            if (string.IsNullOrEmpty(settingsName))
                return;

            var xmlHelper = new XMLHelper(settingsName);

        }
    }
}
