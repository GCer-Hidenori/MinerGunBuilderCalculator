using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    class Item_001_Guide_right : Item
    {
        public Item_001_Guide_right(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToRIGHT = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            if (inbound_projectileStat.EnableGuideDamage)
            {
                inbound_projectileStat.average_damage *= 1.1m;
                inbound_projectileStat.max_damage *= 1.1m;
                inbound_projectileStat.min_damage *= 1.1m;
            }

            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile.EnableGuideDamage)
            {
                inbound_projectile.damage *= 1.1m;
            }
            return inbound_projectile;
        }
    }
    class Item_002_Guide_left : Item
    {
        public Item_002_Guide_left(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToLEFT = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            if (inbound_projectileStat.EnableGuideDamage)
            {
                inbound_projectileStat.average_damage *= 1.1m;
                inbound_projectileStat.max_damage *= 1.1m;
                inbound_projectileStat.min_damage *= 1.1m;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile.EnableGuideDamage)
            {
                inbound_projectile.damage *= 1.1m;
            }
            return inbound_projectile;
        }
    }
    class Item_003_Add_1_damage : Item
    {
        public Item_003_Add_1_damage(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.average_damage += 1;
            inbound_projectileStat.max_damage += 1;
            inbound_projectileStat.min_damage += 1;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                inbound_projectile.damage += 1;
            }
            return inbound_projectile;
        }
    }
    class Item_004_Speed_up : Item
    {
        public Item_004_Speed_up(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.speed += 1;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                inbound_projectile.speed += 1;
            }
            return inbound_projectile;
        }
    }
    class Item_005_Spread_left : Item
    {
        public Item_005_Spread_left(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_006_Large_spread : Item
    {
        public Item_006_Large_spread(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_007_Spread_right : Item
    {
        public Item_007_Spread_right(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_008_Small_spread : Item
    {
        public Item_008_Small_spread(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_009_Curve_left : Item
    {
        public Item_009_Curve_left(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_010_Random_curve : Item
    {
        public Item_010_Random_curve(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_011_Curve_right : Item
    {
        public Item_011_Curve_right(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_012_Slow_down : Item
    {
        public Item_012_Slow_down(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.speed /= 2;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                inbound_projectile.speed /= 2;
            }
            return inbound_projectile;
        }
    }
    class Item_013_Criticalx2 : Item
    {
        public Item_013_Criticalx2(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.max_damage *= 2;
            inbound_projectileStat.average_damage = Decimal.Multiply(inbound_projectileStat.average_damage, (Decimal)(1.0 + 1.0 / 3));
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = null;

            Random rand = new Random();
            inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (rand.Next(0, 100) < 33) inbound_projectile.damage *= 2;
            return inbound_projectile;
        }
    }
    class Item_014_Criticalx10 : Item
    {
        public Item_014_Criticalx10(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.max_damage *= 10;
            inbound_projectileStat.average_damage = Decimal.Multiply(inbound_projectileStat.average_damage, (Decimal)(1 + 0.04 * 9));
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = null;

            Random rand = new Random();
            inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (rand.Next(0, 100) < 4) inbound_projectile.damage *= 10;
            return inbound_projectile;
        }
    }
    class Item_015_Random_critical : Item
    {
        public Item_015_Random_critical(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.min_damage = 0;
            inbound_projectileStat.max_damage *= 4;
            inbound_projectileStat.average_damage = Decimal.Multiply(inbound_projectileStat.average_damage, (Decimal)(9.0 / 13 + 2.0 / 13 + (3.0 + 4) / 2 / 13));
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = null;

            Random rand = new Random();
            inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            switch (rand.Next(0, 12))
            {
                case 0:
                    inbound_projectile.damage = 0;
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    break;
                case 10:
                    inbound_projectile.damage *= 2;
                    break;
                case 11:
                    switch (rand.Next(0, 2))
                    {
                        case 0:
                            inbound_projectile.damage *= 3;
                            break;
                        case 1:
                            inbound_projectile.damage *= 4;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }

            return inbound_projectile;
        }
    }
    class Item_016_Charge : Item
    {
        public Item_016_Charge(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.average_damage *= 1.2m;
            inbound_projectileStat.max_damage *= 1.2m;
            inbound_projectileStat.min_damage *= 1.2m;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                inbound_projectile.damage *= 1.2m;
            }
            return inbound_projectile;
        }
    }
    class Item_017_Return : Item
    {
        public Item_017_Return(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_018_Random_bounce : Item
    {
        public Item_018_Random_bounce(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_019_Richchet : Item
    {
        public Item_019_Richchet(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_020_Double_lifetime : Item
    {
        public Item_020_Double_lifetime(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.lifetime *= 2;
            return inbound_projectileStat;
        }
    }
    class Item_021_Split_2_way : Item
    {
        public Item_021_Split_2_way(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToRIGHT = true;
            IsAccessToLEFT = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = null;

            if (Access_to_rel_right == to_thing)
            {
                inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            }
            else if (Access_to_rel_left == to_thing)
            {
                var projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
                inbound_projectileStat = projectileStat.Copy();
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = null;

            if (Access_to_rel_right == to_thing)
            {
                inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            }
            else if (Access_to_rel_left == to_thing)
            {
                var projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
                inbound_projectile = projectile.Copy();
            }
            return inbound_projectile;
        }
    }
    class Item_022_Split_3_way : Item
    {
        public Item_022_Split_3_way(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsAccessToRIGHT = true;
            IsAccessToLEFT = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = null;

            if (Access_to_rel_top == to_thing)
            {
                inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            }
            else if (Access_to_rel_right == to_thing || Access_to_rel_left == to_thing)
            {
                var projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
                inbound_projectileStat = projectileStat.Copy();
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = null;

            if (Access_to_rel_top == to_thing)
            {
                inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            }
            else if (Access_to_rel_right == to_thing || Access_to_rel_left == to_thing)
            {
                var projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
                inbound_projectile = projectile.Copy();
            }

            return inbound_projectile;
        }
    }
    class Item_023_Random_2_way : Item
    {
        public Item_023_Random_2_way(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToRIGHT = true;
            IsAccessToLEFT = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = null;

            if (Access_to_rel_right == to_thing)
            {
                var projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
                projectileStat.min_damage *= 2;
                projectileStat.max_damage *= 2;
                projectileStat.average_damage *= 2;
                projectileStat.magnification = projectileStat.magnification / 2;
                inbound_projectileStat = projectileStat;
            }
            else if (Access_to_rel_left == to_thing)
            {
                var projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
                var copy = projectileStat.Copy();
                copy.min_damage *= 2;
                copy.max_damage *= 2;
                copy.average_damage *= 2;
                copy.magnification = projectileStat.magnification / 2;
                inbound_projectileStat = copy;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = null;

            if (Access_to_rel_right == to_thing)
            {
                var projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
                projectile.damage *= 2;
                projectile.magnification = projectile.magnification / 2;
                inbound_projectile = projectile;
            }
            else if (Access_to_rel_left == to_thing)
            {
                var projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
                var copy = projectile.Copy();
                copy.damage *= 2;
                copy.magnification = projectile.magnification / 2;
                inbound_projectile = copy;
            }
            return inbound_projectile;
        }
    }
    class Item_024_Random_3_way : Item
    {
        public Item_024_Random_3_way(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsAccessToRIGHT = true;
            IsAccessToLEFT = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = null;

            if (Access_to_rel_top == to_thing)
            {
                var projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
                projectileStat.min_damage *= 3;
                projectileStat.max_damage *= 3;
                projectileStat.average_damage *= 3;
                projectileStat.magnification = projectileStat.magnification / 3;
                inbound_projectileStat = projectileStat;
            }
            else if (Access_to_rel_right == to_thing)
            {
                var projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
                var copy = projectileStat.Copy();
                copy.min_damage *= 3;
                copy.max_damage *= 3;
                copy.average_damage *= 3;
                copy.magnification = projectileStat.magnification / 3;
                inbound_projectileStat = copy;
            }
            else if (Access_to_rel_left == to_thing)
            {
                var projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
                var copy = projectileStat.Copy();
                copy.min_damage *= 3;
                copy.max_damage *= 3;
                copy.average_damage *= 3;
                copy.magnification = projectileStat.magnification / 3;
                inbound_projectileStat = copy;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = null;

            if (Access_to_rel_top == to_thing)
            {
                var projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
                projectile.damage *= 3;
                projectile.magnification = projectile.magnification / 3;
                inbound_projectile = projectile;
            }
            else if (Access_to_rel_right == to_thing)
            {
                var projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
                var copy = projectile.Copy();
                copy.damage *= 3;
                copy.magnification = projectile.magnification / 3;
                inbound_projectile = copy;
            }
            else if (Access_to_rel_left == to_thing)
            {
                var projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
                var copy = projectile.Copy();
                copy.damage *= 3;
                copy.magnification = projectile.magnification / 3;
                inbound_projectile = copy;
            }

            return inbound_projectile;
        }
    }
    class Item_025_Remaining_damage : Item
    {
        public Item_025_Remaining_damage(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_026_Pierce : Item
    {
        public Item_026_Pierce(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_027_Round_area : Item
    {
        public Item_027_Round_area(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_028_Rectangle_area : Item
    {
        public Item_028_Rectangle_area(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_029_Attraction : Item
    {
        public Item_029_Attraction(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_030_Align_direction : Item
    {
        public Item_030_Align_direction(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_031_Align_to_ship : Item
    {
        public Item_031_Align_to_ship(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_032_Add_projectile : Item
    {
        public Item_032_Add_projectile(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            //TO BE CONFIRMED
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.magnification += 1;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            //TO BE CONFIRMED
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                inbound_projectile.magnification += 1;
            }
            return inbound_projectile;
        }
    }
    class Item_033_Fly_forward : Item
    {
        public Item_033_Fly_forward(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_034_Fly_sideways : Item
    {
        public Item_034_Fly_sideways(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_035_Money_crossing : Item
    {
        public Item_035_Money_crossing(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromRIGHT = true;
            IsAccessFromDOWN = true;
            IsCrossing = true;
            IsAccessFromLEFT = true;
            IsAccessToTOP = true;
            IsAccessToRIGHT = true;
            IsAccessToLEFT = true;
        }
        //TO BE CONFIRMED
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = null;

            if (Access_to_rel_top == to_thing)
            {
                if (Access_from_rel_down != null)
                {
                    inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
                }
            }
            else if (Access_to_rel_left == to_thing || Access_to_rel_right == to_thing)
            {
                if (Access_to_rel_left == to_thing)
                {
                    if (Access_from_rel_right != null)
                        inbound_projectileStat = Access_from_rel_right.GetOutboundProjectileStat(shipParameter, profile, this);
                }
                else if (Access_to_rel_right == to_thing)
                {
                    if (Access_from_rel_left != null)
                        inbound_projectileStat = Access_from_rel_left.GetOutboundProjectileStat(shipParameter, profile, this);
                }
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = null;

            if (Access_to_rel_top == to_thing)
            {
                if (Access_from_rel_down != null)
                {
                    inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
                }

            }
            else if (Access_to_rel_left == to_thing || Access_to_rel_right == to_thing)
            {
                if (Access_to_rel_left == to_thing)
                {
                    if (Access_from_rel_right != null)
                        inbound_projectile = Access_from_rel_right.GetOutboundProjectile(shipParameter, profile, this);
                }
                else if (Access_to_rel_right == to_thing)
                {
                    if (Access_from_rel_left != null)
                        inbound_projectile = Access_from_rel_left.GetOutboundProjectile(shipParameter, profile, this);
                }
            }
            return inbound_projectile;
        }
    }
    class Item_036_Damage_crossing : Item
    {
        [JsonIgnore]
        public Dictionary<ProjectileStat, ProjectileStat> projectileStats_history = new();

        [JsonIgnore]
        public Dictionary<Projectile, Projectile> projectile_history = new();

        public override void ResetBeforeCalculateDamage()
        {
            projectileStats_history.Clear();
            projectile_history.Clear();
        }
        public Item_036_Damage_crossing(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromRIGHT = true;
            IsAccessFromDOWN = true;
            IsAccessFromLEFT = true;
            IsCrossing = true;
            IsAccessToTOP = true;
            IsAccessToRIGHT = true;
            IsAccessToLEFT = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = null;

            if (Access_to_rel_top == to_thing)
            {
                if (Access_from_rel_down != null)
                {
                    inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
                    foreach (var self_and_ancestor in inbound_projectileStat.self_and_ancestors)
                    {
                        if (projectileStats_history.TryGetValue(self_and_ancestor, out ProjectileStat his_projectileStats))
                        {
                            inbound_projectileStat.average_damage += his_projectileStats.average_damage;
                            inbound_projectileStat.min_damage += his_projectileStats.min_damage;
                            inbound_projectileStat.max_damage += his_projectileStats.max_damage;
                        }
                        break;
                    }
                }
            }
            else if (Access_to_rel_left == to_thing || Access_to_rel_right == to_thing)
            {
                if (Access_to_rel_left == to_thing)
                {
                    if (Access_from_rel_right != null)
                        inbound_projectileStat = Access_from_rel_right.GetOutboundProjectileStat(shipParameter, profile, this);
                }
                else if (Access_to_rel_right == to_thing)
                {
                    if (Access_from_rel_left != null)
                        inbound_projectileStat = Access_from_rel_left.GetOutboundProjectileStat(shipParameter, profile, this);
                }
                var projectileStat = inbound_projectileStat;
                projectileStats_history[projectileStat] = projectileStat;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = null;

            if (Access_to_rel_top == to_thing)
            {
                if (Access_from_rel_down != null)
                {
                    inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
                    foreach (var self_and_ancestor in inbound_projectile.self_and_ancestors)
                    {
                        if (projectile_history.TryGetValue(self_and_ancestor, out Projectile his_projectile))
                        {
                            inbound_projectile.damage += his_projectile.damage;
                        }
                        break;
                    }
                }

            }
            else if (Access_to_rel_left == to_thing || Access_to_rel_right == to_thing)
            {
                if (Access_to_rel_left == to_thing)
                {
                    if (Access_from_rel_right != null)
                        inbound_projectile = Access_from_rel_right.GetOutboundProjectile(shipParameter, profile, this);
                }
                else if (Access_to_rel_right == to_thing)
                {
                    if (Access_from_rel_left != null)
                        inbound_projectile = Access_from_rel_left.GetOutboundProjectile(shipParameter, profile, this);
                }
                projectile_history[inbound_projectile] = inbound_projectile;
            }
            return inbound_projectile;
        }
    }
    class Item_101_Tier_damage : Item
    {
        public Item_101_Tier_damage(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            int additional = (int)Decimal.Round(Decimal.Multiply(profile.Highest_Reached_Tier_in_World_Map, 0.1m), MidpointRounding.AwayFromZero);
            inbound_projectileStat.average_damage += additional;
            inbound_projectileStat.max_damage += additional;
            inbound_projectileStat.min_damage += additional;

            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            int additional = (int)Decimal.Round(Decimal.Multiply(profile.Highest_Reached_Tier_in_World_Map, 0.1m), MidpointRounding.AwayFromZero);
            inbound_projectile.damage += additional;

            return inbound_projectile;
        }
    }
    class Item_102_More_than_lower : Item
    {
        [JsonIgnore]
        private decimal? last_damage = null;

        public override void ResetBeforeCalculateDamage()
        {
            last_damage = null;
        }
        public Item_102_More_than_lower(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }

        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = null;
            const int Count = 1000;
            decimal total_damage = new();
            decimal max_damage = new();
            decimal? min_damage = null;
            decimal? last_damage_for_stats = null;
            Projectile projectile = new();
            int j = 0;
            for (int i = 0; i < Count; i++)
            {
                projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
                if (projectile != null)
                {
                    j += 1;
                    if (last_damage_for_stats != null && last_damage_for_stats > projectile.damage) projectile.damage *= 4;
                    total_damage += projectile.damage;
                    max_damage = max_damage < projectile.damage ? projectile.damage : max_damage;
                    min_damage = (min_damage == null || min_damage > projectile.damage) ? projectile.damage : min_damage;
                    last_damage_for_stats = projectile.damage;
                }
            }
            ProjectileStat projectileStat = new();
            projectileStat.average_damage = total_damage / j;
            projectileStat.max_damage = max_damage;
            projectileStat.min_damage = (decimal)min_damage;
            projectileStat.magnification = projectile.magnification;
            projectileStat.speed = projectile.speed;
            projectileStat.lifetime = projectile.lifetime;
            projectileStat.EnableGuideDamage = projectile.EnableGuideDamage;
            inbound_projectileStat = projectileStat;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (last_damage != null)
            {
                if (last_damage > inbound_projectile.damage) inbound_projectile.damage *= 4;
            }
            last_damage = inbound_projectile.damage;
            return inbound_projectile;
        }
    }
    class Item_103_Late_damage : Item
    {
        public Item_103_Late_damage(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            decimal late_damage_magnification = (inbound_projectileStat.lifetime + 0.4m) / inbound_projectileStat.lifetime;
            inbound_projectileStat.average_damage *= late_damage_magnification;
            inbound_projectileStat.max_damage *= late_damage_magnification;
            inbound_projectileStat.min_damage *= late_damage_magnification;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                decimal late_damage_magnification = (inbound_projectile.lifetime + 0.4m) / inbound_projectile.lifetime;
                inbound_projectile.damage *= late_damage_magnification;
            }
            return inbound_projectile;
        }
    }
    class Item_104_Unused_tile : Item
    {
        public Item_104_Unused_tile(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        private decimal Calc_additional_damage_magnification()
        {
            var thing_1dim_layout = thing_layout.Cast<Thing>();
            IEnumerable<Thing> IEnull = thing_1dim_layout.Where(thing => thing.GetType().Name == "Parts_Null");
            int num_unused_tiles = IEnull.Count<Thing>();
            return 1m + 0.1m * num_unused_tiles;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = null;

            decimal additional_damage_magnification = Calc_additional_damage_magnification();
            inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.average_damage *= additional_damage_magnification;
            inbound_projectileStat.max_damage *= additional_damage_magnification;
            inbound_projectileStat.min_damage *= additional_damage_magnification;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = null;

            decimal additional_damage_magnification = Calc_additional_damage_magnification();
            inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                inbound_projectile.damage *= additional_damage_magnification;
            }
            return inbound_projectile;
        }
    }
    // More damage, x2 at 1 speed to x5 at 0.2 speed, for slower projectiles.
    class Item_105_Slow_damage : Item
    {
        public Item_105_Slow_damage(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            decimal magnification = 1m;
            if (0.2m <= inbound_projectileStat.speed && inbound_projectileStat.speed <= 1)
            {
                magnification = Math.Truncate(-3.75m * inbound_projectileStat.speed + 5.75m);
            }
            else if (inbound_projectileStat.speed < 0.2m)
            {
                magnification = 5m;
            }
            inbound_projectileStat.average_damage *= magnification;
            inbound_projectileStat.max_damage *= magnification;
            inbound_projectileStat.min_damage *= magnification;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            decimal magnification = 1m;
            if (0.2m <= inbound_projectile.speed && inbound_projectile.speed <= 1)
            {
                magnification = Math.Truncate(-3.75m * inbound_projectile.speed + 5.75m);
            }
            else if (inbound_projectile.speed < 0.2m)
            {
                magnification = 5m;
            }
            inbound_projectile.damage *= magnification;

            return inbound_projectile;
        }
    }
    class Item_106_Combine10 : Item
    {
        int count = 0;
        public Item_106_Combine10(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.average_damage *= 20;
            inbound_projectileStat.max_damage *= 20;
            inbound_projectileStat.min_damage *= 20;
            inbound_projectileStat.magnification /= 10;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = null;
            count += 1;
            if (count >= 10)
            {
                inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
                if (inbound_projectile != null)
                {
                    inbound_projectile.damage *= 20;
                }

                count = 0;
            }
            return inbound_projectile;
        }
    }

    //TO BE SUPPORT
    class Item_107_Change_Direction : Item
    {
        public Item_107_Change_Direction(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_108_Guide_Damage : Item
    {
        public Item_108_Guide_Damage(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.EnableGuideDamage = true;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            inbound_projectile.EnableGuideDamage = true;

            return inbound_projectile;
        }
    }
    class Item_109_Add_100_damage : Item
    {
        public Item_109_Add_100_damage(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.average_damage += 100;
            inbound_projectileStat.max_damage += 100;
            inbound_projectileStat.min_damage += 100;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            inbound_projectile.damage += 100;

            return inbound_projectile;
        }
    }
    class Item_110_Ejection_Damage : Item
    {
        public Item_110_Ejection_Damage(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        private decimal Count_Unused_Ejection()
        {
            var thing_1dim_layout = thing_layout.Cast<Thing>();
            IEnumerable<Thing> IEunusedEjection = thing_1dim_layout.Where(thing => thing.GetType().Name == "Parts_02_Ejector").Where(thing => thing.Access_from_abs_top == null).Where(thing => thing.Access_from_abs_right == null).Where(thing => thing.Access_from_abs_down == null).Where(thing => thing.Access_from_abs_left == null);
            return IEunusedEjection.Count<Thing>();
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = null;

            decimal additional_damage = Count_Unused_Ejection() * 10m;
            inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.average_damage += additional_damage;
            inbound_projectileStat.max_damage += additional_damage;
            inbound_projectileStat.min_damage += additional_damage;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = null;

            decimal additional_damage = Count_Unused_Ejection() * 10m;
            inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                inbound_projectile.damage += additional_damage;
            }

            return inbound_projectile;
        }
    }

    //TO BE SUPPORT
    class Item_111_Few_Shot_Damage : Item
    {
        public Item_111_Few_Shot_Damage(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_112_Clone : Item
    {
        public Item_112_Clone(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.magnification *= 2m;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = null;

            inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                inbound_projectile.magnification *= 2;
            }

            return inbound_projectile;
        }
    }
}
