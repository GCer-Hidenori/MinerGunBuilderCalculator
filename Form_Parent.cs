using Microsoft.Extensions.Logging;
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
    public partial class Form_Parent : Form
    {
        Form_Item form_item = null;
        Form_VersionInfo versionForm = null;
        ILogger logger;

        public Form_Parent(ILogger logger)
        {
            InitializeComponent();
            this.logger = logger;
            menuStrip1.MdiWindowListItem = windowwToolStripMenuItem;
            form_item = new Form_Item
            {
                MdiParent = this
            };
            form_item.Show();
        }
        private void NewShip()
        {
            Form_Ship form_ship = new();
            ShipParameter shipParamater = new();
            Profile profile = new();
            ShipLayoutManager shipLayoutManager = new(form_ship, shipParamater, profile, 14);
            form_ship.shipLayoutManager = shipLayoutManager;
            form_ship.shipParamater = shipParamater;
            form_ship.profile = profile;

            // Set the Parent Form of the Child window.
            form_ship.MdiParent = this;
            // Display the new form.
            form_ship.Show();
        }

        private void LoadShip()
        {
            //string save_file_name; // = null;
            var save_data = SaveData.Load(out string save_file_name,logger);
            if(save_data != null)
            {
                Form_Ship form_ship = new();
                form_ship.Text = Path.GetFileName(save_file_name);
                form_ship.save_file_name = save_file_name;
                ShipParameter shipParamater = save_data.shipParameter;
                Profile profile = save_data.profile;
                ShipLayoutManager shipLayoutManager = new(form_ship, shipParamater,profile, save_data.thing_layout);
                form_ship.shipLayoutManager = shipLayoutManager;
                form_ship.shipParamater = shipParamater;
                form_ship.profile = profile;

                // Set the Parent Form of the Child window.
                form_ship.MdiParent = this;
                // Display the new form.
                form_ship.Show();
            }
        }
        private void NewShipToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewShip();
        }
        private void NewItemWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(form_item == null || form_item.IsDisposed == true)
            {
                form_item = new Form_Item
                {
                    MdiParent = this
                };
                form_item.Show();
            }
        }
        private void LoadShipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadShip();
        }

        private static void SaveShip()
        {
            if(Form_Ship.Current != null)
            {
                Form_Ship form_ship = Form_Ship.Current;
                var shipLayoutManager = form_ship.GetShipLayoutManager();
                
                var save_file_name = SaveData.Save(shipLayoutManager.thing_layout,shipLayoutManager.ship_parameter,shipLayoutManager.profile, false,form_ship.save_file_name);
                form_ship.save_file_name = save_file_name;
                form_ship.Text = Path.GetFileName(save_file_name);
            }
        }
        private void SaveShipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveShip();
        }

        private void SaveAsShipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Form_Ship.Current != null)
            {
                Form_Ship form_ship = Form_Ship.Current;
                var shipLayoutManager = form_ship.GetShipLayoutManager();

                var save_file_name = SaveData.Save(shipLayoutManager.thing_layout, shipLayoutManager.ship_parameter,shipLayoutManager.profile, true);
                form_ship.save_file_name = save_file_name;
                form_ship.Text = Path.GetFileName(save_file_name);
            }
        }

        private void Form_Parent_KeyDown(object sender, KeyEventArgs e)
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

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
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
