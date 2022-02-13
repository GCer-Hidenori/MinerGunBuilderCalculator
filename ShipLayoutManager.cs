using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MinerGunBuilderCalculator
{
    public enum TurnDirection
    {
        LEFT = -1,
        RIGHT = 1
    }
    enum MouseHVoerEffect
    {
        ARROW_LEFT,
        ARROW_RIGHT,
        CROSSMARK
    }
    public class ShipLayoutManager
    {
        public Thing[,] thing_layout;
        private PictureBox[,] picturebox_layout;

        private Dictionary<PictureBox, Point> dic_picturebox;

        private int shipsize;
        private Form_Ship form_ship;
        private Point? mouse_hvoer_position;
        private IList<IShipLayoutChangeObserver> ship_layoutchange_observers = new List<IShipLayoutChangeObserver>();
        public ShipParameter ship_parameter;
        internal Profile profile;
        private MouseHVoerEffect? mouse_hover_effect;
        const int panelsize = 39;

        public void AddShipLayoutChangeObserver(IShipLayoutChangeObserver observer)
        {
            ship_layoutchange_observers.Add(observer);
        }

        public void NotifyShipLayoutChange2Observer()
        {
            foreach(var observer in ship_layoutchange_observers)
            {
                observer.ShipLayoutChanged(thing_layout, ship_parameter,profile,picturebox_layout);
            }
        }
        public ShipLayoutManager()
        {
        }

        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="_tab">TableLayoutPanel</param>
        /// <param name="_size">Ship size</param>
        public ShipLayoutManager(Form_Ship form_ship, ShipParameter ship_parameter,Profile profile,int size=12)
        {
            this.form_ship = form_ship;
            this.shipsize = size;
            this.ship_parameter = ship_parameter;
            this.profile = profile;
            CreateInitialThingLayout(); // set initial thing_layout
            CreatePictureBoxs();
        }

        public ShipLayoutManager(Form_Ship form_ship, ShipParameter ship_parameter,Profile profile,Thing[,] thing_layout)
        {
            this.form_ship = form_ship;

            this.thing_layout = thing_layout;
            shipsize = thing_layout.GetLength(0);
            this.ship_parameter = ship_parameter;
            this.profile = profile;
            CreatePictureBoxs();
        }
        private void CreateInitialThingLayout()
        {
            thing_layout = new Thing[shipsize, shipsize];


            int x;
            int y = 0;
            for (x = 0; x < shipsize; x++)
            {
                for (y = 0; y < shipsize; y++)
                {
                    Thing item;
                    if (x == 0 || x == shipsize - 1 || y == 0 || y == shipsize - 1)
                    {
                        item = new Parts_01_Wall(thing_layout);
                    }
                    else
                    {
                        item = new Parts_Null(thing_layout);
                    }
                    thing_layout[x, y] = item;
                }
            }
            Parts_03_ProjectileGenerator item_ProjectileGenerator = new(thing_layout);
            thing_layout[x / 2, y - 1] = item_ProjectileGenerator;
        }

        private void PictureBox_MouseHover(object sender, EventArgs e)
        {
            var resource_manager = Resource_Effects.ResourceManager;
            PictureBox pb = (PictureBox)sender;
            if (pb.BackgroundImage != null)
            {
                var pos = dic_picturebox[pb];

                if (thing_layout[pos.X, pos.Y] is not Parts_01_Wall)
                {
                    mouse_hvoer_position = pos;
                    pb.MouseLeave += PictureBox_MouseLeave;
                }
            }
        }
        private void PictureBox_MouseMove(object sender,MouseEventArgs e)
        {
            if(mouse_hvoer_position != null)
            {
                PictureBox pb = (PictureBox)sender;
                var pb_pos = dic_picturebox[pb];
                var resource_manager = Resource_Effects.ResourceManager;

                Thing thing = thing_layout[pb_pos.X, pb_pos.Y];

                if(thing.IsRotatable &&  pb_pos == mouse_hvoer_position && e.Y < pb.Height / 3.0)
                {
                    if (e.X < pb.Width / 3.0)
                    {
                        //click left side
                        var arrow_image = (Bitmap)resource_manager.GetObject("arrow_left");
                        arrow_image.MakeTransparent(arrow_image.GetPixel(0, 0));
                        pb.Image = arrow_image;

                        mouse_hover_effect = MouseHVoerEffect.ARROW_LEFT;

                        return;
                    }
                    else if (e.X > pb.Width * 2.0 / 3)
                    {
                        //click right side
                        var arrow_image = (Bitmap)resource_manager.GetObject("arrow_right");
                        arrow_image.MakeTransparent(arrow_image.GetPixel(0, 0));
                        pb.Image = arrow_image;

                        mouse_hover_effect = MouseHVoerEffect.ARROW_RIGHT;

                        return;
                    }
                    else
                    {
                        mouse_hover_effect = null;
                        pb.Image = null;
                    }
                }else if (thing.IsRemovable && pb_pos == mouse_hvoer_position && e.Y > pb.Height / 3.0*2)
                {
                    var arrow_image = (Bitmap)resource_manager.GetObject("crossmark");
                    arrow_image.MakeTransparent(arrow_image.GetPixel(0, 0));
                    pb.Image = arrow_image;
                    mouse_hover_effect = MouseHVoerEffect.CROSSMARK;
                }
                else
                {
                    mouse_hover_effect = null;
                    pb.Image = null;
                }
            }
        }

        private void PictureBox_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.Image = null;
            pb.MouseLeave -= PictureBox_MouseLeave;

            var pb_pos = dic_picturebox[pb];
            if(pb_pos == mouse_hvoer_position)
            {
                mouse_hvoer_position = null;
                mouse_hover_effect = null;
            }
        }

        private void Picturebox_click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PictureBox pb = (PictureBox)sender;
                var pb_pos = dic_picturebox[pb];

                switch (mouse_hover_effect)
                {
                    case MouseHVoerEffect.ARROW_LEFT:
                        thing_layout[pb_pos.X, pb_pos.Y].Turn(TurnDirection.LEFT);
                        Rotate_Image(pb, thing_layout[pb_pos.X, pb_pos.Y]);

                        NotifyShipLayoutChange2Observer();
                        return;
                    case MouseHVoerEffect.ARROW_RIGHT:
                        thing_layout[pb_pos.X, pb_pos.Y].Turn(TurnDirection.RIGHT);
                        Rotate_Image(pb, thing_layout[pb_pos.X, pb_pos.Y]);
                        NotifyShipLayoutChange2Observer();
                        return;
                    case MouseHVoerEffect.CROSSMARK:
                        thing_layout[pb_pos.X, pb_pos.Y] = new Parts_Null(thing_layout);
			            pb.BackgroundImage = null;
                        NotifyShipLayoutChange2Observer();
                        return;
                    default:
                        break;
                }
                pb.DoDragDrop(pb, DragDropEffects.All);

            }
        }

        private static void Rotate_Image(PictureBox pb,Thing item)
        {
            Image image = Item2image(item);

            switch (item.direction)
            {
                case Thing.Direction.TOP:
                    break;
                case Thing.Direction.RIGHT:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case Thing.Direction.DOWN:
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case Thing.Direction.LEFT:
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
            }
            pb.BackgroundImage = image;
        }

        private static Image Item2image(Thing item)
        {
            var resource_manager_shipparts = Resource_ShipParts.ResourceManager;
            var resource_manager_item = Resource_Item.ResourceManager;
            var resource_manager_legendary = Resource_Legendary.ResourceManager;
            switch (item)
            {
                case Parts_Null:
                    return null;
                case Parts_03_ProjectileGenerator:
                    return (Image)resource_manager_shipparts.GetObject("Parts_03_ProjectileGenerator");
                default:
                    var image = (Image)resource_manager_shipparts.GetObject(item.GetType().Name.ToString());
                    if(image != null)
                    {
                        return image;
                    }
                    else
                    {
                        image = (Image)resource_manager_item.GetObject(item.GetType().Name.ToString()) ?? (Image)resource_manager_legendary.GetObject(item.GetType().Name.ToString());
                        if (image != null)
                        {
                            return image;
                        }
                        throw new NotImplementedException();
                    }
            }
        }
        private Thing ResourceName2Item(string resource_name)
        {
            //Thing item = null;

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            string typename = typeof(ShipLayoutManager).Namespace + "." + resource_name;
            Thing item = (Thing)assembly.CreateInstance(typename, true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { thing_layout }, null, null);
            if(item == null)
            {
                throw new Exception();
            }
            return item;
        }
       
        private void PictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                var to_pb = (PictureBox)sender;
                var from_pb = (PictureBox)e.Data.GetData(typeof(PictureBox));
                if (from_pb.Parent == to_pb.Parent)
                {
                    var from_pos = dic_picturebox[from_pb];
                    if (thing_layout[from_pos.X, from_pos.Y].GetType() != typeof(Parts_Null))
                    {
                        e.Effect = DragDropEffects.Move;
                    }
                }
                else
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PictureBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                var to_pb = (PictureBox)sender;
                var to_pos = dic_picturebox[to_pb];
                var from_pb = (PictureBox)e.Data.GetData(typeof(PictureBox));
                Thing from_obj, to_obj;
                
                if (from_pb.Parent == to_pb.Parent)
                {
                    (from_pb.BackgroundImage, to_pb.BackgroundImage) = (to_pb.BackgroundImage, from_pb.BackgroundImage);
                    var from_pos = dic_picturebox[from_pb];
                    from_obj = thing_layout[from_pos.X, from_pos.Y];
                    to_obj = thing_layout[to_pos.X, to_pos.Y];
                    thing_layout[from_pos.X, from_pos.Y] = to_obj;
                    thing_layout[to_pos.X, to_pos.Y] = from_obj;

                    NotifyShipLayoutChange2Observer();
                }
                else
                {
                    to_pb.BackgroundImage = from_pb.BackgroundImage;
                    to_obj = ResourceName2Item(from_pb.Name);
               
                    thing_layout[to_pos.X, to_pos.Y] = to_obj;

                    NotifyShipLayoutChange2Observer();
                }
            }
        }

        private void CreatePictureBoxs()
        {
            picturebox_layout = new PictureBox[shipsize,shipsize];
            dic_picturebox = new Dictionary<PictureBox, Point>();
            for (var x = 0; x < shipsize; x++)
            {
                for (var y = 0; y < shipsize; y++)
                {
                    var pb = new PictureBox
                    {
                        AllowDrop = true,
                        SizeMode = PictureBoxSizeMode.StretchImage,

                        Location = new Point(x * panelsize, y * panelsize),
                        Size = new Size(panelsize, panelsize),
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    pb.MouseDown += Picturebox_click;
                    pb.DragEnter += PictureBox_DragEnter;
                    pb.DragDrop += PictureBox_DragDrop;
                    pb.MouseHover += PictureBox_MouseHover;
                    pb.MouseMove += PictureBox_MouseMove;
                    form_ship.AddPictureBox(pb);
                    dic_picturebox[pb] = new Point(x, y);
                    picturebox_layout[x,y] = pb;
                }
            }

        }
        public void Draw()
        {
            PictureBox pb;
            for (var x = 0;x < shipsize; x++)
            {
                for(var y = 0;y < shipsize; y++)
                {
                    pb = picturebox_layout[x,y];
                    pb.BackgroundImageLayout = ImageLayout.Zoom;
                    pb.BackgroundImage = Item2image(thing_layout[x, y]);
                    Rotate_Image(pb, thing_layout[x, y]);
                }
            }
            form_ship.SetShipParameteLabelText(ship_parameter.base_damage, ship_parameter.fire_rate, ship_parameter.projectile_speed, ship_parameter.projectile_lifetime);
            form_ship.SetProfileParameteLabelText(profile.Highest_Reached_Tier_in_World_Map,profile.Highest_Cleared_Tier_in_World_Map,profile.Play_Hour);
            NotifyShipLayoutChange2Observer();
        }

    }
}
