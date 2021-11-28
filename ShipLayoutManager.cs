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
        private int shipsize;
        private TableLayoutPanel tab;
        private ShipForm shipForm;
        private TableLayoutPanelCellPosition? mouse_hvoer_position;
        private IList<IShipLayoutChangeObserver> ship_layoutchange_observers = new List<IShipLayoutChangeObserver>();
        private ShipParameter ship_parameter;
        private MouseHVoerEffect? mouse_hover_effect;

        public void AddShipLayoutChangeObserver(IShipLayoutChangeObserver observer)
        {
            ship_layoutchange_observers.Add(observer);
        }

        public ShipParameter GetShipParameter()
        {
            return ship_parameter;
        }

        public void NotifyShipLayoutChange2Observer()
        {
            foreach(var observer in ship_layoutchange_observers)
            {
                observer.ShipLayoutChanged(thing_layout, ship_parameter);
            }
        }


        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="_tab">TableLayoutPanel</param>
        /// <param name="_size">Ship size</param>
        public ShipLayoutManager(ShipForm _shipform, ShipParameter _ship_parameter,int _size=12)
        {
            shipForm = _shipform;
            tab = shipForm.GetTableLayoutPanel();
            shipsize = _size;
            ship_parameter = _ship_parameter;
            CreateInitialThingLayout(); // set initial thing_layout
            CreatePictureBoxs();
        }

        public ShipLayoutManager(ShipForm _shipform, ShipParameter _ship_parameter, Thing[,] _thing_layout)
        {
            shipForm = _shipform;
            tab = shipForm.GetTableLayoutPanel();

            thing_layout = _thing_layout;
            shipsize = thing_layout.GetLength(0);
            ship_parameter = _ship_parameter;
            CreatePictureBoxs();
        }
        private void CreateInitialThingLayout()
        {
            thing_layout = new Thing[shipsize, shipsize];
            
            int x = 0, y = 0;
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
                TableLayoutPanel tab = shipForm.GetTableLayoutPanel();
                var pos = tab.GetPositionFromControl(pb);
                if (!(thing_layout[pos.Column, pos.Row] is Parts_01_Wall))
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
                TableLayoutPanel tab = shipForm.GetTableLayoutPanel();
                var pb_pos = tab.GetPositionFromControl(pb);
                var resource_manager = Resource_Effects.ResourceManager;

                Thing thing = thing_layout[pb_pos.Column, pb_pos.Row];

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

            TableLayoutPanel tab = shipForm.GetTableLayoutPanel();
            var pb_pos = tab.GetPositionFromControl(pb);
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
                TableLayoutPanel tab = shipForm.GetTableLayoutPanel();
                var pb_pos = tab.GetPositionFromControl(pb);

                switch (mouse_hover_effect)
                {
                    case MouseHVoerEffect.ARROW_LEFT:
                        thing_layout[pb_pos.Column, pb_pos.Row].Turn(TurnDirection.LEFT);
                        Rotate_Image(pb, thing_layout[pb_pos.Column, pb_pos.Row]);

                        NotifyShipLayoutChange2Observer();
                        return;
                    case MouseHVoerEffect.ARROW_RIGHT:
                        thing_layout[pb_pos.Column, pb_pos.Row].Turn(TurnDirection.RIGHT);
                        Rotate_Image(pb, thing_layout[pb_pos.Column, pb_pos.Row]);
                        NotifyShipLayoutChange2Observer();
                        return;
                    case MouseHVoerEffect.CROSSMARK:
                        thing_layout[pb_pos.Column, pb_pos.Row] = new Parts_Null(thing_layout);
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
                        image = (Image)resource_manager_item.GetObject(item.GetType().Name.ToString());
                        if(image != null)
                        {
                            return image;
                        }
                        throw new NotImplementedException();
                    }
            }
        }
        private Thing ResourceName2Item(string resource_name)
        {
            Thing item = null;

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            string typename = typeof(ShipLayoutManager).Namespace + "." + resource_name;
            item = (Thing)assembly.CreateInstance(typename, true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { thing_layout }, null, null);
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
                var from_pos = tab.GetPositionFromControl(from_pb);
                if (from_pb.Parent == to_pb.Parent)
                {
                    if (thing_layout[from_pos.Column, from_pos.Row].GetType() != typeof(Parts_Null))
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
                TableLayoutPanel tab = shipForm.GetTableLayoutPanel();
                var to_pos = tab.GetPositionFromControl(to_pb);
                var from_pb = (PictureBox)e.Data.GetData(typeof(PictureBox));
                Thing from_obj, to_obj;
                
                if (from_pb.Parent == to_pb.Parent)
                {
                    (from_pb.BackgroundImage, to_pb.BackgroundImage) = (to_pb.BackgroundImage, from_pb.BackgroundImage);
                    var from_pos = tab.GetPositionFromControl(from_pb);
                    from_obj = thing_layout[from_pos.Column, from_pos.Row];
                    to_obj = thing_layout[to_pos.Column, to_pos.Row];
                    thing_layout[from_pos.Column, from_pos.Row] = to_obj;
                    thing_layout[to_pos.Column, to_pos.Row] = from_obj;

                    NotifyShipLayoutChange2Observer();
                }
                else
                {
                    to_pb.BackgroundImage = from_pb.BackgroundImage;
                    to_obj = ResourceName2Item(from_pb.Name);
               
                    thing_layout[to_pos.Column, to_pos.Row] = to_obj;

                    NotifyShipLayoutChange2Observer();
                }
            }
        }

        private void CreatePictureBoxs()
        {
            for (var x = 0; x < shipsize; x++)
            {
                for (var y = 0; y < shipsize; y++)
                {
                    var pb = new PictureBox();
                    pb.AllowDrop = true;
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.MouseDown += Picturebox_click;
                    pb.DragEnter += PictureBox_DragEnter;
                    pb.DragDrop += PictureBox_DragDrop;
                    pb.MouseHover += PictureBox_MouseHover;
                    pb.MouseMove += PictureBox_MouseMove;
                    tab.Controls.Add(pb);
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
                    pb = (PictureBox)tab.GetControlFromPosition(x, y);
                    pb.BackgroundImageLayout = ImageLayout.Zoom;
                    pb.BackgroundImage = Item2image(thing_layout[x, y]);
                    Rotate_Image(pb, thing_layout[x, y]);
                }
            }
            shipForm.SetShipParameteLabelText(ship_parameter.base_damage, ship_parameter.fire_rate, ship_parameter.projectile_speed);
            NotifyShipLayoutChange2Observer();
        }

    }
}
