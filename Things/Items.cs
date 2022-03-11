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
        private static decimal SkillTree_Add5damage(HashSet<string> skillList)
        {
            return skillList.Contains("03_12")? 5m : 0m;
        }
        public Item_001_Guide_right(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToRIGHT = true;
            IsGuide = true;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.average_damage += SkillTree_Add5damage(profile.skillList);
            inbound_projectileStat.max_damage += SkillTree_Add5damage(profile.skillList);
            inbound_projectileStat.min_damage += SkillTree_Add5damage(profile.skillList);
            if (inbound_projectileStat.Legendary_EnableGuideDamage)
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
            inbound_projectile.damage += SkillTree_Add5damage(profile.skillList);
            if (inbound_projectile.Legendary_EnableGuideDamage)
            {
                inbound_projectile.damage *= 1.1m;
            }
            return inbound_projectile;
        }
    }
    class Item_002_Guide_left : Item
    {
        private static decimal SkillTree_Add5damage(HashSet<string> skillList)
        {
            return skillList.Contains("04_11") ? 5m : 0m;
        }
        public Item_002_Guide_left(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToLEFT = true;
            IsGuide = true;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.average_damage += SkillTree_Add5damage(profile.skillList);
            inbound_projectileStat.max_damage += SkillTree_Add5damage(profile.skillList);
            inbound_projectileStat.min_damage += SkillTree_Add5damage(profile.skillList);
            if (inbound_projectileStat.Legendary_EnableGuideDamage)
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
            inbound_projectile.damage += SkillTree_Add5damage(profile.skillList);
            if (inbound_projectile.Legendary_EnableGuideDamage)
            {
                inbound_projectile.damage *= 1.1m;
            }
            return inbound_projectile;
        }
    }
    class Item_003_Add_1_damage : Item
    {
        public Item_003_Add_1_damage(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,  this);
            decimal additional_damage = 0m;
            if (profile.skillList.Contains("05_08"))
            {
                additional_damage = 5m;
            }
            if (profile.skillList.Contains("05_00"))
            {
                var thing_1dim_layout = thing_layout.Cast<Thing>();
                IEnumerable<Thing> IEadd1damage = thing_1dim_layout.Where(thing => thing.GetType().Name == "Item_003_Add_1_damage");
                int num_add1damage = IEadd1damage.Count<Thing>();
                additional_damage += 20m * num_add1damage;
            }
            inbound_projectileStat.average_damage += 1m + additional_damage;
            inbound_projectileStat.max_damage += 1m + additional_damage;
            inbound_projectileStat.min_damage += 1m + additional_damage;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,  this);
            if (inbound_projectile != null)
            {
                decimal additional_damage = 0m;
                if (profile.skillList.Contains("05_08"))
                {
                    additional_damage = 5m;
                }
                if (profile.skillList.Contains("05_00"))
                {
                    var thing_1dim_layout = thing_layout.Cast<Thing>();
                    IEnumerable<Thing> IEadd1damage = thing_1dim_layout.Where(thing => thing.GetType().Name == "Item_003_Add_1_damage");
                    int num_add1damage = IEadd1damage.Count<Thing>();
                    additional_damage += 20m * num_add1damage;
                }
                inbound_projectile.damage += 1m + additional_damage;
            }
            return inbound_projectile;
        }
    }
    class Item_004_Speed_up : Item
    {
        public Item_004_Speed_up(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.speed += 1m;
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                inbound_projectile.speed += 1m;
            }
            return inbound_projectile;
        }
    }
    class Item_005_Spread_left : Item
    {
        public Item_005_Spread_left(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            if(profile.skillList.Contains("06_11")){
                inbound_projectileStat.average_damage *= 1.25m;
                inbound_projectileStat.max_damage *= 1.5m;
            }
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                if (profile.skillList.Contains("06_11"))
                {
                    decimal magnification = 1.0m + (decimal)rand.NextDouble() * 0.5m;
                    inbound_projectile.damage *= magnification;
                }
            }
            return inbound_projectile;
        }
    }
    class Item_006_Large_spread : Item
    {
        public Item_006_Large_spread(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            if(profile.skillList.Contains("07_10")){
                inbound_projectileStat.average_damage *= 1.3m;
                inbound_projectileStat.max_damage *= 1.6m;
            }
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                if (profile.skillList.Contains("07_10"))
                {
                    decimal magnification = 1.0m + (decimal)rand.NextDouble() * 0.6m;
                    inbound_projectile.damage *= magnification;
                }
            }
            return inbound_projectile;
        }
    }
    class Item_007_Spread_right : Item
    {
        public Item_007_Spread_right(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            if(profile.skillList.Contains("07_12")){
                inbound_projectileStat.average_damage *= 1.25m;
                inbound_projectileStat.max_damage *= 1.5m;
            }
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                if (profile.skillList.Contains("07_12"))
                {
                    decimal magnification = 1.0m + (decimal)rand.NextDouble() * 0.5m;
                    inbound_projectile.damage *= magnification;
                }
            }
            return inbound_projectile;
        }
    }
    class Item_008_Small_spread : Item
    {
        public Item_008_Small_spread(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            if(profile.skillList.Contains("08_11")){
                inbound_projectileStat.average_damage *= 1.1m;
                inbound_projectileStat.max_damage *= 1.2m;
            }
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                if (profile.skillList.Contains("08_11"))
                {
                    decimal magnification = 1.0m + (decimal)rand.NextDouble() * 0.2m;
                    inbound_projectile.damage *= magnification;
                }
            }
            return inbound_projectile;
        }
    }
    class Item_009_Curve_left : Item
    {
        public Item_009_Curve_left(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,  this);
            if (profile.skillList.Contains("05_06"))
            {
                inbound_projectileStat.average_damage *= 1.4m;
                inbound_projectileStat.max_damage *= 1.4m;
                inbound_projectileStat.min_damage *= 1.4m;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,  this);
            if (profile.skillList.Contains("05_06"))
            {
                inbound_projectile.damage *= 1.4m;
            }
            return inbound_projectile;
        }
    }
    class Item_010_Random_curve : Item
    {
        public Item_010_Random_curve(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,  this);
            if (profile.skillList.Contains("03_08"))
            {
                inbound_projectileStat.average_damage *= 1.3m;
                inbound_projectileStat.max_damage *= 1.6m;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,  this);
            if (profile.skillList.Contains("03_08"))
            {
                    decimal magnification = 1.0m + (decimal)rand.NextDouble() * 0.6m;
                    inbound_projectile.damage *= magnification;
            }
            return inbound_projectile;
        }
    }
    class Item_011_Curve_right : Item
    {
        public Item_011_Curve_right(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,  this);
            if (profile.skillList.Contains("04_05"))
            {
                inbound_projectileStat.average_damage *= 1.4m;
                inbound_projectileStat.max_damage *= 1.4m;
                inbound_projectileStat.min_damage *= 1.4m;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,  this);
            if (profile.skillList.Contains("04_05"))
            {
                inbound_projectile.damage *= 1.4m;
            }
            return inbound_projectile;
        }
    }
    class Item_012_Slow_down : Item
    {
        public Item_012_Slow_down(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.speed /= 2m;
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                inbound_projectile.speed /= 2m;
            }
            return inbound_projectile;
        }
    }
    class Item_013_Criticalx2 : Item
    {
        private static decimal SkillTree_IncreaseChance_magnification(HashSet<string> skillList)
        {
            decimal hit_rate,magnification;
            if(skillList.Contains("02_13"))
            {
                hit_rate = 0.4m;
            }else
            {
                hit_rate = 0.3m;
            }
            if(skillList.Contains("01_12"))
            {
                magnification = 2.5m;
            }
            else
            {
                magnification = 2m;
            }
            //return skillList.Contains("02_13") ? 1.4m : (decimal)(1.0+1.0/3);
            return (1.0m-hit_rate) + hit_rate * magnification;
        }
        private static int SkillTree_IncreaseChance_Chance(HashSet<string> skillList)
        {
            return skillList.Contains("02_13") ? 7 : 0;
        }
        public Item_013_Criticalx2(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.max_damage *= profile.skillList.Contains("01_12") ? 2.5m : 2m;
            inbound_projectileStat.average_damage = Decimal.Multiply(inbound_projectileStat.average_damage, SkillTree_IncreaseChance_magnification(profile.skillList));
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (rand.Next(0, 100) < (33m + SkillTree_IncreaseChance_Chance(profile.skillList))) inbound_projectile.damage *= profile.skillList.Contains("01_12") ? 2.5m : 2m;
            return inbound_projectile;
        }
    }
    class Item_014_Criticalx10 : Item
    {
        private static decimal SkillTree_IncreaseChance_magnification(HashSet<string> skillList)
        {
            return skillList.Contains("02_15") ? (decimal)(1m-0.06m+0.06m * (10m+SkillTree_High_Times(skillList))) : (decimal)(1m - 0.04m + 0.04m * (10m + SkillTree_High_Times(skillList)));
        }
        private static int SkillTree_IncreaseChance_Chance(HashSet<string> skillList)
        {
            return skillList.Contains("02_15") ? 2 : 0;
        }
        private static decimal SkillTree_High_Times(HashSet<string> skillList)
        {
            return skillList.Contains("01_16") ? 2m : 0m;
        }
        public Item_014_Criticalx10(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.max_damage *= (10m + SkillTree_High_Times(profile.skillList));
            inbound_projectileStat.average_damage = Decimal.Multiply(inbound_projectileStat.average_damage, SkillTree_IncreaseChance_magnification(profile.skillList));
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            //Projectile inbound_projectile = null;

            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (rand.Next(0, 100) < (4 + SkillTree_IncreaseChance_Chance(profile.skillList))) inbound_projectile.damage *= 10m;
            return inbound_projectile;
        }
    }
    class Item_015_Random_critical : Item
    {
        int counter_instead_of_random_number = 0;
        public Item_015_Random_critical(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override void ResetBeforeCalculateDamage()
        {
            base.ResetBeforeCalculateDamage();
            counter_instead_of_random_number = 0;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,  this);
            inbound_projectileStat.min_damage = 0m;
            if (profile.skillList.Contains("03_18"))
            {
                inbound_projectileStat.max_damage *= 4m;
                inbound_projectileStat.average_damage = Decimal.Multiply(inbound_projectileStat.average_damage, (Decimal)( (1.0m+2.0m+3.0m + 4m)/7m));
            }
            else if (profile.skillList.Contains("03_16"))
            {
                inbound_projectileStat.max_damage *= 3m;
                inbound_projectileStat.average_damage = Decimal.Multiply(inbound_projectileStat.average_damage, (Decimal)( (1.0m+1.0m+2.0m + 3.0m)/5m));
            }
            else
            {
                inbound_projectileStat.max_damage *= 4m;
                inbound_projectileStat.average_damage = Decimal.Multiply(inbound_projectileStat.average_damage, (Decimal)(9.0m / 13m + 2.0m / 13m + 3.0m / 13m + 4m / 13m ));
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,  this);
            if (profile.skillList.Contains("03_18"))
            {
                switch (counter_instead_of_random_number)
                {
                    case 0:
                    case 1:
                    case 2:
                        inbound_projectile.damage = 0m;
                        counter_instead_of_random_number += 1;
                        break;
                    case 3:
                        counter_instead_of_random_number += 1;
                        break;
                    case 4:
                        counter_instead_of_random_number += 1;
                        inbound_projectile.damage *= 2m;
                        break;
                    case 5:
                        counter_instead_of_random_number += 1;
                        inbound_projectile.damage *= 3m;
                        break;
                    case 6:
                        counter_instead_of_random_number = 0;
                        inbound_projectile.damage *= 4m;
                        break;
                }
            }
            else if (profile.skillList.Contains("03_16"))
            {
                switch (counter_instead_of_random_number)
                {
                    case 0:
                        inbound_projectile.damage = 0m;
                        counter_instead_of_random_number += 1;
                        break;
                    case 1:
                    case 2:
                        counter_instead_of_random_number += 1;
                        break;
                    case 3:
                        inbound_projectile.damage *= 2m;
                        counter_instead_of_random_number += 1;
                        break;
                    case 4:
                        inbound_projectile.damage *= 3m;
                        counter_instead_of_random_number = 0;
                        break;
                }
            }
            else
            {
                switch (counter_instead_of_random_number)
                {
                    case 0:
                        inbound_projectile.damage = 0m;
                        counter_instead_of_random_number += 1;
                        break;
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                        counter_instead_of_random_number += 1;
                        break;
                    case 10:
                        inbound_projectile.damage *= 2m;
                        counter_instead_of_random_number += 1;
                        break;
                    case 11:
                        inbound_projectile.damage *= 3m;
                        counter_instead_of_random_number += 1;
                        break;
                    case 12:
                        inbound_projectile.damage *= 4m;
                        counter_instead_of_random_number = 0;
                        break;
                }
            }

            return inbound_projectile;
        }
    }
    class Item_016_Charge : Item
    {
        public Item_016_Charge(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            decimal magnification = profile.skillList.Contains("06_13") ? 1.3m : 1.2m;
            inbound_projectileStat.average_damage *= magnification;
            inbound_projectileStat.max_damage *= magnification;
            inbound_projectileStat.min_damage *= magnification;
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            decimal magnification = profile.skillList.Contains("06_13") ? 1.3m : 1.2m;
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                inbound_projectile.damage *= magnification;
            }
            return inbound_projectile;
        }
    }
    class Item_017_Return : Item
    {
        public Item_017_Return(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_018_Random_bounce : Item
    {
        public Item_018_Random_bounce(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_019_Richchet : Item
    {
        public Item_019_Richchet(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_020_Double_lifetime : Item
    {
        public Item_020_Double_lifetime(Thing[,] thing_layout) : base(thing_layout)
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
        public Item_021_Split_2_way(Thing[,] thing_layout) : base(thing_layout)
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
            if (inbound_projectileStat != null && inbound_projectileStat.Legendary_EnableGuideDamage && profile.skillList.Contains("06_17"))
            {
                inbound_projectileStat.average_damage *= 1.1m;
                inbound_projectileStat.max_damage *= 1.1m;
                inbound_projectileStat.min_damage *= 1.1m;
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
            if (inbound_projectile != null && inbound_projectile.Legendary_EnableGuideDamage && profile.skillList.Contains("06_17"))
            {
                inbound_projectile.damage *= 1.1m;
            }
            return inbound_projectile;
        }
    }
    class Item_022_Split_3_way : Item
    {
        public Item_022_Split_3_way(Thing[,] thing_layout) : base(thing_layout)
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
            if (inbound_projectileStat != null && inbound_projectileStat.Legendary_EnableGuideDamage && profile.skillList.Contains("06_17"))
            {
                inbound_projectileStat.average_damage *= 1.1m;
                inbound_projectileStat.max_damage *= 1.1m;
                inbound_projectileStat.min_damage *= 1.1m;
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
            if (inbound_projectile != null && inbound_projectile.Legendary_EnableGuideDamage && profile.skillList.Contains("06_17"))
            {
                inbound_projectile.damage *= 1.1m;
            }

            return inbound_projectile;
        }
    }
    class Item_023_Random_2_way : Item
    {
        Projectile to_left_projectile = null;
        Projectile to_right_projectile = null;
        int counter_instead_of_random_number = 0;
        public Item_023_Random_2_way(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToRIGHT = true;
            IsAccessToLEFT = true;
        }
        public override void ResetBeforeCalculateDamage()
        {
            base.ResetBeforeCalculateDamage();
            to_left_projectile = null;
            to_right_projectile = null;
            counter_instead_of_random_number = 0;

        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat;
            if (Access_to_rel_right == to_thing)
            {
                inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,  this);
            }
            else    //Access_to_rel_left == to_thing
            {
                inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,  this).Copy();
            }
            if (inbound_projectileStat != null && inbound_projectileStat.Legendary_EnableGuideDamage && profile.skillList.Contains("06_17"))
            {
                inbound_projectileStat.average_damage *= 1.1m;
                inbound_projectileStat.max_damage *= 1.1m;
                inbound_projectileStat.min_damage *= 1.1m;
            }
            if (profile.skillList.Contains("08_09"))
            {
                inbound_projectileStat.min_damage *= 3m;
                inbound_projectileStat.max_damage *= 3m;
                inbound_projectileStat.average_damage *= 3m;
            }
            else
            {
                inbound_projectileStat.min_damage *= 2m;
                inbound_projectileStat.max_damage *= 2m;
                inbound_projectileStat.average_damage *= 2m;
            }
            if (profile.skillList.Contains("09_08"))
            {
                    inbound_projectileStat.magnification *= 0.05m * 1m + 0.95m / 2m;
            }else
            {
                inbound_projectileStat.magnification /= 2m;
            }
            return inbound_projectileStat;


        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            if (Access_to_rel_right == to_thing && to_right_projectile == null || Access_to_rel_left == to_thing && to_left_projectile == null)
            {
                var projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,  this);
                if (profile.skillList.Contains("08_09"))
                {
                    projectile.damage *= 3m;
                }
                else
                {
                    projectile.damage *= 2m;
                }
                if (projectile != null && projectile.Legendary_EnableGuideDamage && profile.skillList.Contains("06_17"))
                {
                    projectile.damage *= 1.1m;
                }
                if (profile.skillList.Contains("09_08") && rand.Next(0, 100) < 5)
                {
                    to_right_projectile = projectile;
                    to_left_projectile = projectile.Copy();
                }
                else
                {
                    if(counter_instead_of_random_number == 0)
                    {
                        to_right_projectile = projectile;
                        to_left_projectile = null;
                        counter_instead_of_random_number += 1;
                    }else{
                        to_right_projectile = null;
                        to_left_projectile = projectile;
                        counter_instead_of_random_number = 0;
                    }
                }
            }
            Projectile tmp;
            if (Access_to_rel_right == to_thing)
            {
                (tmp, to_right_projectile) = (to_right_projectile, null);
                return tmp;
            }
            else if (Access_to_rel_left == to_thing)
            {
                (tmp, to_left_projectile) = (to_left_projectile, null);
                return tmp;
            }
            throw new NotImplementedException();
        }
    }
    class Item_024_Random_3_way : Item
    {
        Projectile to_top_projectile = null;
        Projectile to_left_projectile = null;
        Projectile to_right_projectile = null;
        int counter_instead_of_random_number = 0;
        public Item_024_Random_3_way(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsAccessToRIGHT = true;
            IsAccessToLEFT = true;
        }
        public override void ResetBeforeCalculateDamage()
        {
            base.ResetBeforeCalculateDamage();
            to_top_projectile = null;
            to_left_projectile = null;
            to_right_projectile = null;
            counter_instead_of_random_number = 0;

        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat;
            if (Access_to_rel_top == to_thing)
            {
                inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,  this);
            }
            else if (Access_to_rel_right == to_thing)
            {
                inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,  this).Copy();
            }
            else    //Access_to_rel_left == to_thing
            {
                inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,  this).Copy();
            }
            if (inbound_projectileStat != null && inbound_projectileStat.Legendary_EnableGuideDamage && profile.skillList.Contains("06_17"))
            {
                inbound_projectileStat.average_damage *= 1.1m;
                inbound_projectileStat.max_damage *= 1.1m;
                inbound_projectileStat.min_damage *= 1.1m;
            }
            if (profile.skillList.Contains("08_07"))
            {
                inbound_projectileStat.min_damage *= 4m;
                inbound_projectileStat.max_damage *= 4m;
                inbound_projectileStat.average_damage *= 4m;
            }
            else
            {
                inbound_projectileStat.min_damage *= 3m;
                inbound_projectileStat.max_damage *= 3m;
                inbound_projectileStat.average_damage *= 3m;
            }
            if (profile.skillList.Contains("09_06"))
            {
                    inbound_projectileStat.magnification *= 0.05m * 1m + 0.95m / 3m;
            }else
            {
                inbound_projectileStat.magnification /= 3m;
            }
            return inbound_projectileStat;

        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            if (Access_to_rel_right == to_thing && to_right_projectile == null || Access_to_rel_left == to_thing && to_left_projectile == null || Access_to_rel_top == to_thing && to_top_projectile == null)
            {
                var projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,  this);
                if (profile.skillList.Contains("08_07"))
                {
                    projectile.damage *= 4m;
                }
                else
                {
                    projectile.damage *= 3m;
                }
                if (projectile != null && projectile.Legendary_EnableGuideDamage && profile.skillList.Contains("06_17"))
                {
                    projectile.damage *= 1.1m;
                }
                if (profile.skillList.Contains("09_06") && rand.Next(0, 100) < 5)
                {
                    to_top_projectile = projectile;
                    to_right_projectile = projectile.Copy();
                    to_left_projectile = projectile.Copy();
                }
                else
                {
                    if(counter_instead_of_random_number == 0)
                    {
                        to_top_projectile = projectile;
                        to_right_projectile = null;
                        to_left_projectile = null;
                        counter_instead_of_random_number += 1;
                    }else if(counter_instead_of_random_number == 1)
                    {
                        to_top_projectile = null;
                        to_right_projectile = projectile;
                        to_left_projectile = null;
                        counter_instead_of_random_number += 1;
                    }else{
                        to_top_projectile = null;
                        to_right_projectile = null;
                        to_left_projectile = projectile;
                        counter_instead_of_random_number = 0;
                    }
                }
            }
            Projectile tmp;
            if (Access_to_rel_right == to_thing)
            {
                (tmp, to_right_projectile) = (to_right_projectile, null);
                return tmp;
            }
            else if (Access_to_rel_left == to_thing)
            {
                (tmp, to_left_projectile) = (to_left_projectile, null);
                return tmp;
            }else if (Access_to_rel_top == to_thing)
            {
                (tmp, to_top_projectile) = (to_top_projectile, null);
                return tmp;
            }
            throw new NotImplementedException();
        }
    }
    class Item_025_Remaining_damage : Item
    {
        public Item_025_Remaining_damage(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_026_Pierce : Item
    {
        public Item_026_Pierce(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.pierce_count += 1;
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                inbound_projectile.pierce_count += 1;
            }
            return inbound_projectile;
        }
    }
    class Item_027_Round_area : Item
    {
        public Item_027_Round_area(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.round_area_count += 1;
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                inbound_projectile.round_area_count += 1;
            }
            return inbound_projectile;
        }
    }
    class Item_028_Rectangle_area : Item
    {
        public Item_028_Rectangle_area(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.rectangle_area_count += 1;
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                inbound_projectile.rectangle_area_count += 1;
            }
            return inbound_projectile;
        }
    }
    class Item_029_Attraction : Item
    {
        public Item_029_Attraction(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_030_Align_direction : Item
    {
        public Item_030_Align_direction(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_031_Align_to_ship : Item
    {
        public Item_031_Align_to_ship(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_032_Add_projectile : Item
    {
        public Item_032_Add_projectile(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            if(profile.skillList.Contains("07_08"))
            {
                inbound_projectileStat.magnification  += inbound_projectileStat.magnification * 0.1m + 1m * 0.9m;
            }else
            {
                inbound_projectileStat.magnification += 1m;
            }
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (inbound_projectile != null)
            {
                if(profile.skillList.Contains("07_08") && rand.Next(0,100) < 10)
                {
                    inbound_projectile.magnification *= 2m;
                }else
                {
                    inbound_projectile.magnification += 1m;
                }
            }
            return inbound_projectile;
        }
    }
    class Item_033_Fly_forward : Item
    {
        public Item_033_Fly_forward(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_034_Fly_sideways : Item
    {
        public Item_034_Fly_sideways(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_035_Money_crossing : Crossing
    {
        public Item_035_Money_crossing(Thing[,] thing_layout) : base(thing_layout)
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
    class Item_036_Damage_crossing : Crossing
    {
        [JsonIgnore]
        public Dictionary<ProjectileStat, ProjectileStat> projectileStats_history = new();

        [JsonIgnore]
        public Dictionary<Projectile, Projectile> projectile_history = new();

        public override void ResetBeforeCalculateDamage()
        {
            base.ResetBeforeCalculateDamage();
            projectileStats_history.Clear();
            projectile_history.Clear();
        }
        public Item_036_Damage_crossing(Thing[,] thing_layout) : base(thing_layout)
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
                    inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,  this);
                    foreach (var self_and_ancestor in inbound_projectileStat.self_and_ancestors)
                    {
                        if (projectileStats_history.TryGetValue(self_and_ancestor, out ProjectileStat his_projectileStats))
                        {
                            if (profile.skillList.Contains("07_06"))
                            {
                                inbound_projectileStat.average_damage += his_projectileStats.average_damage * 2m;
                                inbound_projectileStat.min_damage += his_projectileStats.min_damage * 2m;
                                inbound_projectileStat.max_damage += his_projectileStats.max_damage * 2m;
                            }
                            else
                            {
                                inbound_projectileStat.average_damage += his_projectileStats.average_damage;
                                inbound_projectileStat.min_damage += his_projectileStats.min_damage;
                                inbound_projectileStat.max_damage += his_projectileStats.max_damage;
                            }
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
                        inbound_projectileStat = Access_from_rel_right.GetOutboundProjectileStat(shipParameter, profile,  this);
                }
                else if (Access_to_rel_right == to_thing)
                {
                    if (Access_from_rel_left != null)
                        inbound_projectileStat = Access_from_rel_left.GetOutboundProjectileStat(shipParameter, profile,  this);
                }
                var projectileStat = inbound_projectileStat;
                projectileStats_history[projectileStat] = projectileStat.Copy();
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
                    inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,  this);
                    foreach (var self_and_ancestor in inbound_projectile.self_and_ancestors)
                    {
                        if (projectile_history.TryGetValue(self_and_ancestor, out Projectile his_projectile))
                        {
                            if (profile.skillList.Contains("07_06"))
                            {
                                inbound_projectile.damage += his_projectile.damage * 2m;
                            }
                            else
                            {
                                inbound_projectile.damage += his_projectile.damage;
                            }
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
                        inbound_projectile = Access_from_rel_right.GetOutboundProjectile(shipParameter, profile,  this);
                }
                else if (Access_to_rel_right == to_thing)
                {
                    if (Access_from_rel_left != null)
                        inbound_projectile = Access_from_rel_left.GetOutboundProjectile(shipParameter, profile,  this);
                }
                projectile_history[inbound_projectile] = inbound_projectile.Copy();
            }
            return inbound_projectile;
        }
    }
    class Item_101_Tier_damage : Item
    {
        public Item_101_Tier_damage(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsLegendary = true;
        }
        private int Calc_additional_damage(Profile profile)
        {
            int additional = (int)Decimal.Round(Decimal.Multiply(profile.Highest_Reached_Tier_in_World_Map, 0.1m), MidpointRounding.AwayFromZero);
            if(profile.skillList.Contains("08_17"))
            {
                additional += (int)Decimal.Round(Decimal.Multiply(profile.Highest_Cleared_Tier_in_World_Map , 0.05m), MidpointRounding.AwayFromZero);
            }
            if(profile.skillList.Contains("09_16"))
            {
                decimal hour = profile.Play_Hour > 100 ? 100:profile.Play_Hour;
                additional += (int)Decimal.Round(Decimal.Multiply(hour, 2m), MidpointRounding.AwayFromZero);
            }
            return additional;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            int additional = Calc_additional_damage(profile);
            inbound_projectileStat.average_damage += additional;
            inbound_projectileStat.max_damage += additional;
            inbound_projectileStat.min_damage += additional;

            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            int additional = Calc_additional_damage(profile);
            inbound_projectile.damage += additional;

            return inbound_projectile;
        }
    }
    class Item_102_More_when_lower : Item
    {
        [JsonIgnore]
        private decimal? last_damage = null;

        public override void ResetBeforeCalculateDamage()
        {
            base.ResetBeforeCalculateDamage();
            last_damage = null;
        }
        public Item_102_More_when_lower(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsLegendary = true;
        }

       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            // Since the average value of projectile damage cannot be calculated by a mathematical formula,
            // this program make a projectile 1000 times and calculate the average damage.
            const int Count = 1000;
            decimal total_damage = new();
            decimal max_damage = new();
            decimal? min_damage = null;
            Projectile projectile = new();
            int i;
            for (i = 0; i < Count; i++)
            {
                projectile = GetOutboundProjectile(shipParameter, profile, this);
                if (projectile != null)
                {
                    total_damage += projectile.damage;
                    max_damage = max_damage < projectile.damage ? projectile.damage : max_damage;
                    min_damage = (min_damage == null || min_damage > projectile.damage) ? projectile.damage : min_damage;
                }
            }
            ProjectileStat inbound_projectileStat = new();
            inbound_projectileStat.average_damage = total_damage / i;
            inbound_projectileStat.max_damage = max_damage;
            inbound_projectileStat.min_damage = (decimal)min_damage;
            inbound_projectileStat.magnification = projectile.magnification;
            inbound_projectileStat.speed = projectile.speed;
            inbound_projectileStat.lifetime = projectile.lifetime;
            inbound_projectileStat.Legendary_EnableGuideDamage = projectile.Legendary_EnableGuideDamage;
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            if (last_damage != null)
            {
                if (last_damage > inbound_projectile.damage) inbound_projectile.damage *= profile.skillList.Contains("02_07") ? 8m : 4m;

            }
            last_damage = inbound_projectile.damage;
            return inbound_projectile;
        }
    }
    class Item_103_Late_damage : Item
    {
        public Item_103_Late_damage(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsLegendary = true;
        }
        private decimal Calc_late_damage_magnification(HashSet<string> skillList,Decimal lifetime)
        {
            if(skillList.Contains("01_14") && skillList.Contains("00_15"))
            {
                return (lifetime + 3.2m) / lifetime;
            }else if(skillList.Contains("01_14"))
            {
                return (lifetime + 1.8m) / lifetime;
            }else if(skillList.Contains("00_15"))
            {
                return (lifetime +2m) / lifetime;
            }else
            {
                return (lifetime +1m) / lifetime;
            }
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            if(profile.skillList.Contains("01_14")){
                inbound_projectileStat.lifetime /= 2m;
            }
            if(profile.skillList.Contains("00_15")){
                inbound_projectileStat.average_damage *= 0.8m;
                inbound_projectileStat.max_damage *= 0.8m;
                inbound_projectileStat.min_damage *= 0.8m;
            }
            decimal late_damage_magnification = Calc_late_damage_magnification(profile.skillList,inbound_projectileStat.lifetime);
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
                if(profile.skillList.Contains("01_14")){
                    inbound_projectile.lifetime /= 2m;
                }
                if(profile.skillList.Contains("00_15")){
                    inbound_projectile.damage *= 0.8m;
                }
                decimal late_damage_magnification = Calc_late_damage_magnification(profile.skillList,inbound_projectile.lifetime);
                inbound_projectile.damage *= late_damage_magnification;
            }
            return inbound_projectile;
        }
    }
    class Item_104_Unused_tile : Item
    {
        public Item_104_Unused_tile(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsLegendary = true;
        }
        private decimal Calc_additional_damage_magnification(HashSet<string> skillList)
        {
            int num_unused_tiles = 0;
            var thing_1dim_layout = thing_layout.Cast<Thing>();
            IEnumerable<Thing> IEnull = thing_1dim_layout.Where(thing => thing.GetType().Name == "Parts_Null");
            num_unused_tiles = IEnull.Count<Thing>();
            if(skillList.Contains("08_05"))
            {
                IEnull = thing_1dim_layout.Where(thing => thing.IsLegendary == true);
                num_unused_tiles += IEnull.Count<Thing>();
            }
            if(skillList.Contains("09_04"))
            {
                IEnull = thing_1dim_layout.Where(thing => thing.IsGuide == true);
                num_unused_tiles += IEnull.Count<Thing>();
            }
            return 1m + 0.1m * num_unused_tiles;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            //ProjectileStat inbound_projectileStat = null;

            decimal additional_damage_magnification = Calc_additional_damage_magnification(profile.skillList);
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.average_damage *= additional_damage_magnification;
            inbound_projectileStat.max_damage *= additional_damage_magnification;
            inbound_projectileStat.min_damage *= additional_damage_magnification;
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            //Projectile inbound_projectile = null;

            decimal additional_damage_magnification = Calc_additional_damage_magnification(profile.skillList);
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
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
        public Item_105_Slow_damage(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsLegendary = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,  this);
            inbound_projectileStat.slowdamage = true;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,  this);
            inbound_projectile.slowdamage = true;
            return inbound_projectile;
        }
    }
    class Item_106_Combine10 : Item
    {
        int count = 0;
        decimal accumulation_damage = 0m;
        decimal last_damage = 0m;

        public Item_106_Combine10(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsLegendary = true;
        }
        public override void ResetBeforeCalculateDamage()
        {
            base.ResetBeforeCalculateDamage();
            accumulation_damage = 0m;
            last_damage = 0m;
            count = 0;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat;
            if (profile.skillList.Contains("02_17"))
            {
                inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,  this);
                inbound_projectileStat.average_damage *= 12m;
                inbound_projectileStat.max_damage *= 12m;
                inbound_projectileStat.min_damage *= 12m;
                inbound_projectileStat.magnification /= 6m;
            }
            else if (profile.skillList.Contains("02_19"))
            {
                // Since the average value of projectile damage cannot be calculated by a mathematical formula,
                // this program make a projectile 1000 times and calculate the average damage.
                const int Count = 1000;
                decimal total_damage = new();
                decimal max_damage = new();
                decimal? min_damage = null;
                Projectile projectile = new();
                int j = 0;
                for (int i = 0; i < Count; i++)
                {
                    projectile = GetOutboundProjectile(shipParameter, profile,  this);
                    if(projectile != null)
                    {
                        j += 1;
	                    total_damage += projectile.damage;
	                    max_damage = max_damage < projectile.damage ? projectile.damage : max_damage;
	                    min_damage = (min_damage == null || min_damage > projectile.damage) ? projectile.damage : min_damage;
                    }
                }
                inbound_projectileStat = new();
                inbound_projectileStat.average_damage = total_damage / j;
                inbound_projectileStat.max_damage = max_damage;
                inbound_projectileStat.min_damage = (decimal)min_damage;
                inbound_projectileStat.magnification = projectile.magnification / (profile.skillList.Contains("02_17") ? 6m : 10m) ;
                inbound_projectileStat.speed = projectile.speed;
                inbound_projectileStat.lifetime = projectile.lifetime;
                inbound_projectileStat.Legendary_EnableGuideDamage = projectile.Legendary_EnableGuideDamage;
                return inbound_projectileStat;
            }
            else
            {
                inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,  this);
                inbound_projectileStat.average_damage *= 20m;
                inbound_projectileStat.max_damage *= 20m;
                inbound_projectileStat.min_damage *= 20m;
                inbound_projectileStat.magnification /= 10m;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,  this);
            count += 1;
            if(inbound_projectile != null)
            {
                if(profile.skillList.Contains("02_19"))
                {
                    if(last_damage > inbound_projectile.damage)
                    {
                        accumulation_damage += last_damage * 2m;
                    }
                    else
                    {
                        accumulation_damage += inbound_projectile.damage * 2m;
                    }
                    last_damage = inbound_projectile.damage;
                }
                else
                {
                    accumulation_damage += inbound_projectile.damage * 2m;
                }
            }
            if(count >= (profile.skillList.Contains("02_17") ? 6 : 10))
            {
                inbound_projectile.damage = accumulation_damage;
                accumulation_damage = 0m;
                count = 0;
                return inbound_projectile;
            }
            else
            {
                return null;
            }
            /*
            Projectile inbound_projectile = null;
            count += 1;
            if (count >= (profile.SkillList.Contains("02_17") ? 6 : 10))
            {
                inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,  this);
                if (inbound_projectile != null)
                {
                    inbound_projectile.damage *= (profile.SkillList.Contains("02_17") ? 12m : 20m);
                }
                count = 0;
            }
            return inbound_projectile;
            */
        }
    }

    
    class Item_107_Change_Direction : Item
    {
        public Item_107_Change_Direction(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsLegendary = true;
        }
    }
    class Item_108_Guide_Damage : Item
    {
        public Item_108_Guide_Damage(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsLegendary = true;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.Legendary_EnableGuideDamage = true;
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            inbound_projectile.Legendary_EnableGuideDamage = true;

            return inbound_projectile;
        }
    }
    class Item_109_Add_100_damage : Item
    {
        public Item_109_Add_100_damage(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsLegendary = true;
        }
        private decimal SkillTree_Add5damage(HashSet<string> skillList)
        {
            int step = 0;
            if (skillList.Contains("00_07"))
            {
                Thing now_thing = this;
                while(true)
                {
                    Thing to_thing = now_thing.Access_from;
                    if(to_thing == null)
                    {
                        step = 0;
                        break;
                    }
                    step += (int)(now_thing.GetLocation().GetDistance(to_thing.GetLocation()));
                    if (to_thing is Parts_03_ProjectileGenerator) break;
                    now_thing = to_thing;
                }
            }
            return 5m * step;
        }
        private static decimal SkillTree_Add30damage(HashSet<string> skillList)
        {
            return skillList.Contains("01_08") ? 30m : 0m;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            decimal skillTree_Add5damage = SkillTree_Add5damage(profile.skillList);
            decimal skillTree_Add30damage = SkillTree_Add30damage(profile.skillList);
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.average_damage += 100m + skillTree_Add5damage + skillTree_Add30damage;
            inbound_projectileStat.max_damage += 100m + skillTree_Add5damage + skillTree_Add30damage;
            inbound_projectileStat.min_damage += 100m + skillTree_Add5damage + skillTree_Add30damage;
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            decimal skillTree_Add5damage = SkillTree_Add5damage(profile.skillList);
            decimal skillTree_Add30damage = SkillTree_Add30damage(profile.skillList);
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
            inbound_projectile.damage += 100m + skillTree_Add5damage + skillTree_Add30damage;

            return inbound_projectile;
        }
    }
    class Item_110_Ejection_Damage : Item
    {
        public Item_110_Ejection_Damage(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsLegendary = true;
        }
        /*
        private decimal Count_Unused_Ejection()
        {
            var thing_1dim_layout = thing_layout.Cast<Thing>();
            IEnumerable<Thing> IEunusedEjection = thing_1dim_layout.Where(thing => thing.GetType().Name == "Parts_02_Ejector").Where(thing => thing.Access_from_abs_top == null).Where(thing => thing.Access_from_abs_right == null).Where(thing => thing.Access_from_abs_down == null).Where(thing => thing.Access_from_abs_left == null);
            return IEunusedEjection.Count<Thing>();
        }
        */
        private decimal Calc_additional_damage(HashSet<string> skillList)
        {
            var thing_1dim_layout = thing_layout.Cast<Thing>();
            IEnumerable<Thing> IEunusedEjection = thing_1dim_layout.Where(thing => thing.GetType().Name == "Parts_02_Ejector").Where(thing => thing.Access_from_abs_top == null).Where(thing => thing.Access_from_abs_right == null).Where(thing => thing.Access_from_abs_down == null).Where(thing => thing.Access_from_abs_left == null);
            int unused_ejection = IEunusedEjection.Count<Thing>();
            decimal additional_damage =  unused_ejection * 10m;
            if(skillList.Contains("07_18"))
            {
                decimal magnification = unused_ejection / 2m;
                if(magnification < 1m)
                {
                    magnification = 1m;
                }else if(magnification > 3m)
                {
                    magnification = 3m;
                }
                additional_damage *= magnification;
            }
            return additional_damage;
        }
       public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            //ProjectileStat inbound_projectileStat = null;

            decimal additional_damage = Calc_additional_damage(profile.skillList);
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, this);
            inbound_projectileStat.average_damage += additional_damage;
            inbound_projectileStat.max_damage += additional_damage;
            inbound_projectileStat.min_damage += additional_damage;
            return inbound_projectileStat;
        }
       public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            //Projectile inbound_projectile = null;

            decimal additional_damage = Calc_additional_damage(profile.skillList);
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this);
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
        public Item_111_Few_Shot_Damage(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsLegendary = true;
        }
    }
    class Item_112_Clone : Item
    {
        public Item_112_Clone(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsLegendary = true;
            IsLegendary = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,  this);
            if (profile.skillList.Contains("07_04"))
            {
                inbound_projectileStat.magnification *= 2.2m;
            }
            else
            {
                inbound_projectileStat.magnification *= 2m;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            //Projectile inbound_projectile = null;

            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,  this);
            if (inbound_projectile != null)
            {
                if (profile.skillList.Contains("07_04") && rand.Next(0,100) < 20)
                {
                    inbound_projectile.magnification *= 3m;
                }
                else
                {
                    inbound_projectile.magnification *= 2m;
                }
            }

            return inbound_projectile;
        }
    }
}
