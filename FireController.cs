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

            decimal total_average_round_area_count = 0;
            decimal total_average_rectangle_area_count = 0;
            decimal total_average_pierce_count = 0;

            var thing_1dim_layout = thing_layout.Cast<Thing>();
            IEnumerable<Thing> IEejector = thing_1dim_layout.Where(thing => thing.GetType() == typeof(Parts_02_Ejector)).Where(thing => thing.IsEjecting == true);
            foreach (Parts_02_Ejector ejector in IEejector)
            {
                List<ProjectileStat> inbound_projectileStats = ejector.GetOutboundProjectileStatList(shipParameter, profile);

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

                decimal each_average_round_area_count = 0;
                decimal each_average_rectangle_area_count = 0;
                decimal each_average_pierce_count = 0;

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


                    each_ejector_min_effective_damage = (each_ejector_min_effective_damage == null || each_ejector_min_effective_damage > projectileStats.Calc_min_effective_damage(profile.skillList)) ? projectileStats.Calc_min_effective_damage(profile.skillList) : each_ejector_min_effective_damage;
                    each_ejector_max_effective_damage = each_ejector_max_effective_damage < projectileStats.Calc_max_effective_damage(profile.skillList) ? projectileStats.Calc_max_effective_damage(profile.skillList) : each_ejector_max_effective_damage;
                    each_ejector_average_effective_damage += projectileStats.Calc_average_effective_damage(profile.skillList);
                    each_ejector_average_effective_damage_per_sec += projectileStats.Calc_average_effective_damage(profile.skillList) * projectileStats.magnification * shipParameter.fire_rate;

                    each_average_round_area_count += projectileStats.round_area_count;
                    each_average_rectangle_area_count += projectileStats.rectangle_area_count;
                    each_average_pierce_count += projectileStats.pierce_count;

                    max_speed = max_speed < projectileStats.speed ? projectileStats.speed : max_speed;
                }
                if (ejected_count > 0)
                {
                    each_ejector_average_damage /= ejected_count;
                    each_ejector_average_lifetime /= ejected_count;
                    each_ejector_average_effective_damage /= ejected_count;
                    each_average_round_area_count /= ejected_count;
                    each_average_rectangle_area_count /= ejected_count;
                    each_average_pierce_count /= ejected_count;
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

                total_average_round_area_count += each_average_round_area_count;
                total_average_rectangle_area_count += each_average_rectangle_area_count;
                total_average_pierce_count += each_average_pierce_count;

            }
            if (IEejector.Count<Thing>() > 0)
            {
                total_average_damage /= IEejector.Count<Thing>();
                total_average_damage_per_sec /= IEejector.Count<Thing>();
                total_average_effective_damage /= IEejector.Count<Thing>();
                total_average_effective_damage_per_sec /= IEejector.Count<Thing>();
                total_average_lifetime /= IEejector.Count<Thing>();
                total_average_round_area_count /= IEejector.Count<Thing>();
                total_average_rectangle_area_count /= IEejector.Count<Thing>();
                total_average_pierce_count /= IEejector.Count<Thing>();
            }

            form_ship.WriteCalculateResult(average_damage_per_sec: total_average_damage_per_sec, min_damage: total_min_damage, average_damage: total_average_damage, max_damage: total_max_damage, projectile_speed: total_max_speed, projectile_eject_per_sec: shipParameter.fire_rate * total_magnification, projectile_lifetime: total_average_lifetime);
            form_ship.WriteCalculateResult_EffectiveDamage(average_effective_damage_per_sec: total_average_effective_damage_per_sec, min_effective_damage: total_min_effective_damage, average_effective_damage: total_average_effective_damage, max_effective_damage: total_max_effective_damage);
            form_ship.WriteCalculateResult_area_pierce(total_average_round_area_count,total_average_rectangle_area_count,total_average_pierce_count);

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
            CreateProjectileFlow_Main(thing_layout);
        }

        private static void CreateProjectileFlow_Main(Thing[,] thing_layout)
        {
            //convert Thing[,] to IEnumerable<Thing> 
            var thing_1dim_layout = thing_layout.Cast<Thing>();
            Parts_03_ProjectileGenerator projectileGgenerator = (Parts_03_ProjectileGenerator)thing_1dim_layout.First<Thing>(thing => thing.GetType() == typeof(Parts_03_ProjectileGenerator));

            projectileGgenerator.CreateProjectileFlow(thing_layout);
        }


        public void MakeGraphs(Form_Parent form_parent, HashSet<string> SkillList)
        {
            const int fire_time_sec = 100;
            CreateProjectileFlow(thing_layout);
            DrawProjectileEffect(thing_layout, picturebox_layout);
            DrawEjectorEffect(thing_layout, picturebox_layout);
            List<SimulationResult> results = DamageSimulate(thing_layout, shipParameter, SkillList, fire_time_sec);
            if (results.Count > 0)
            {
                MakeGraphsMain(results, form_parent, fire_time_sec);
            }
        }

        private void MakeGraphsMain(List<SimulationResult> results, Form_Parent form_parent, int fire_time_sec)
        {
            if (formGraph == null || formGraph.IsDisposed == true)
            {
                formGraph = new Form_Graph
                {
                    MdiParent = form_parent
                };
                formGraph.Show();
            }
            formGraph.ClearGraphs();
            foreach (SimulationResult each_result in results)
            {
                formGraph.AddHistogram(each_result.ejector_name, each_result.projectile_damages, each_result.projectile_effective_damges, fire_time_sec, each_result.stats_projectile_damage, each_result.stats_projectile_effective_damage);
            }
            formGraph.Focus();

        }
        private List<Projectile> GetProjectileListOfPassEjector(Parts_02_Ejector ejector, ShipParameter shipParameter, HashSet<string> skillList, int fire_time_sec)
        {
            int fireCount = decimal.ToInt32(shipParameter.fire_rate * fire_time_sec);
            List<Projectile> projectileListOfPassEjector = new();
            List<Projectile> projectileList;
            for (int k = 0; k < fireCount; k++)
            {
                projectileList = ejector.GetOutboundProjectileList(shipParameter, profile);
                foreach (Projectile projectile in projectileList)
                {
                    if (projectile != null)
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
        private (List<decimal> projectile_damages, List<decimal> projectile_effective_damges) GetProjectilesDamages(List<Projectile> list_projectile)
        {
            List<decimal> projectile_damages = new();            //Not take into account pierce,area damage
            List<decimal> projectile_effective_damges = new();   //Take into account pierce,area damage
            foreach (Projectile projectile in list_projectile)
            {
                projectile_damages.Add(projectile.damage);
                projectile_effective_damges.Add(projectile.Calc_effective_damage(profile.skillList));
            }
            return (projectile_damages, projectile_effective_damges);
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

                stats_projectile_damage = Statistics.Calculate(ejector_damages.projectile_damages, fire_time_sec);
                stats_projectile_effective_damage = Statistics.Calculate(ejector_damages.projectile_effective_damges, fire_time_sec);

                decimal round_area_count = 0m;
                decimal rectangle_area_count = 0m;
                decimal pierce_count = 0m;
                decimal round_area= 0m;
                decimal rectangle_area= 0m;
                foreach(Projectile projectile in projectile_list)
                {
                    round_area_count += projectile.round_area_count;
                    rectangle_area_count += projectile.rectangle_area_count;
                    pierce_count += projectile.pierce_count;
                    round_area += Statistics.Calc_round_area(projectile.round_area_count,skillList);
                    rectangle_area += Statistics.Calc_rectangle_area(projectile.rectangle_area_count,skillList);
                }
                stats_projectile_effective_damage.round_area_count = round_area_count / projectile_list.Count;
                stats_projectile_effective_damage.rectangle_area_count = rectangle_area_count / projectile_list.Count;
                stats_projectile_effective_damage.pierce_count = pierce_count / projectile_list.Count;
                stats_projectile_effective_damage.round_area = round_area / projectile_list.Count;
                stats_projectile_effective_damage.rectangle_area = rectangle_area / projectile_list.Count;

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

    }
}
