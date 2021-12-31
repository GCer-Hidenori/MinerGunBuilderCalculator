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

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            drawTextHext_01();
        }




        
        int d_i = 0;
        int d_j = 1;

        private void drawTextHext_01()
        {
            var panel = new Panel
            {
                //BackColor = SystemColors.ControlDarkDark,
                Width = 40,
                Height = 40
            };
            panel.SetBounds(0, 0, 40, 40);
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

            System.Drawing.Drawing2D.GraphicsPath path =
                new System.Drawing.Drawing2D.GraphicsPath(points, types);
            panel.Region = new Region(path);
            this.Controls.Add(panel);
            
            panel.Location = new Point((int)(11-3-3-2 + d_i * 53), (int)(9-3-3 + d_j * 30));
            d_i += 1;
            d_j += 1;
        }
        private void drawTestSQ_01()
        {
            decimal scale_x = (decimal)this.ClientSize.Width / 686.3607m;
            decimal scale_y = (decimal)this.ClientSize.Height / 814.7583m;

            //System.Diagnostics.Debug.WriteLine(scale);

            //var resource_manager_othres = Resource_Others.ResourceManager;
            //var image = (Bitmap)resource_manager_othres.GetObject("gray_hex");
            //image.MakeTransparent(Color.White);

            var panel_top = new Panel
            {
                BackColor = SystemColors.ControlDarkDark,
                Width = 25,
                Height = 2
            };
            this.Controls.Add(panel_top);
            panel_top.Location = new Point((int)(11 + d_i * 53.333333333333336), (int)(9 + d_j * 30.444444444444443));

            var panel_right = new Panel
            {
                BackColor = SystemColors.ControlDarkDark,
                Width = 2,
                Height = 25
            };
            this.Controls.Add(panel_right);
            panel_right.Location = new Point((int)(11 + d_i * 53.333333333333336 + 25 - 1), (int)(9 + d_j * 30.444444444444443));
            var panel_bottom = new Panel
            {
                BackColor = SystemColors.ControlDarkDark,
                Width = 25,
                Height = 2
            };
            this.Controls.Add(panel_bottom);
            panel_bottom.Location = new Point((int)(11 + d_i * 53.333333333333336), (int)(9 + d_j * 30.444444444444443 + 25 - 1));
            var panel_left = new Panel
            {
                BackColor = SystemColors.ControlDarkDark,
                Width = 2,
                Height = 25
            };
            this.Controls.Add(panel_left);
            panel_left.Location = new Point((int)(11 + d_i * 53.333333333333336), (int)(9 + d_j * 30.444444444444443));
           
            d_i += 1;
            d_j += 1;
        }
        private void drawTest05()
        {
            decimal scale_x = (decimal)this.ClientSize.Width / 686.3607m;
            decimal scale_y = (decimal)this.ClientSize.Height / 814.7583m;

            //System.Diagnostics.Debug.WriteLine(scale);

            var resource_manager_othres = Resource_Others.ResourceManager;
            var image = (Bitmap)resource_manager_othres.GetObject("gray_hex");
            image.MakeTransparent(Color.White);

            var pb = new PictureBox
            {
                BackgroundImageLayout = ImageLayout.Zoom,
                BackgroundImage = image,
                Width = (int)(56.646m * scale_x),
                Height = (int)(49.0569m * scale_y),

                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(pb);
            pb.Location = new Point((int)(0 + d_i * 70 * scale_x), (int)(3 + (d_j+1) * 40 * scale_y));
            d_i += 1;
            d_j += 1;
        }
        private void drawTest04()
        {
            decimal scale_x = (decimal)this.ClientSize.Width / 686.3607m;
            decimal scale_y = (decimal)this.ClientSize.Height / 814.7583m;

            //System.Diagnostics.Debug.WriteLine(scale);

            var resource_manager_othres = Resource_Others.ResourceManager;
            var image = (Image)resource_manager_othres.GetObject("gray_hex");

            var pb = new PictureBox
            {
                BackgroundImageLayout = ImageLayout.Zoom,
                BackgroundImage = image,
                Width = (int)(56.646m * scale_x),
                Height = (int)(49.0569m * scale_y),

                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(pb);
            pb.Location = new Point((int)(0 + d_i * 70 * scale_x), (int)(3 + (d_j+1) * 40 * scale_y));
            d_i += 1;
            d_j += 1;
        }
        private void drawTest03()
        {
            decimal scale = (decimal)this.Size.Width / 686.3607m;

            System.Diagnostics.Debug.WriteLine(scale);

            var resource_manager_othres = Resource_Others.ResourceManager;
            var image = (Image)resource_manager_othres.GetObject("gray_hex");

            

            var pb = new PictureBox
            {
                BackgroundImageLayout = ImageLayout.Zoom,
                BackgroundImage = image,
                Width = (int)(56.646m * scale),
                Height = (int)(49.0569m * scale),

                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(pb);
            pb.Location = new Point((int)(0 + d_i * 70 * scale), (int)(0 + d_j * 40 * scale));
            d_i += 1;
            d_j += 1;
        }
        private void drawTest02()
        {
            //double scale = 686.3607/this.BackgroundImage.Size.Width ;
            //double scale = this.Size.Width / 686.3607;
            //double scale = this.BackgroundImage.Size.Width / 2591 ;
            double scale = (double)this.Size.Width / this.BackgroundImage.Size.Width;

            System.Diagnostics.Debug.WriteLine(scale);

            var resource_manager_othres = Resource_Others.ResourceManager;
            var image = (Image)resource_manager_othres.GetObject("gray_hex");

            var image_size_width = image.Size.Width;
            var image_size_height = image.Size.Height;
            
            var pb = new PictureBox
            {
                BackgroundImageLayout = ImageLayout.Zoom,
                BackgroundImage = image,
                Width = (int)(40 * scale),
                Height = (int)(40 * scale),

                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(pb);
            pb.Location = new Point((int)(0 + d_i * 150.9993 * scale),(int)( 0 + d_j * 150.9993 * scale));
            d_i += 1;
            d_j += 1;
        }
        private void drawTest01()
        {
            double scale = 686.3607/this.BackgroundImage.Size.Width ;
            System.Diagnostics.Debug.WriteLine(scale);

            var resource_manager_othres = Resource_Others.ResourceManager;
            var image = (Image)resource_manager_othres.GetObject("gray_hex");

            var image_size_width = image.Size.Width;
            var image_size_height = image.Size.Height;
            
            var pb = new PictureBox
            {
                BackgroundImageLayout = ImageLayout.Zoom,
                BackgroundImage = image,
                Width = (int)(image_size_width * scale),
                Height = (int)(image_size_height * scale),
                //Name = idictionary.Key.ToString(),

                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(pb);
            pb.Location = new Point(0, 0);
            return;
            ///
            List<ImageLayout> list_imagelayout = new() { ImageLayout.Zoom,ImageLayout.Stretch,ImageLayout.Center,ImageLayout.None};
            List<PictureBoxSizeMode> list_sizemode = new() { PictureBoxSizeMode.StretchImage, PictureBoxSizeMode.Zoom, PictureBoxSizeMode.AutoSize, PictureBoxSizeMode.CenterImage, PictureBoxSizeMode.Normal };
            for(int i = 0;i < list_imagelayout.Count; i++)
            {
                ImageLayout imagelayout = list_imagelayout[i];
                for(int j = 0;j < list_sizemode.Count; j++)
                {
                    PictureBoxSizeMode pictureBoxSizeMode = list_sizemode[j];
                    image = (Image)resource_manager_othres.GetObject("gray_hex");

                    image_size_width = image.Size.Width;
                    image_size_height = image.Size.Height;

                    pb = new PictureBox
                    {
                        BackgroundImageLayout = imagelayout,
                        BackgroundImage = image,
                        Width = (int)(image_size_width * scale),
                        Height = (int)(image_size_height * scale),
                        //Name = idictionary.Key.ToString(),

                        SizeMode = pictureBoxSizeMode,
                    };
                    this.Controls.Add(pb);
                    pb.Location = new Point((i+1) * 50,(j+1)* 50);
                }
            }

            
            ///
        }
        */
    }
}
