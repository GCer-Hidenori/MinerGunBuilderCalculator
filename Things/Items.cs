using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    class Item_01_Guide_right : Item
    {
        public Item_01_Guide_right(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToRIGHT = true;
        }
        public override List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {
            List<Projectile> inbound_projectiles = new();
            if(Access_from_rel_down != null)
            {
                inbound_projectiles.AddRange(Access_from_rel_down.GetOutboundProjectile(shipParameter,this));
            }
            return inbound_projectiles;
        }
    }
    class Item_02_Guide_left : Item
    {
        public Item_02_Guide_left(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToLEFT = true;
        }
    }
    class Item_03_Add_1_damage : Item
    {
        public Item_03_Add_1_damage(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {
            List<Projectile> inbound_projectiles = new();

            if (Access_from_rel_down != null)
            {
                inbound_projectiles.AddRange(Access_from_rel_down.GetOutboundProjectile(shipParameter,this));
                foreach(var projectile in inbound_projectiles)
                {
                    projectile.average_damage += 1;
                    projectile.max_damage += 1;
                    projectile.min_damage += 1;
                }
            }
            return inbound_projectiles;
        }
    }
    class Item_04_Speed_up : Item
    {
        public Item_04_Speed_up(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {
            List<Projectile> inbound_projectiles = new();

            if (Access_from_rel_down != null)
            {
                inbound_projectiles.AddRange(Access_from_rel_down.GetOutboundProjectile(shipParameter,this));
                foreach (var projectile in inbound_projectiles)
                {
                    projectile.speed += 1;
                }
            }
            return inbound_projectiles;
        }
    }
    class Item_05_Spread_left : Item
    {
        public Item_05_Spread_left(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_06_Large_spread : Item
    {
        public Item_06_Large_spread(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_07_Spread_right : Item
    {
        public Item_07_Spread_right(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_08_Small_spread : Item
    {
        public Item_08_Small_spread(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_09_Curve_left : Item
    {
        public Item_09_Curve_left(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_10_Random_curve : Item
    {
        public Item_10_Random_curve(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_11_Curve_right : Item
    {
        public Item_11_Curve_right(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_12_Slow_down : Item
    {
        public Item_12_Slow_down(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {
            List<Projectile> inbound_projectiles = new();

            if (Access_from_rel_down != null)
            {
                inbound_projectiles.AddRange(Access_from_rel_down.GetOutboundProjectile(shipParameter,this));
                foreach (var projectile in inbound_projectiles)
                {
                    projectile.speed /= 2;
                }
            }
            return inbound_projectiles;
        }
    }
    class Item_13_Criticalx2 : Item
    {
        public Item_13_Criticalx2(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {
            List<Projectile> inbound_projectiles = new();

            if (Access_from_rel_down != null)
            {
                inbound_projectiles.AddRange(Access_from_rel_down.GetOutboundProjectile(shipParameter,this));
                foreach (var projectile in inbound_projectiles)
                {
                    projectile.max_damage *= 2;
                    projectile.average_damage = Decimal.Multiply(projectile.average_damage , (Decimal)(1.0 + 1.0 / 3));
                }
            }
            return inbound_projectiles;
        }
    }
    class Item_14_Criticalx10 : Item
    {
        public Item_14_Criticalx10(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {
            List<Projectile> inbound_projectiles = new();

            if (Access_from_rel_down != null)
            {
                inbound_projectiles.AddRange(Access_from_rel_down.GetOutboundProjectile(shipParameter,this));
                foreach (var projectile in inbound_projectiles)
                {
                    projectile.max_damage *= 10;
                    projectile.average_damage = Decimal.Multiply(projectile.average_damage, (Decimal)(1 + 0.04 * 9));
                }
            }
            return inbound_projectiles;
        }
    }
    class Item_15_Random_critical : Item
    {
        public Item_15_Random_critical(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {
            List<Projectile> inbound_projectiles = new();

            if (Access_from_rel_down != null)
            {
                inbound_projectiles.AddRange(Access_from_rel_down.GetOutboundProjectile(shipParameter,this));
                foreach (var projectile in inbound_projectiles)
                {
                    projectile.max_damage *= 4;
                    projectile.average_damage = Decimal.Multiply(projectile.average_damage, (Decimal)(9.0 / 13 + 2.0 / 13 + (3.0 + 4) / 2 / 13));
                }
            }
            return inbound_projectiles;
        }
    }
    class Item_16_Charge : Item
    {
        public Item_16_Charge(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {

            List<Projectile> inbound_projectiles = new();

            if (Access_from_rel_down != null)
            {
                inbound_projectiles.AddRange(Access_from_rel_down.GetOutboundProjectile(shipParameter,this));
                foreach (var projectile in inbound_projectiles)
                {
                    projectile.average_damage *= 1.2m;
                    projectile.max_damage *= 1.2m;
                    projectile.min_damage *= 1.2m;
                }
            }
            return inbound_projectiles;
        }
    }
    class Item_17_Return : Item
    {
        public Item_17_Return(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_18_Random_bounce : Item
    {
        public Item_18_Random_bounce(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_19_Richchet : Item
    {
        public Item_19_Richchet(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_20_Double_lifetime : Item
    {
        public Item_20_Double_lifetime(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_21_Split_2_way : Item
    {
        public Item_21_Split_2_way(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToRIGHT = true;
            IsAccessToLEFT = true;
        }
        public override List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {
            List<Projectile> inbound_projectiles = new();

            if (Access_from_rel_down != null)
            {
                if(Access_to_rel_right == to_thing)
                {
                    inbound_projectiles.AddRange(Access_from_rel_down.GetOutboundProjectile(shipParameter,this));
                }else if(Access_to_rel_left == to_thing)
                {
                    foreach(var projectile in Access_from_rel_down.GetOutboundProjectile(shipParameter,this))
                    {
                        inbound_projectiles.Add(projectile.Copy());
                    }
                }
            }
            return inbound_projectiles;
        }
    }
    class Item_22_Split_3_way : Item
    {
        public Item_22_Split_3_way(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsAccessToRIGHT = true;
            IsAccessToLEFT = true;
        }
        public override List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {
            List<Projectile> inbound_projectiles = new();

            if (Access_from_rel_down != null)
            {
                if(Access_to_rel_top == to_thing)
                {
                    inbound_projectiles.AddRange(Access_from_rel_down.GetOutboundProjectile(shipParameter,this));
                }else if(Access_to_rel_right == to_thing || Access_to_rel_left == to_thing)
                {
                    foreach(var projectile in Access_from_rel_down.GetOutboundProjectile(shipParameter,this))
                    {
                        inbound_projectiles.Add(projectile.Copy());
                    }
                }
            }
            return inbound_projectiles;
        }
    }
    class Item_23_Random_2_way : Item
    {
        public Item_23_Random_2_way(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToRIGHT = true;
            IsAccessToLEFT = true;
        }
        public override List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {
            List<Projectile> inbound_projectiles = new();

            if (Access_from_rel_down != null)
            {
                if(Access_to_rel_right == to_thing)
                {
                    foreach (var projectile in  Access_from_rel_down.GetOutboundProjectile(shipParameter,this))
                    {
                        projectile.min_damage *= 2;
                        projectile.max_damage *= 2;
                        projectile.average_damage *= 2;
                        projectile.fire_rate = projectile.fire_rate / 2;
                        inbound_projectiles.Add(projectile);
                    }
                }else if(Access_to_rel_left == to_thing)
                {
                    foreach(var projectile in Access_from_rel_down.GetOutboundProjectile(shipParameter,this))
                    {
                        var copy = projectile.Copy();
                        copy.min_damage *= 2;
                        copy.max_damage *= 2;
                        copy.average_damage *= 2;
                        copy.fire_rate = projectile.fire_rate / 2;
                        inbound_projectiles.Add(copy);
                    }
                }
            }
            return inbound_projectiles;
        }
    }
    class Item_24_Random_3_way : Item
    {
        public Item_24_Random_3_way(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsAccessToRIGHT = true;
            IsAccessToLEFT = true;
        }
        public override List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {
            List<Projectile> inbound_projectiles = new();

            if (Access_from_rel_down != null)
            {
                if(Access_to_rel_top == to_thing)
                {
                    foreach (var projectile in  Access_from_rel_down.GetOutboundProjectile(shipParameter,this))
                    {
                        projectile.min_damage *= 3;
                        projectile.max_damage *= 3;
                        projectile.average_damage *= 3;
                        projectile.fire_rate = projectile.fire_rate / 3;
                        inbound_projectiles.Add(projectile);
                    }
                }else if(Access_to_rel_right == to_thing)
                {
                    foreach(var projectile in Access_from_rel_down.GetOutboundProjectile(shipParameter,this))
                    {
                        var copy = projectile.Copy();
                        copy.min_damage *= 3;
                        copy.max_damage *= 3;
                        copy.average_damage *= 3;
                        copy.fire_rate = projectile.fire_rate / 3;
                        inbound_projectiles.Add(copy);
                    }
                }else if(Access_to_rel_left == to_thing)
                {
                    foreach(var projectile in Access_from_rel_down.GetOutboundProjectile(shipParameter,this))
                    {
                        var copy  = projectile.Copy();
                        copy.min_damage *= 3;
                        copy.max_damage *= 3;
                        copy.average_damage *= 3;
                        copy.fire_rate = projectile.fire_rate / 3;
                        inbound_projectiles.Add(copy);
                    }
                }
            }
            return inbound_projectiles;
        }
    }
    class Item_25_Remaining_damage : Item
    {
        public Item_25_Remaining_damage(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_26_Pierce : Item
    {
        public Item_26_Pierce(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_27_Round_area : Item
    {
        public Item_27_Round_area(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_28_Rectangle_area : Item
    {
        public Item_28_Rectangle_area(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_29_Attraction : Item
    {
        public Item_29_Attraction(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_30_Align_direction : Item
    {
        public Item_30_Align_direction(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_31_Align_to_ship : Item
    {
        public Item_31_Align_to_ship(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_32_Add_projectile : Item
    {
        public Item_32_Add_projectile(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {
            //TO BE CONFIRMED
            List<Projectile> inbound_projectiles = new();

            if (Access_from_rel_down != null)
            {
                inbound_projectiles.AddRange(Access_from_rel_down.GetOutboundProjectile(shipParameter,this));
                var first_projectile = inbound_projectiles.First<Projectile>();

                var projectile = new Projectile();
                projectile.average_damage = first_projectile.average_damage;
                projectile.max_damage = first_projectile.max_damage;
                projectile.min_damage = first_projectile.min_damage;
                projectile.fire_rate = first_projectile.fire_rate;
                projectile.speed = first_projectile.speed;
                inbound_projectiles.Add(projectile);
            }
            return inbound_projectiles;
        }
    }
    class Item_33_Fly_forward : Item
    {
        public Item_33_Fly_forward(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_34_Fly_sideways : Item
    {
        public Item_34_Fly_sideways(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_35_Money_crossing : Item
    {
        public Item_35_Money_crossing(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromRIGHT = true;
            IsAccessFromDOWN = true;
            IsAccessFromLEFT = true;
            IsAccessToTOP = true;
            IsAccessToRIGHT = true;
            IsAccessToLEFT = true;
        }
        //TO BE CONFIRMED
        public override List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {
            List<Projectile> inbound_projectiles = new();

            if (Access_to_rel_top == to_thing)
            {
                if (Access_from_rel_down != null)
                {
                    inbound_projectiles.AddRange(Access_from_rel_down.GetOutboundProjectile(shipParameter, this));
                }

            }
            else if(Access_to_rel_left == to_thing || Access_to_rel_right == to_thing)
            {
                if (Access_to_rel_left == to_thing)
                {
                    if (Access_from_rel_right != null)
                        inbound_projectiles.AddRange(Access_from_rel_right.GetOutboundProjectile(shipParameter, this));
                }
                else if (Access_to_rel_right == to_thing)
                {
                    if (Access_from_rel_left != null)
                        inbound_projectiles.AddRange(Access_from_rel_left.GetOutboundProjectile(shipParameter, this));
                }
            }
            return inbound_projectiles;
        }
    }
    class Item_36_Damage_crossing : Item
    {
        public Dictionary<Projectile, Projectile> projectile_history = new();


        public Item_36_Damage_crossing(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromRIGHT = true;
            IsAccessFromDOWN = true;
            IsAccessFromLEFT = true;
            IsAccessToTOP = true;
            IsAccessToRIGHT = true;
            IsAccessToLEFT = true;
        }
        public override List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {
            List<Projectile> inbound_projectiles = new();

            if (Access_to_rel_top == to_thing)
            {
                if (Access_from_rel_down != null)
                {
                    inbound_projectiles.AddRange(Access_from_rel_down.GetOutboundProjectile(shipParameter, this));
                    foreach (var projectile in inbound_projectiles)
                    {
                        foreach (var self_and_ancestor in projectile.self_and_ancestors)
                        {
                            if (projectile_history.TryGetValue(self_and_ancestor, out Projectile his_projectile))
                            {
                                projectile.average_damage += his_projectile.average_damage;
                                projectile.min_damage += his_projectile.min_damage;
                                projectile.max_damage += his_projectile.max_damage;
                            }
                            break;
                        }
                    }
                }

            }
            else if(Access_to_rel_left == to_thing || Access_to_rel_right == to_thing)
            {
                if (Access_to_rel_left == to_thing)
                {
                    if (Access_from_rel_right != null)
                        inbound_projectiles.AddRange(Access_from_rel_right.GetOutboundProjectile(shipParameter, this));
                }
                else if (Access_to_rel_right == to_thing)
                {
                    if (Access_from_rel_left != null)
                        inbound_projectiles.AddRange(Access_from_rel_left.GetOutboundProjectile(shipParameter, this));
                }
                foreach (var projectile in inbound_projectiles)
                {
                    projectile_history[projectile] = projectile;
                }
            }
            return inbound_projectiles;
        }
    }
    class Item_700_Add_100_damage : Item
    {
        public Item_700_Add_100_damage(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {
            List<Projectile> inbound_projectiles = new();

            if (Access_from_rel_down != null)
            {
                inbound_projectiles.AddRange(Access_from_rel_down.GetOutboundProjectile(shipParameter,this));
                foreach(var projectile in inbound_projectiles)
                {
                    projectile.average_damage += 100;
                    projectile.max_damage += 100;
                    projectile.min_damage += 100;
                }

            }
            return inbound_projectiles;
        }
    }


}
