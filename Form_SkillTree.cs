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
    public partial class Form_SkillTree : Form
    {
        PictureBox[,] ary_pb = new PictureBox[10,20];

        public SkillTree skillTree;

        public Form_SkillTree()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }
        private static Bitmap GetImageFromResource(string name)
        {
            var resource_manager = Resource_SkillTree_Images.ResourceManager;
            var resourceSet = resource_manager.GetResourceSet(Application.CurrentCulture, true, true);
            System.Collections.IDictionaryEnumerator idictionary = resourceSet.GetEnumerator();
            while (idictionary.MoveNext())
            {
                var image_resource_name = idictionary.Key.ToString();
                if (image_resource_name.Contains(name))
                {
                    Bitmap image = new((Image)resource_manager.GetObject(image_resource_name),new Size((int)(40/1.5),(int)(40/1.5)));
                    return image;
                }
            }
            throw new NotImplementedException(name);
        }
        private bool IsValid(string name)
        {
            return name switch
            {
                "00_07" => skillTree.v00_07_add_5_damage,
                "01_08" => skillTree.v01_08_add_30_damage,
                "04_11" => skillTree.v04_11_add_5_damage,
                "05_10" => skillTree.v05_10_add_5_damage,
                "03_12" => skillTree.v03_12_add_5_damage,
                "02_13" => skillTree.v02_13_increase_chance,
                "01_12" => skillTree.v01_12_high_multiplier,
                "02_15" => skillTree.v02_15_increase_chance,
                "01_16" => skillTree.v01_16_high_times,
                "03_16" => skillTree.v03_16_high_multiplier,
                "03_18" => skillTree.v03_18_high_multiplier,
                _ => throw new NotImplementedException(),
            };
        }
        public void RefreshHex(int x,int y,bool state)
        {
            PictureBox pb = ary_pb[x,y];
            if (state)
            {
                pb.BackColor = Color.White;
            }
            else
            {
                pb.BackColor = SystemColors.ControlDarkDark;
            }
        }
        public void DrawSkills()
        {
            var resource_manager = Resource_skilltree.ResourceManager;
            var resourceSet = resource_manager.GetResourceSet(Application.CurrentCulture, true, true);
            System.Collections.IDictionaryEnumerator idictionary = resourceSet.GetEnumerator();
            while (idictionary.MoveNext())
            {
                string name = idictionary.Key.ToString();
                string discription = resource_manager.GetString(name);

                var tmpary = name.Split('_');
                int x, y;
                (x, y) = (int.Parse(tmpary[0]), int.Parse(tmpary[1]));

                Bitmap image = GetImageFromResource(name);
                PictureBox pb = CreateHex(image);
                pb.Name = name;

                if (IsValid(name))
                {
                    pb.BackColor = Color.White;
                }
                else
                {
                    pb.BackColor = SystemColors.ControlDarkDark;
                }

                this.Controls.Add(pb);
                pb.Location = new Point((int)(3 + x * 53), (int)(3 + y * 30));

                ToolTip tooltip = new();
                tooltip.SetToolTip(pb, discription);
                tooltip.InitialDelay = 500;
                tooltip.ReshowDelay = 250;

                pb.Click += Pb_Click;

                ary_pb[x,y] = pb;
            }
        }

        private void Pb_Click(object sender, EventArgs e)
        {
            string name = ((PictureBox)sender).Name;
            var tmpary = name.Split('_');
            int x, y;
            (x, y) = (int.Parse(tmpary[0]), int.Parse(tmpary[1]));
            switch (name)
            {
                case "00_07":
                    skillTree.v00_07_add_5_damage = !skillTree.v00_07_add_5_damage;
                    RefreshHex(x, y, skillTree.v00_07_add_5_damage);
                    skillTree.shipLayoutManager.NotifyShipLayoutChange2Observer();
                    break;
                case "01_08":
                    skillTree.v01_08_add_30_damage = !skillTree.v01_08_add_30_damage;
                    RefreshHex(x, y, skillTree.v01_08_add_30_damage);
                    skillTree.shipLayoutManager.NotifyShipLayoutChange2Observer();
                    break;
                case "04_11":
                    skillTree.v04_11_add_5_damage = !skillTree.v04_11_add_5_damage;
                    RefreshHex(x, y, skillTree.v04_11_add_5_damage);
                    skillTree.shipLayoutManager.NotifyShipLayoutChange2Observer();
                    break;
                case "05_10":
                    skillTree.v05_10_add_5_damage = !skillTree.v05_10_add_5_damage;
                    RefreshHex(x, y, skillTree.v05_10_add_5_damage);
                    skillTree.shipLayoutManager.NotifyShipLayoutChange2Observer();
                    break;
                case "03_12":
                    skillTree.v03_12_add_5_damage = !skillTree.v03_12_add_5_damage;
                    RefreshHex(x, y, skillTree.v03_12_add_5_damage);
                    skillTree.shipLayoutManager.NotifyShipLayoutChange2Observer();
                    break;
                case "02_13":
                    skillTree.v02_13_increase_chance = !skillTree.v02_13_increase_chance;
                    RefreshHex(x, y, skillTree.v02_13_increase_chance);
                    skillTree.shipLayoutManager.NotifyShipLayoutChange2Observer();
                    break;
                case "01_12":
                    skillTree.v01_12_high_multiplier = !skillTree.v01_12_high_multiplier;
                    RefreshHex(x, y, skillTree.v01_12_high_multiplier);
                    skillTree.shipLayoutManager.NotifyShipLayoutChange2Observer();
                    break;
                case "02_15":
                    skillTree.v02_15_increase_chance = !skillTree.v02_15_increase_chance;
                    RefreshHex(x, y, skillTree.v02_15_increase_chance);
                    skillTree.shipLayoutManager.NotifyShipLayoutChange2Observer();
                    break;
                case "01_16":
                    skillTree.v01_16_high_times = !skillTree.v01_16_high_times;
                    RefreshHex(x, y, skillTree.v01_16_high_times);
                    skillTree.shipLayoutManager.NotifyShipLayoutChange2Observer();
                    break;
                case "03_16":
                    skillTree.v03_16_high_multiplier = !skillTree.v03_16_high_multiplier;
                    RefreshHex(x, y, skillTree.v03_16_high_multiplier);
                    skillTree.shipLayoutManager.NotifyShipLayoutChange2Observer();
                    break;
                case "03_18":
                    skillTree.v03_18_high_multiplier = !skillTree.v03_18_high_multiplier;
                    RefreshHex(x, y, skillTree.v03_18_high_multiplier);
                    skillTree.shipLayoutManager.NotifyShipLayoutChange2Observer();
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private static PictureBox CreateHex(Bitmap image)
        {
            var pb = new PictureBox
            {
                //BackColor = SystemColors.ControlDarkDark,
                Width = 40,
                Height = 40
            };
            pb.SetBounds(0, 0, 40, 40);
            Point[] points = {
        new Point(40, 17),
        new Point(30, 35),
        new Point(10, 35),
        new Point(0, 17),
        new Point(10, 0),
        new Point(30, 0)
            };
            byte[] types =
               {(byte) System.Drawing.Drawing2D.PathPointType.Line,
        (byte) System.Drawing.Drawing2D.PathPointType.Line,
        (byte) System.Drawing.Drawing2D.PathPointType.Line,
        (byte) System.Drawing.Drawing2D.PathPointType.Line,
        (byte) System.Drawing.Drawing2D.PathPointType.Line,
        (byte) System.Drawing.Drawing2D.PathPointType.Line};

            System.Drawing.Drawing2D.GraphicsPath path = new(points, types);
            pb.Region = new Region(path);

            image.MakeTransparent(Color.White);
            
            pb.Image = image;
            pb.Padding = new Padding(0, 0, 0, 5);
      
            pb.SizeMode = PictureBoxSizeMode.CenterImage;
            return pb;
            
        }
    }
}
