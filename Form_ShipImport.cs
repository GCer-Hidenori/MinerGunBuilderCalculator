using System;
using System.IO;
using System.Windows.Forms;

namespace MinerGunBuilderCalculator
{
    public partial class Form_ShipImport : Form
    {
        public string ImportContent;
        public string ImportFile = "Clipboard";

        public Form_ShipImport()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();
            ofd.FileName = "";
            ofd.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

            ofd.Filter = "Ship export file(*.txt)|*.txt|All files(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "Load";

            ofd.RestoreDirectory = true;

            ofd.CheckFileExists = true;

            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var sr = new StreamReader(ofd.FileName, System.Text.Encoding.UTF8);

                ImportContent = sr.ReadToEnd();
                ImportFile = ofd.FileName;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ImportContent = textBox1.Text;
        }
    }
}
