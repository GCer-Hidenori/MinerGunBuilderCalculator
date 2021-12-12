using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinerGunBuilderCalculator
{
    public partial class Form_VersionInfo : Form
    {
        const string version = "0.4";
        public Form_VersionInfo()
        {
            InitializeComponent();
            label_version_number.Text = "version " + version;
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            var info = new System.Diagnostics.ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = "https://twitter.com/Hidenori_tw",
            };
            
            System.Diagnostics.Process.Start(info);
        }
    }
}
