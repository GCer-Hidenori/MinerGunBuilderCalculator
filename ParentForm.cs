using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinerGunBuilderCalculator
{
    public partial class ParentForm : Form
    {
        ItemForm itemForm = null;
        Form_VersionInfo versionForm = null;

        public ParentForm()
        {
            InitializeComponent();
            menuStrip1.MdiWindowListItem = windowwToolStripMenuItem;
            itemForm = new ItemForm();
            itemForm.MdiParent = this;
            itemForm.Show();
        }
        private void NewShip()
        {
            ShipForm shipForm = new ShipForm();
            ShipParameter shipParamater = new();
            ShipLayoutManager shipLayoutManager = new ShipLayoutManager(shipForm, shipParamater, 14);
            shipForm.shipLayoutManager = shipLayoutManager;
            shipForm.shipParamater = shipParamater;

            // Set the Parent Form of the Child window.
            shipForm.MdiParent = this;
            // Display the new form.
            shipForm.Show();
        }

        private void NewShipToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewShip();
        }
        private void NewItemWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(itemForm == null || itemForm.IsDisposed == true)
            {
                itemForm = new ItemForm();
                itemForm.MdiParent = this;
                itemForm.Show();
            }
        }
        private void LoadShip()
        {
            string save_file_name = null;
            var save_data = SaveData.Load(out save_file_name);
            if(save_data != null)
            {
                ShipForm shipForm = new ShipForm();
                shipForm.Text = Path.GetFileName(save_file_name);
                shipForm.save_file_name = save_file_name;
                ShipParameter shipParamater = save_data.shipParameter;
                ShipLayoutManager shipLayoutManager = new ShipLayoutManager(shipForm, shipParamater, save_data.thing_layout);
                shipForm.shipLayoutManager = shipLayoutManager;
                shipForm.shipParamater = shipParamater;

                // Set the Parent Form of the Child window.
                shipForm.MdiParent = this;
                // Display the new form.
                shipForm.Show();
            }
        }
        private void LoadShipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadShip();
        }

        private void SaveShip()
        {
            if(ShipForm.Current != null)
            {
                ShipForm shipForm = ShipForm.Current;
                var shipLayoutManager = shipForm.GetShipLayoutManager();
                
                var save_file_name = SaveData.Save(shipLayoutManager.thing_layout,shipLayoutManager.GetShipParameter(),false,shipForm.save_file_name);
                shipForm.save_file_name = save_file_name;
                shipForm.Text = Path.GetFileName(save_file_name);
            }
        }
        private void SaveShipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveShip();
        }

        private void SaveAsShipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ShipForm.Current != null)
            {
                ShipForm shipForm = ShipForm.Current;
                var shipLayoutManager = shipForm.GetShipLayoutManager();

                var save_file_name = SaveData.Save(shipLayoutManager.thing_layout, shipLayoutManager.GetShipParameter(), true);
                shipForm.save_file_name = save_file_name;
                shipForm.Text = Path.GetFileName(save_file_name);
            }
        }

        private void ParentForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control)
            {
                if (e.KeyCode == Keys.N) // Ctrl+N
                {
                    NewShip();
                }
                else if (e.KeyCode == Keys.S)
                {
                    SaveShip();

                }
                else if (e.KeyCode == Keys.O)
                {
                    LoadShip();
                }      
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (versionForm == null || versionForm.IsDisposed)
            {
                versionForm = new Form_VersionInfo();
                versionForm.ShowDialog();
                versionForm.Dispose();
            }
        }
    }
}
