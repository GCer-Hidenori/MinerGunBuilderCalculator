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
        private Form_Ship form_ship;
        private Profile profile;
        private PictureBox[,] picturebox_layout;
        private Thing[,] thing_layout;
        private ShipParameter shipParameter;
        public FireController(Form_Ship form_ship)
        {
            this.form_ship = form_ship;
        }
        public void ShipLayoutChanged(Thing[,] thing_layout, ShipParameter shipParameter, Profile profile, PictureBox[,] picturebox_layout)
        {
            this.thing_layout = thing_layout;
            this.profile = profile;
            this.picturebox_layout = picturebox_layout;
            this.shipParameter = shipParameter;
            CreateProjectileFlow(thing_layout);
            DrawProjectileEffect(thing_layout, picturebox_layout);
            DrawEjectorEffect(thing_layout, picturebox_layout);
            CalculateDamage(thing_layout, shipParameter, profile);
        }

        private void CalculateDamage(Thing[,] thing_layout, ShipParameter shipParameter, Profile profile)
        {
            decimal? total_min_damage = null;
            decimal total_average_damage_per_sec = 0;
            decimal total_average_damage = 0;
            decimal total_max_damage = 0;

            decimal? total_min_effective_damage = null;
            decimal total_average_effective_damage_per_sec = 0;
            decimal total_average_effective_damage = 0;
            decimal total_max_effective_damage = 0;

            decimal total_max_speed = 0;
            decimal total_magnification = 0;
            decimal total_average_lifetime = 0;

            var thing_1dim_layout = thing_layout.Cast<Thing>();
            IEnumerable<Thing> IEejector = thing_1dim_layout.Where(thing => thing.GetType() == typeof(Parts_02_Ejector)).Where(thing => thing.IsEjecting == true);
            foreach (Parts_02_Ejector ejector in IEejector)
            {
                List<ProjectileStat> inbound_projectileStats = ejector.GetOutboundProjectileStatList(shipParameter,profile);

                decimal? each_ejector_min_damage = null;
                decimal each_ejector_average_damage = 0;
                decimal each_ejector_max_damage = 0;
                decimal each_ejector_average_damage_per_sec = 0;

                decimal? each_ejector_min_effective_damage = null;
                decimal each_ejector_average_effective_damage = 0;
                decimal each_ejector_max_effective_damage = 0;
                decimal each_ejector_average_effective_damage_per_sec = 0;

                decimal each_ejector_average_lifetime = 0;
                decimal each_ejector_magnification = 0;

                decimal max_speed = 0;

                int ejected_count = 0;

                foreach (var projectileStats in inbound_projectileStats)
                {
                    ejected_count += 1;
                    each_ejector_magnification += projectileStats.magnification;
                    each_ejector_min_damage = (each_ejector_min_damage == null || each_ejector_min_damage > projectileStats.min_damage) ? projectileStats.min_damage : each_ejector_min_damage;

                    each_ejector_max_damage = each_ejector_max_damage < projectileStats.max_damage ? projectileStats.max_damage : each_ejector_max_damage;
                    each_ejector_average_damage += projectileStats.average_damage;
                    each_ejector_average_damage_per_sec += projectileStats.average_damage * projectileStats.magnification * shipParameter.fire_rate;
                    each_ejector_average_lifetime += projectileStats.lifetime;


                    each_ejector_min_effective_damage = (each_ejector_min_effective_damage == null || each_ejector_min_effective_damage > projectileStats.Calc_min_effective_damage()) ? projectileStats.Calc_min_effective_damage() : each_ejector_min_effective_damage;
                    each_ejector_max_effective_damage = each_ejector_max_effective_damage < projectileStats.Calc_max_effective_damage() ? projectileStats.Calc_max_effective_damage() : each_ejector_max_effective_damage;
                    each_ejector_average_effective_damage += projectileStats.Calc_average_effective_damage();
                    each_ejector_average_effective_damage_per_sec += projectileStats.Calc_average_effective_damage() * projectileStats.magnification * shipParameter.fire_rate;
                    max_speed = max_speed < projectileStats.speed ? projectileStats.speed : max_speed;
                }
                if (ejected_count > 0)
                {
                    each_ejector_average_damage /= ejected_count;
                    each_ejector_average_lifetime /= ejected_count;

                    each_ejector_average_effective_damage /= ejected_count;
                }

                total_max_damage = total_max_damage < each_ejector_max_damage ? each_ejector_max_damage : total_max_damage;
                total_average_damage += each_ejector_average_damage;
                total_min_damage = (total_min_damage == null || total_min_damage > each_ejector_min_damage) ? each_ejector_min_damage : total_min_damage;
                total_max_speed = total_max_speed < max_speed ? max_speed : total_max_speed;
                total_average_damage_per_sec += each_ejector_average_damage_per_sec;

                total_max_effective_damage = total_max_effective_damage < each_ejector_max_effective_damage ? each_ejector_max_effective_damage : total_max_effective_damage;
                total_average_effective_damage += each_ejector_average_effective_damage;
                total_min_effective_damage = (total_min_effective_damage == null || total_min_effective_damage > each_ejector_min_effective_damage) ? each_ejector_min_effective_damage : total_min_effective_damage;
                total_max_speed = total_max_speed < max_speed ? max_speed : total_max_speed;
                total_average_effective_damage_per_sec += each_ejector_average_effective_damage_per_sec;


                total_average_lifetime += each_ejector_average_lifetime;
                total_magnification += each_ejector_magnification;

            }
            if (IEejector.Count<Thing>() > 0)
            {
                total_average_damage /= IEejector.Count<Thing>();
                total_average_effective_damage /= IEejector.Count<Thing>();
                total_average_lifetime /= IEejector.Count<Thing>();
            }

            form_ship.WriteCalculateResult(average_damage_per_sec: total_average_damage_per_sec,min_damage: total_min_damage,average_damage: total_average_damage, max_damage: total_max_damage,projectile_speed: total_max_speed,projectile_eject_per_sec: shipParameter.fire_rate * total_magnification,projectile_lifetime: total_average_lifetime);
            form_ship.WriteCalculateResult_EffectiveDamage(average_effective_damage_per_sec: total_average_effective_damage_per_sec,min_effective_damage: total_min_effective_damage,average_effective_damage: total_average_effective_damage, max_effective_damage: total_max_effective_damage);

        }

        private static void DrawEjectorEffect(Thing[,] thing_layout, PictureBox[,] picturebox_layout)
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
                    ejector.IsEjecting = true;

                }
                else
                {
                    var image = (Bitmap)resource_manager_shipparts.GetObject("Parts_02_Ejector");
                    image.MakeTransparent(Color.White);
                    pb.BackgroundImage = image;
                    ejector.IsEjecting = false;
                }
            }
        }
        private static void DrawProjectileEffect(Thing[,] thing_layout, PictureBox[,] picturebox_layout)
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

        private static IEnumerable<Thing[]> List_separate_connect(Thing[,] thing_layout)
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

            // 1. Check the connection between thing and assign it to access_to_**** property.
            CreateProjectileFlow1(thing_layout);

            // 3. Delete connections that are not connected to Projectile generator.
            CreateProjectileFlow3(thing_layout);

            // 2. Modify damage crossing/money crossing connections
            CreateProjectileFlow2(thing_layout);


            // 4. Create backward projectile connection.
            CreateProjectileFlow4(thing_layout);
        }

    /*
        private static void CreateProjectileFlow2(Thing[,] thing_layout)
        {
            var thing_1dim_layout = thing_layout.Cast<Thing>();
            IEnumerable<Thing> IEcrossing = thing_1dim_layout.Where(thing => thing.IsCrossing == true);
            foreach (Thing crossing in IEcrossing)
            {
                if (crossing.Access_to_abs_top != null)
                {
                    if (!crossing.CanReachFromProjectileGenerator(thing_layout, from_direction: Thing.Direction.DOWN))
                    {
                        crossing.Access_to_rel_top = null;
                    }
                }
                else if (crossing.Access_to_abs_right != null)
                {
                    if (!crossing.CanReachFromProjectileGenerator(thing_layout, from_direction: Thing.Direction.LEFT))
                    {
                        crossing.Access_to_abs_right = null;
                    }
                }
                else if (crossing.Access_to_abs_down != null)
                {
                    if (!crossing.CanReachFromProjectileGenerator(thing_layout, from_direction: Thing.Direction.TOP))
                    {
                        crossing.Access_to_abs_down = null;
                    }
                }
                else if (crossing.Access_to_abs_left != null)
                {
                    if (!crossing.CanReachFromProjectileGenerator(thing_layout, from_direction: Thing.Direction.RIGHT))
                    {
                        crossing.Access_to_abs_left = null;
                    }
                }

            }
        }
        */

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
                            switch (thing)
                            {
                                case Parts_01_Wall:
                                case Parts_Null:
                                    break;
                                default:
                                    if (crossing == thing) continue;
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
                                    break;
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

        public void MakeGraphs(Form_Parent form_parent,HashSet<string> SkillList)
        {
            const int fire_time_sec = 100;
            CreateProjectileFlow(thing_layout);
            DrawProjectileEffect(thing_layout, picturebox_layout);
            DrawEjectorEffect(thing_layout, picturebox_layout);
            List<SimulationResult> results = DamageSimulate(thing_layout, shipParameter,SkillList, fire_time_sec);
            if (results.Count > 0)
            {
                MakeGraphsMain(results, form_parent,fire_time_sec);
            }
        }

        private void MakeGraphsMain(List<SimulationResult> results, Form_Parent form_parent,int fire_time_sec)
        {
            if(formGraph == null || formGraph.IsDisposed == true)
            {
                formGraph = new Form_Graph
                {
                    MdiParent = form_parent
                };
                formGraph.Show();
            }
            formGraph.ClearGraphs();
            foreach(SimulationResult each_result in results)
            {
                formGraph.AddHistogram(each_result.ejector_name, each_result.projectile_damages,each_result.projectile_effective_damges,fire_time_sec,each_result.stats_projectile_damage,each_result.stats_projectile_effective_damage);
            }

        }
        private List<Projectile> GetProjectileListOfPassEjector (Parts_02_Ejector ejector, ShipParameter shipParameter, HashSet<string> skillList, int fire_time_sec)
        {
            int fireCount = decimal.ToInt32(shipParameter.fire_rate * fire_time_sec);
            List<Projectile> projectileListOfPassEjector = new();
            List<Projectile> projectileList;
            for (int k = 0; k < fireCount; k++)
            {
                projectileList = ejector.GetOutboundProjectileList(shipParameter,profile);
                foreach(Projectile projectile in projectileList)
                {
                    if(projectile != null)
                    {
                        for (int j = 0; j < projectile.magnification; j++)
                        {
                            projectileListOfPassEjector.Add(projectile);
                        }
                    }
                }
            }
            return projectileListOfPassEjector;
        }
        /*
        private List<decimal> GetEjectorDamages(Parts_02_Ejector ejector, ShipParameter shipParameter, HashSet<string> skillList, int fire_time_sec,out decimal eject_count)
        {
            int fireCount = decimal.ToInt32(shipParameter.fire_rate * fire_time_sec);
            eject_count = 0;
            List<decimal> ejector_damages = new();
            List<Projectile> projectileList;
            for (int k = 0; k < fireCount; k++)
            {
                projectileList = ejector.GetOutboundProjectileList(shipParameter,profile);
                foreach(Projectile projectile in projectileList)
                {
                    if(projectile != null)
                    {
                        for (int j = 0; j < projectile.magnification; j++)
                        {
                            eject_count += 1;
                            for (int pierce = 0; pierce < projectile.pierce_count + 1; pierce++)
                            {
                                ejector_damages.Add(projectile.damage);
                            }
                        }
                    }
                }
            }
            return ejector_damages;
        }
        */
        private (List<decimal> projectile_damages, List<decimal> projectile_effective_damges) GetProjectilesDamages(List<Projectile> list_projectile)
        {
            List<decimal> projectile_damages = new();            //Not take into account pierce,area damage
            List<decimal> projectile_effective_damges = new();   //Take into account pierce,area damage
            foreach(Projectile projectile in list_projectile)
            {
                projectile_damages.Add(projectile.damage);
                projectile_effective_damges.Add(projectile.Calc_effective_damage());
            }
            return (projectile_damages,projectile_effective_damges);
        }
        private List<SimulationResult> DamageSimulate(Thing[,] thing_layout, ShipParameter shipParameter, HashSet<string> skillList, int fire_time_sec)
        {
            var results = new List<SimulationResult>();
            var thing_1dim_layout = thing_layout.Cast<Thing>();
            IEnumerable<Thing> IEejector = thing_1dim_layout.Where(thing => thing.GetType() == typeof(Parts_02_Ejector)).Where(thing => thing.IsEjecting == true);
            int ejector_number = 1;
            List<decimal> all_ejector_damages = new();
            List<decimal> all_ejector_effective_damages = new();
            SimulationResult ejector_result;
            Statistics.Stats stats_projectile_damage;
            Statistics.Stats stats_projectile_effective_damage;

            foreach (Parts_02_Ejector ejector in IEejector)
            {
                List<Projectile> projectile_list = GetProjectileListOfPassEjector(ejector, shipParameter, skillList, fire_time_sec);
                var ejector_damages = GetProjectilesDamages(projectile_list);

                stats_projectile_damage = Statistics.Calculate(ejector_damages.projectile_damages,fire_time_sec);
                stats_projectile_effective_damage = Statistics.Calculate(ejector_damages.projectile_effective_damges,fire_time_sec);

                int eject_count = ejector_damages.projectile_damages.Count;

                ejector_result = new SimulationResult
                {
                    ejector_name = ejector_number.ToString(),
                    projectile_damages = ejector_damages.projectile_damages,
                    projectile_effective_damges = ejector_damages.projectile_effective_damges,
                    stats_projectile_damage = stats_projectile_damage,
                    stats_projectile_effective_damage = stats_projectile_effective_damage,
                    ejected_count = eject_count,
                    ejected_count_per_sec = new decimal(eject_count) / fire_time_sec
                };
                results.Add(ejector_result);
                ejector_number += 1;
                all_ejector_damages.AddRange(ejector_damages.projectile_damages);
                all_ejector_effective_damages.AddRange(ejector_damages.projectile_effective_damges);
            }
            if (results.Count > 1)
            {
                stats_projectile_damage = Statistics.Calculate(all_ejector_damages, fire_time_sec);
                stats_projectile_effective_damage = Statistics.Calculate(all_ejector_effective_damages, fire_time_sec);
                int eject_count = all_ejector_damages.Count;
                ejector_result = new SimulationResult
                {
                    ejector_name = "Total",
                    projectile_damages = all_ejector_damages,
                    projectile_effective_damges = all_ejector_effective_damages,
                    stats_projectile_damage = stats_projectile_damage,
                    stats_projectile_effective_damage = stats_projectile_effective_damage,
                    ejected_count = eject_count,
                    ejected_count_per_sec = new decimal(eject_count) / fire_time_sec
                };
                results.Insert(0, ejector_result);
            }
            return results;


        }

        //ŒÃ‚¢
        /*
        private List<SimulationResult> DamageSimulate_old(Thing[,] thing_layout, ShipParameter shipParameter,HashSet<string> skillList,int fire_time_sec)
        {
            var results = new List<SimulationResult>();
            var thing_1dim_layout = thing_layout.Cast<Thing>();
            IEnumerable<Thing> IEejector = thing_1dim_layout.Where(thing => thing.GetType() == typeof(Parts_02_Ejector)).Where(thing => thing.IsEjecting == true);
            int ejector_number = 1;
            List<decimal> all_ejector_damages = new();
            SimulationResult ejector_result;
            Statistics.Stats stats;

            decimal eject_count = 0;
            foreach (Parts_02_Ejector ejector in IEejector)
            {
                List<decimal> ejector_damages = GetEjectorDamages(ejector, shipParameter, skillList,fire_time_sec,out eject_count);

                if (ejector_damages.Count > 0)
                {
                    stats = Statistics.Calculate(ejector_damages,fire_time_sec,eject_count);
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
                stats = Statistics.Calculate(all_ejector_damages,fire_time_sec, eject_count);
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
    }
}
