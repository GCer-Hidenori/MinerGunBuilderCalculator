using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinerGunBuilderCalculator
{
    class FireController : IShipLayoutChangeObserver
    {
        private Form_Graph formGraph = null;
        private ShipForm shipForm;
        private Profile profile;
        private PictureBox[,] picturebox_layout;
        private Thing[,] thing_layout;
        private ShipParameter shipParameter;
        public FireController(ShipForm _shipForm)
        {
            shipForm = _shipForm;
        }
        public void ShipLayoutChanged(Thing[,] _thing_layout, ShipParameter _shipParameter, Profile _profile, PictureBox[,] _picturebox_layout)
        {
            thing_layout = _thing_layout;
            profile = _profile;
            picturebox_layout = _picturebox_layout;
            shipParameter = _shipParameter;
            CreateProjectileFlow(thing_layout);
            DrawProjectileEffect(thing_layout, picturebox_layout);
            DrawEjectorEffect(thing_layout, picturebox_layout);
            CalculateDamage(thing_layout, shipParameter, profile);
        }

        private void CalculateDamage(Thing[,] thing_layout, ShipParameter shipParameter, Profile profile)
        {
            //StringBuilder stringBuilder = new();
            //Hashtable h_ejector = new();
            decimal? total_min_damage = null;
            decimal total_average_damage_per_sec = 0;
            decimal total_average_damage = 0;
            decimal total_max_damage = 0;
            decimal total_max_speed = 0;
            //decimal total_projectile_num = 0;
            decimal total_magnification = 0;

            var thing_1dim_layout = thing_layout.Cast<Thing>();
            IEnumerable<Thing> IEejector = thing_1dim_layout.Where(thing => thing.GetType() == typeof(Parts_02_Ejector));
            //int i = 1;
            foreach (Parts_02_Ejector ejector in IEejector)
            {
                List<ProjectileStat> inbound_projectileStats = new();
                if (ejector.Access_from_abs_top != null) inbound_projectileStats.Add(ejector.Access_from_abs_top.GetOutboundProjectileStat(shipParameter, profile, ejector));
                if (ejector.Access_from_abs_right != null) inbound_projectileStats.Add(ejector.Access_from_abs_right.GetOutboundProjectileStat(shipParameter, profile, ejector));
                if (ejector.Access_from_abs_down != null) inbound_projectileStats.Add(ejector.Access_from_abs_down.GetOutboundProjectileStat(shipParameter, profile, ejector));
                if (ejector.Access_from_abs_left != null) inbound_projectileStats.Add(ejector.Access_from_abs_left.GetOutboundProjectileStat(shipParameter, profile, ejector));

                decimal? each_ejector_min_damage = null;
                decimal each_ejector_average_damage = 0;
                decimal each_ejector_max_damage = 0;
                decimal each_ejector_average_damage_per_sec = 0;
                decimal each_ejector_magnification = 0;

                decimal max_speed = 0;
                //decimal projectile_num = 0;

                foreach (var projectileStats in inbound_projectileStats)
                {
                    //projectile_num++;
                    each_ejector_magnification += projectileStats.magnification;

                    each_ejector_min_damage = (each_ejector_min_damage == null || each_ejector_min_damage > projectileStats.min_damage) ? projectileStats.min_damage : each_ejector_min_damage;

                    each_ejector_max_damage = each_ejector_max_damage < projectileStats.max_damage ? projectileStats.max_damage : each_ejector_max_damage;
                    each_ejector_average_damage += projectileStats.average_damage;
                    each_ejector_average_damage_per_sec += projectileStats.average_damage * projectileStats.magnification * shipParameter.fire_rate;
                    max_speed = max_speed < projectileStats.speed ? projectileStats.speed : max_speed;
                }
                if (inbound_projectileStats.Count > 0)
                {
                    each_ejector_average_damage /= inbound_projectileStats.Count;
                    //average_damage_per_sec = average_damage_per_sec; // / inbound_projectileStats.Count;
                }

                //total_max_damage = total_max_damage < each_ejector_max_damage ? each_ejector_max_damage : total_max_damage;
                total_max_damage += each_ejector_max_damage;
                total_average_damage += each_ejector_average_damage;
                total_min_damage = (total_min_damage == null || total_min_damage > each_ejector_min_damage) ? each_ejector_min_damage : total_min_damage;
                total_max_speed = total_max_speed < max_speed ? max_speed : total_max_speed;
                total_average_damage_per_sec += each_ejector_average_damage_per_sec;
                //total_projectile_num += projectile_num;
                total_magnification += each_ejector_magnification;

                //stringBuilder.AppendLine($"ejector {i} avg_damage/sec={each_ejector_average_damage_per_sec:#,0.00} max_damage={each_ejector_max_damage:#,0.00} min_damage={each_ejector_min_damage:#,0.00} max_speed={max_speed:#,0.00}");
                //i += 1;
            }
            //if(IEejector.Count<Thing>() > 0)total_average_damage /= IEejector.Count<Thing>(); //

            shipForm.WriteCalculateResult(total_average_damage_per_sec, total_min_damage, total_average_damage, total_max_damage, total_max_speed, shipParameter.fire_rate * total_magnification);

            //return stringBuilder.ToString();
        }

        private void DrawEjectorEffect(Thing[,] thing_layout, PictureBox[,] picturebox_layout)
        {
            var thing_1dim_layout = thing_layout.Cast<Thing>();
            var resource_manager_effect = Resource_Effects.ResourceManager;
            var resource_manager_shipparts = Resource_ShipParts.ResourceManager;
            IEnumerable<Thing> IEejector = thing_1dim_layout.Where(thing => thing.GetType() == typeof(Parts_02_Ejector));
            foreach (Parts_02_Ejector ejector in IEejector)
            {
                var loc = ejector.GetLocation();
                var pb = picturebox_layout[loc.X, loc.Y];
                if (ejector.Access_from_abs_top != null || ejector.Access_from_abs_right != null || ejector.Access_from_abs_down != null || ejector.Access_from_abs_left != null)
                {
                    var image = (Bitmap)resource_manager_effect.GetObject("Parts_02_Ejector_ejecting");
                    image.MakeTransparent(Color.White);
                    pb.BackgroundImage = image;

                }
                else
                {
                    var image = (Bitmap)resource_manager_shipparts.GetObject("Parts_02_Ejector");
                    image.MakeTransparent(Color.White);
                    pb.BackgroundImage = image;
                }
            }
        }
        private void DrawProjectileEffect(Thing[,] thing_layout, PictureBox[,] picturebox_layout)
        {
            var resource_manager = Resource_Effects.ResourceManager;

            for (var x = 0; x < thing_layout.GetLength(0); x++)
            {
                for (var y = 0; y < thing_layout.GetLength(1); y++)
                {
                    var pb = picturebox_layout[x, y];
                    pb.Name = null;
                    pb.Image = null;
                }
            }

            foreach (Thing[] things in List_separate_connect(thing_layout))
            {
                int x, y;
                int y_from, y_to;
                int x_from, x_to;
                PictureBox pb;
                Thing thing_from, thing_to;
                (thing_from, thing_to) = (things[0], things[1]);
                Location loc_from = thing_from.GetLocation();
                Location loc_to = thing_to.GetLocation();

                if (loc_from.X == loc_to.X)
                {
                    x = loc_from.X;
                    if (loc_from.Y > loc_to.Y)
                    {
                        y_from = loc_to.Y;
                        y_to = loc_from.Y;
                    }
                    else
                    {
                        y_from = loc_from.Y;
                        y_to = loc_to.Y;
                    }
                    for (y = y_from + 1; y < y_to; y++)
                    {
                        Bitmap image;
                        pb = picturebox_layout[x, y];
                        if (pb.Name == "HorizontalLine")
                        {
                            image = (Bitmap)resource_manager.GetObject("CrossLine");
                            pb.Name = "CrossLine";
                        }
                        else
                        {
                            image = (Bitmap)resource_manager.GetObject("VerticalLine");
                            pb.Name = "VerticalLine";
                        }
                        image.MakeTransparent(Color.White);
                        pb.Image = image;
                    }
                }
                if (loc_from.Y == loc_to.Y)
                {
                    y = loc_from.Y;
                    if (loc_from.X > loc_to.X)
                    {
                        x_from = loc_to.X;
                        x_to = loc_from.X;
                    }
                    else
                    {
                        x_from = loc_from.X;
                        x_to = loc_to.X;
                    }
                    for (x = x_from + 1; x < x_to; x++)
                    {
                        Bitmap image;
                        pb = picturebox_layout[x, y];
                        if (pb.Name == "VerticalLine")
                        {
                            image = (Bitmap)resource_manager.GetObject("CrossLine");
                            pb.Name = "CrossLine";
                        }
                        else
                        {
                            image = (Bitmap)resource_manager.GetObject("HorizontalLine");
                            pb.Name = "HorizontalLine";
                        }
                        image.MakeTransparent(Color.White);
                        pb.Image = image;
                    }
                }
            }
        }

        private IEnumerable<Thing[]> List_separate_connect(Thing[,] thing_layout)
        {
            for (var x = 0; x < thing_layout.GetLength(0); x++)
            {
                for (var y = 0; y < thing_layout.GetLength(1); y++)
                {
                    Thing thing = thing_layout[x, y];
                    if (thing.Access_to_abs_top != null && thing.IsSeparate(thing.Access_to_abs_top))
                    {
                        yield return new Thing[] { thing, thing.Access_to_abs_top };
                    }
                    if (thing.Access_to_abs_right != null && thing.IsSeparate(thing.Access_to_abs_right))
                    {
                        yield return new Thing[] { thing, thing.Access_to_abs_right };
                    }
                    if (thing.Access_to_abs_down != null && thing.IsSeparate(thing.Access_to_abs_down))
                    {
                        yield return new Thing[] { thing, thing.Access_to_abs_down };
                    }
                    if (thing.Access_to_abs_left != null && thing.IsSeparate(thing.Access_to_abs_left))
                    {
                        yield return new Thing[] { thing, thing.Access_to_abs_left };
                    }
                }
            }
        }

        private static Thing Get_access_right_thing(Thing[,] thing_layout, int from_x, int from_y)
        {
            if (from_x < thing_layout.GetLength(0) - 1)
            {
                if (thing_layout[from_x + 1, from_y].GetType() == typeof(Parts_Null))
                {
                    return Get_access_right_thing(thing_layout, from_x + 1, from_y);
                }
                else
                {
                    var obj = thing_layout[from_x + 1, from_y];
                    switch (obj.direction)
                    {
                        case Thing.Direction.TOP:
                            if (obj.IsAccessFromLEFT) return obj;
                            break;
                        case Thing.Direction.RIGHT:
                            if (obj.IsAccessFromDOWN) return obj;
                            break;
                        case Thing.Direction.DOWN:
                            if (obj.IsAccessFromRIGHT) return obj;
                            break;
                        case Thing.Direction.LEFT:
                            if (obj.IsAccessFromTOP) return obj;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        private static Thing Get_access_left_thing(Thing[,] thing_layout, int from_x, int from_y)
        {
            if (from_x > 0)
            {
                if (thing_layout[from_x - 1, from_y].GetType() == typeof(Parts_Null))
                {
                    return Get_access_left_thing(thing_layout, from_x - 1, from_y);
                }
                else
                {
                    var obj = thing_layout[from_x - 1, from_y];
                    switch (obj.direction)
                    {
                        case Thing.Direction.TOP:
                            if (obj.IsAccessFromRIGHT) return obj;
                            break;
                        case Thing.Direction.RIGHT:
                            if (obj.IsAccessFromTOP) return obj;
                            break;
                        case Thing.Direction.DOWN:
                            if (obj.IsAccessFromLEFT) return obj;
                            break;
                        case Thing.Direction.LEFT:
                            if (obj.IsAccessFromDOWN) return obj;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        private static Thing Get_access_top_thing(Thing[,] thing_layout, int from_x, int from_y)
        {
            if (from_y > 0)
            {
                if (thing_layout[from_x, from_y - 1].GetType() == typeof(Parts_Null))
                {
                    return Get_access_top_thing(thing_layout, from_x, from_y - 1);
                }
                else
                {
                    var obj = thing_layout[from_x, from_y - 1];
                    switch (obj.direction)
                    {
                        case Thing.Direction.TOP:
                            if (obj.IsAccessFromDOWN) return obj;
                            break;
                        case Thing.Direction.RIGHT:
                            if (obj.IsAccessFromRIGHT) return obj;
                            break;
                        case Thing.Direction.DOWN:
                            if (obj.IsAccessFromTOP) return obj;
                            break;
                        case Thing.Direction.LEFT:
                            if (obj.IsAccessFromLEFT) return obj;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        private static Thing Get_access_down_thing(Thing[,] thing_layout, int from_x, int from_y)
        {
            if (from_y < thing_layout.GetLength(1) - 1)
            {
                if (thing_layout[from_x, from_y + 1].GetType() == typeof(Parts_Null))
                {
                    return Get_access_down_thing(thing_layout, from_x, from_y + 1);
                }
                else
                {
                    var obj = thing_layout[from_x, from_y + 1];
                    switch (obj.direction)
                    {
                        case Thing.Direction.TOP:
                            if (obj.IsAccessFromTOP) return obj;
                            break;
                        case Thing.Direction.RIGHT:
                            if (obj.IsAccessFromLEFT) return obj;
                            break;
                        case Thing.Direction.DOWN:
                            if (obj.IsAccessFromDOWN) return obj;
                            break;
                        case Thing.Direction.LEFT:
                            if (obj.IsAccessFromRIGHT) return obj;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        private static void ResetBeforeCalculateDamage(Thing[,] thing_layout)
        {
            for (int x = 0; x < thing_layout.GetLength(0); x++)
            {
                for (int y = 0; y < thing_layout.GetLength(1); y++)
                {
                    var thing = thing_layout[x, y];
                    thing.ResetBeforeCalculateDamage();
                    thing.Access_to_abs_top = null;
                    thing.Access_to_abs_right = null;
                    thing.Access_to_abs_down = null;
                    thing.Access_to_abs_left = null;

                    thing.Access_from_abs_top = null;
                    thing.Access_from_abs_right = null;
                    thing.Access_from_abs_down = null;
                    thing.Access_from_abs_left = null;
                }
            }
        }
        private static void CreateProjectileFlow(Thing[,] thing_layout)
        {
            ResetBeforeCalculateDamage(thing_layout);

            // 1. Check the connection between thing and assign it to access_**** property.
            CreateProjectileFlow1(thing_layout);

            // 2. Modify damage crossing/money crossing connections
            CreateProjectileFlow2(thing_layout);

            // 3. Delete connections that are not connected to Projectile generator.
            CreateProjectileFlow3(thing_layout);

            // 4. Create backward projectile connection.
            CreateProjectileFlow4(thing_layout);
        }
        private static void CreateProjectileFlow2(Thing[,] thing_layout)
        {
            var thing_1dim_layout = thing_layout.Cast<Thing>();
            IEnumerable<Thing> IEcrossing = thing_1dim_layout.Where(thing => thing.IsCrossing == true);
            foreach (Thing crossing in IEcrossing)
            {
                if (crossing.Access_to_rel_top != null)
                {
                    var isfound = false;
                    for (var x = 0; x < thing_layout.GetLength(0); x++)
                    {
                        for (var y = 0; y < thing_layout.GetLength(0); y++)
                        {
                            var thing = thing_layout[x, y];
                            switch (crossing.direction)
                            {
                                case Thing.Direction.TOP:
                                    if (thing.Access_to_abs_top == crossing)
                                    {
                                        isfound = true;
                                        break;
                                    }
                                    break;
                                case Thing.Direction.RIGHT:
                                    if (thing.Access_to_abs_right == crossing)
                                    {
                                        isfound = true;
                                        break;
                                    }
                                    break;
                                case Thing.Direction.DOWN:
                                    if (thing.Access_to_abs_down == crossing)
                                    {
                                        isfound = true;
                                        break;
                                    }
                                    break;
                                case Thing.Direction.LEFT:
                                    if (thing.Access_to_abs_left == crossing)
                                    {
                                        isfound = true;
                                        break;
                                    }
                                    break;
                                default:
                                    throw new NotImplementedException();
                            }

                            /*
                            if(thing.Access_to_rel_top == crossing || thing.Access_to_rel_right == crossing || thing.Access_to_rel_down == crossing || thing.Access_to_rel_left == crossing){
                                isfound = true;
                                break;
                            }
                            */
                        }
                        if (isfound) break;
                    }
                    if (!isfound)
                    {
                        crossing.Access_to_rel_top = null;
                    }
                }
            }
        }

        private static void CreateProjectileFlow4(Thing[,] thing_layout)
        {
            for (var x = 0; x < thing_layout.GetLength(0); x++)
            {
                for (var y = 0; y < thing_layout.GetLength(1); y++)
                {
                    Thing thing = thing_layout[x, y];
                    if (thing.Access_to_abs_top != null) thing.Access_to_abs_top.Access_from_abs_down = thing;
                    if (thing.Access_to_abs_right != null) thing.Access_to_abs_right.Access_from_abs_left = thing;
                    if (thing.Access_to_abs_down != null) thing.Access_to_abs_down.Access_from_abs_top = thing;
                    if (thing.Access_to_abs_left != null) thing.Access_to_abs_left.Access_from_abs_right = thing;
                }
            }
        }

        private static void CreateProjectileFlow3(Thing[,] thing_layout)
        {
            //convert Thing[,] to List<Thing>
            List<Thing> inconnected_things = new(thing_layout.Cast<Thing>());

            //convert Thing[,] to IEnumerable<Thing> 
            var thing_1dim_layout = thing_layout.Cast<Thing>();
            Parts_03_ProjectileGenerator projectileGgenerator = (Parts_03_ProjectileGenerator)thing_1dim_layout.First<Thing>(thing => thing.GetType() == typeof(Parts_03_ProjectileGenerator));

            foreach (Thing thing in projectileGgenerator.ConnectedThings(true))
            {
                inconnected_things.Remove(thing);
            }
            foreach (Thing thing in inconnected_things)
            {
                thing.Access_to_abs_top = null;
                thing.Access_to_abs_right = null;
                thing.Access_to_abs_down = null;
                thing.Access_to_abs_left = null;
            }
        }

        private static void CreateProjectileFlow1(Thing[,] thing_layout)
        {
            for (int x = 0; x < thing_layout.GetLength(0); x++)
            {
                for (int y = 0; y < thing_layout.GetLength(1); y++)
                {
                    var thing = thing_layout[x, y];
                    /*
                    thing.Access_to_abs_top = null;
                    thing.Access_to_abs_right = null;
                    thing.Access_to_abs_down = null;
                    thing.Access_to_abs_left = null;

                    thing.Access_from_abs_top = null;
                    thing.Access_from_abs_right = null;
                    thing.Access_from_abs_down = null;
                    thing.Access_from_abs_left = null;
                    */

                    if (thing.IsAccessToTOP)
                    {
                        switch (thing.direction)
                        {
                            case Thing.Direction.TOP:
                                thing.Access_to_abs_top = Get_access_top_thing(thing_layout, x, y);
                                break;
                            case Thing.Direction.RIGHT:
                                thing.Access_to_abs_right = Get_access_right_thing(thing_layout, x, y);
                                break;
                            case Thing.Direction.DOWN:
                                thing.Access_to_abs_down = Get_access_down_thing(thing_layout, x, y);
                                break;
                            case Thing.Direction.LEFT:
                                thing.Access_to_abs_left = Get_access_left_thing(thing_layout, x, y);
                                break;
                        }
                    }
                    if (thing.IsAccessToRIGHT)
                    {
                        switch (thing.direction)
                        {
                            case Thing.Direction.TOP:
                                thing.Access_to_abs_right = Get_access_right_thing(thing_layout, x, y);
                                break;
                            case Thing.Direction.RIGHT:
                                thing.Access_to_abs_down = Get_access_down_thing(thing_layout, x, y);
                                break;
                            case Thing.Direction.DOWN:
                                thing.Access_to_abs_left = Get_access_left_thing(thing_layout, x, y);
                                break;
                            case Thing.Direction.LEFT:
                                thing.Access_to_abs_top = Get_access_top_thing(thing_layout, x, y);
                                break;
                        }
                    }
                    if (thing.IsAccessToDOWN)
                    {
                        switch (thing.direction)
                        {
                            case Thing.Direction.TOP:
                                thing.Access_to_abs_down = Get_access_down_thing(thing_layout, x, y);
                                break;
                            case Thing.Direction.RIGHT:
                                thing.Access_to_abs_left = Get_access_left_thing(thing_layout, x, y);
                                break;
                            case Thing.Direction.DOWN:
                                thing.Access_to_abs_top = Get_access_top_thing(thing_layout, x, y);
                                break;
                            case Thing.Direction.LEFT:
                                thing.Access_to_abs_right = Get_access_right_thing(thing_layout, x, y);
                                break;
                        }
                    }
                    if (thing.IsAccessToLEFT)
                    {
                        switch (thing.direction)
                        {
                            case Thing.Direction.TOP:
                                thing.Access_to_abs_left = Get_access_left_thing(thing_layout, x, y);
                                break;
                            case Thing.Direction.RIGHT:
                                thing.Access_to_abs_top = Get_access_top_thing(thing_layout, x, y);
                                break;
                            case Thing.Direction.DOWN:
                                thing.Access_to_abs_right = Get_access_right_thing(thing_layout, x, y);
                                break;
                            case Thing.Direction.LEFT:
                                thing.Access_to_abs_down = Get_access_down_thing(thing_layout, x, y);
                                break;
                        }
                    }
                }
            }
        }
        /*
        private Point Find_projectile_generator_position(Thing[,] thing_layout)
        {
            for (var x = 0; x < thing_layout.GetLength(0); x++)
            {
                for (var y = 0; y < thing_layout.GetLength(1); y++)
                {
                    if (thing_layout[x, y].GetType() == typeof(Parts_03_ProjectileGenerator))
                    {
                        return new Point(x, y);
                    }
                }
            }
            throw new Exception();
        }
        */

        public void MakeGraphs(ParentForm parentForm)
        {
            const int fire_time_sec = 100;
            CreateProjectileFlow(thing_layout);
            DrawProjectileEffect(thing_layout, picturebox_layout);
            DrawEjectorEffect(thing_layout, picturebox_layout);
            List<SimulationResult> results = DamageSimulate(thing_layout, shipParameter, fire_time_sec);
            if (results.Count > 0)
            {
                MakeGraphsMain(results, parentForm,fire_time_sec);
            }
        }

        private void MakeGraphsMain(List<SimulationResult> results, ParentForm parentForm,int fire_time_sec)
        {
            if(formGraph == null || formGraph.IsDisposed == true)
            {
                formGraph = new Form_Graph
                {
                    MdiParent = parentForm
                };
                formGraph.Show();
            }
            formGraph.ClearGraphs();
            foreach(SimulationResult each_result in results)
            {
                formGraph.AddHistogram(each_result.ejector_name, each_result.damages,fire_time_sec,each_result.stats);
            }

        }
        private List<decimal> GetEjectorDamages(Parts_02_Ejector ejector, ShipParameter shipParameter, int fire_time_sec)
        {
            int fireCount = decimal.ToInt32(shipParameter.fire_rate * fire_time_sec);
            List<decimal> ejector_damages = new();
            Projectile projectile;
            if (ejector.Access_from_abs_top != null)
            {
                projectile = ejector.Access_from_abs_top.GetOutboundProjectile(shipParameter, profile, ejector);
                for (int j = 0; j < projectile.magnification * fireCount; j++)
                {
                    projectile = ejector.Access_from_abs_top.GetOutboundProjectile(shipParameter, profile, ejector);
                    ejector_damages.Add(projectile.damage);
                }
            }
            if (ejector.Access_from_abs_right != null)
            {
                projectile = ejector.Access_from_abs_right.GetOutboundProjectile(shipParameter, profile, ejector);
                for (int j = 0; j < projectile.magnification * fireCount; j++)
                {
                    projectile = ejector.Access_from_abs_right.GetOutboundProjectile(shipParameter, profile, ejector);
                    ejector_damages.Add(projectile.damage);
                }
            }
            if (ejector.Access_from_abs_down != null)
            {
                projectile = ejector.Access_from_abs_down.GetOutboundProjectile(shipParameter, profile, ejector);
                for (int j = 0; j < projectile.magnification * fireCount; j++)
                {
                    projectile = ejector.Access_from_abs_down.GetOutboundProjectile(shipParameter, profile, ejector);
                    ejector_damages.Add(projectile.damage);
                }
            }
            if (ejector.Access_from_abs_left != null)
            {
                projectile = ejector.Access_from_abs_left.GetOutboundProjectile(shipParameter, profile, ejector);
                for (int j = 0; j < projectile.magnification * fireCount; j++)
                {
                    projectile = ejector.Access_from_abs_left.GetOutboundProjectile(shipParameter, profile, ejector);
                    ejector_damages.Add(projectile.damage);
                }
            }
            return ejector_damages;
        }
        /*
        private List<SimulationResult> DamageSimulate(Thing[,] thing_layout, ShipParameter shipParameter,int fire_time_sec)
        {
            var results = new List<SimulationResult>();
            var thing_1dim_layout = thing_layout.Cast<Thing>();
            IEnumerable<Thing> IEejector = thing_1dim_layout.Where(thing => thing.GetType() == typeof(Parts_02_Ejector));
            int ejector_number = 1;
            List<decimal> all_ejector_damages = new();
            SimulationResult ejector_result;
            Statistics.Stats stats;
            foreach (Parts_02_Ejector ejector in IEejector)
            {
                const int loop_number_for_accuracy = 10;
                List<List<decimal>> loop_ejector_damages = new();
                for(int i = 0;i < loop_number_for_accuracy; i++)
                {
                    loop_ejector_damages.Add(GetEjectorDamages(ejector, shipParameter, fire_time_sec));
                }
                List<decimal> ejector_damages = new();

                for (int j = 0; j < loop_ejector_damages[0].Count; j++)
                {
                    decimal damage = 0;
                    for (int i = 0; i < loop_number_for_accuracy; i++)
                    {
                        damage += loop_ejector_damages[i][j];
                    }
                    ejector_damages.Add(damage / loop_number_for_accuracy);
                }

                if (ejector_damages.Count > 0)
                {
                    stats = Statistics.Calculate(ejector_damages,fire_time_sec);
                    ejector_result = new SimulationResult
                    {
                        ejector_name = ejector_number.ToString(),
                        damages = ejector_damages,
                        stats = stats
                    };
                    results.Add(ejector_result);
                    ejector_number += 1;

                    all_ejector_damages.AddRange(ejector_damages);
                }
            }
            if (results.Count > 1)
            {
                stats = Statistics.Calculate(all_ejector_damages,fire_time_sec);
                ejector_result = new SimulationResult
                {
                    ejector_name = "Total",
                    damages = all_ejector_damages,
                    stats = stats
                };
                results.Insert(0, ejector_result);
            }
            return results;
        }
        */
        private List<SimulationResult> DamageSimulate(Thing[,] thing_layout, ShipParameter shipParameter,int fire_time_sec)
        {
            var results = new List<SimulationResult>();
            var thing_1dim_layout = thing_layout.Cast<Thing>();
            IEnumerable<Thing> IEejector = thing_1dim_layout.Where(thing => thing.GetType() == typeof(Parts_02_Ejector));
            int ejector_number = 1;
            List<decimal> all_ejector_damages = new();
            SimulationResult ejector_result;
            Statistics.Stats stats;
            foreach (Parts_02_Ejector ejector in IEejector)
            {
                List<decimal> ejector_damages = GetEjectorDamages(ejector, shipParameter, fire_time_sec);

                if (ejector_damages.Count > 0)
                {
                    stats = Statistics.Calculate(ejector_damages,fire_time_sec);
                    ejector_result = new SimulationResult
                    {
                        ejector_name = ejector_number.ToString(),
                        damages = ejector_damages,
                        stats = stats
                    };
                    results.Add(ejector_result);
                    ejector_number += 1;

                    all_ejector_damages.AddRange(ejector_damages);
                }
            }
            if (results.Count > 1)
            {
                stats = Statistics.Calculate(all_ejector_damages,fire_time_sec);
                ejector_result = new SimulationResult
                {
                    ejector_name = "Total",
                    damages = all_ejector_damages,
                    stats = stats
                };
                results.Insert(0, ejector_result);
            }
            return results;
        }
    }
}
