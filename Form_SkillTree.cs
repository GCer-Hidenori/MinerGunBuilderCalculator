using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MinerGunBuilderCalculator
{
    public partial class Form_SkillTree : Form
    {
        PictureBox[,] ary_pb = new PictureBox[10, 20];

        public HashSet<string> SkillList;
        public ShipLayoutManager shipLayoutManager = null;

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

                if (SkillList.Contains(name))
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


            if(SkillList.Contains(name))
            {
                SkillList.Remove(name);
            }
            else
            {
                SkillList.Add(name);
            }
            RefreshHex(x, y, SkillList.Contains(name));
            shipLayoutManager.NotifyShipLayoutChange2Observer();
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
