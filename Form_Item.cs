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
    public partial class Form_Item : Form
    {
        public Form_Item()
        {
            InitializeComponent();
            Load_images(tableLayoutPanel_Items,Resource_Item.ResourceManager);
            Load_images(tableLayoutPanel_Others,Resource_ShipParts.ResourceManager,"Parts_03_ProjectileGenerator");
            Load_images(tableLayoutPanel_Legendary,Resource_Legendary.ResourceManager);
            SetToolTips(tableLayoutPanel_Items);
            SetToolTips(tableLayoutPanel_Legendary);
            SetToolTips(tableLayoutPanel_Others);
        }
        private void Load_images(TableLayoutPanel tab, System.Resources.ResourceManager resource_manager,string not_show_thing_name=null)
        {
            var resourceSet = resource_manager.GetResourceSet(Application.CurrentCulture, true, true);
            System.Collections.IDictionaryEnumerator idictionary = resourceSet.GetEnumerator();

            var list_picuture_box = new List<PictureBox>();
            while (idictionary.MoveNext())
            {
                Image image = (Image)resource_manager.GetObject(idictionary.Key.ToString());
                if(idictionary.Key.ToString()==not_show_thing_name)continue;
                var pb = new PictureBox
                {
                    BackgroundImageLayout = ImageLayout.Zoom,
                    BackgroundImage = image,
                    Width = this.Size.Width / 4,
                    Name = idictionary.Key.ToString(),
                    Height = Width,
                    SizeMode = PictureBoxSizeMode.StretchImage,

                };
                //pb.Height = pb.Width;
                //pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.MouseDown += Picturebox_click;
                

                list_picuture_box.Add(pb);
            }
            list_picuture_box.Sort((a, b) => a.Name.CompareTo(b.Name));

            for (var i = 0; i < tab.RowCount; i++)
            {
                for (var j = 0; j < tab.ColumnCount; j++)
                {
                    if (list_picuture_box.Count > 0)
                    {
                        PictureBox pb = list_picuture_box.First<PictureBox>();
                        tab.Controls.Add(pb, j, i);
                        list_picuture_box.RemoveAt(0);
                    }
                }
            }
        }

        private static void SetToolTips(TableLayoutPanel tab)
        {
            var resource_manager = Resource_tooltips.ResourceManager;
            for (int x = 0; x < tab.ColumnCount; x++)
            {
                for(int y = 0; y < tab.RowCount; y++)
                {
                    var pb = tab.GetControlFromPosition(x, y);
                    if (pb != null)
                    {
                        ToolTip tooltip = new();
                        tooltip.SetToolTip(pb, resource_manager.GetString(pb.Name));
                        tooltip.InitialDelay = 500;
                        tooltip.ReshowDelay = 250;
                    }
                }
            }
        }
   
        private void Picturebox_click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pb = (PictureBox)sender;
                pb.DoDragDrop(pb, DragDropEffects.All);
            }
        }

    }
}
