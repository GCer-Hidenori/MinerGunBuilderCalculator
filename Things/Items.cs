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
        private static decimal SkillTree_Add5damage(SkillTree skillTree)
        {
            return skillTree.v03_12_add_5_damage ? 5m : 0m;
        }
        public Item_001_Guide_right(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToRIGHT = true;
            IsGuide = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            inbound_projectileStat.average_damage += SkillTree_Add5damage(skillTree);
            inbound_projectileStat.max_damage += SkillTree_Add5damage(skillTree);
            inbound_projectileStat.min_damage += SkillTree_Add5damage(skillTree);
            if (inbound_projectileStat.Legendary_EnableGuideDamage)
            {
                inbound_projectileStat.average_damage *= 1.1m;
                inbound_projectileStat.max_damage *= 1.1m;
                inbound_projectileStat.min_damage *= 1.1m;
            }

            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
            inbound_projectile.damage += SkillTree_Add5damage(skillTree);
            if (inbound_projectile.Legendary_EnableGuideDamage)
            {
                inbound_projectile.damage *= 1.1m;
            }
            return inbound_projectile;
        }
    }
    class Item_002_Guide_left : Item
    {
        private static decimal SkillTree_Add5damage(SkillTree skillTree)
        {
            return skillTree.v04_11_add_5_damage ? 5m : 0m;
        }
        public Item_002_Guide_left(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToLEFT = true;
            IsGuide = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            inbound_projectileStat.average_damage += SkillTree_Add5damage(skillTree);
            inbound_projectileStat.max_damage += SkillTree_Add5damage(skillTree);
            inbound_projectileStat.min_damage += SkillTree_Add5damage(skillTree);
            if (inbound_projectileStat.Legendary_EnableGuideDamage)
            {
                inbound_projectileStat.average_damage *= 1.1m;
                inbound_projectileStat.max_damage *= 1.1m;
                inbound_projectileStat.min_damage *= 1.1m;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
            inbound_projectile.damage += SkillTree_Add5damage(skillTree);
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, skillTree, this);
            decimal additional_damage = 0m;
            if (skillTree.v05_08_more_damage)
            {
                additional_damage = 5m;
            }
            if (skillTree.v05_00_more_damage)
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
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, skillTree, this);
            if (inbound_projectile != null)
            {
                decimal additional_damage = 0m;
                if (skillTree.v05_08_more_damage)
                {
                    additional_damage = 5m;
                }
                if (skillTree.v05_00_more_damage)
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            inbound_projectileStat.speed += 1m;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            if(skillTree.v06_11_more_damage){
                inbound_projectileStat.average_damage *= 1.25m;
                inbound_projectileStat.max_damage *= 1.5m;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
            if (inbound_projectile != null)
            {
                if (skillTree.v06_11_more_damage)
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            if(skillTree.v07_10_more_damage){
                inbound_projectileStat.average_damage *= 1.3m;
                inbound_projectileStat.max_damage *= 1.6m;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
            if (inbound_projectile != null)
            {
                if (skillTree.v07_10_more_damage)
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            if(skillTree.v07_12_more_damage){
                inbound_projectileStat.average_damage *= 1.25m;
                inbound_projectileStat.max_damage *= 1.5m;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
            if (inbound_projectile != null)
            {
                if (skillTree.v07_12_more_damage)
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            if(skillTree.v08_11_more_damage){
                inbound_projectileStat.average_damage *= 1.1m;
                inbound_projectileStat.max_damage *= 1.2m;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
            if (inbound_projectile != null)
            {
                if (skillTree.v08_11_more_damage)
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, skillTree, this);
            if (skillTree.v05_06_more_damage)
            {
                inbound_projectileStat.average_damage *= 1.4m;
                inbound_projectileStat.max_damage *= 1.4m;
                inbound_projectileStat.min_damage *= 1.4m;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, skillTree, this);
            if (skillTree.v05_06_more_damage)
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, skillTree, this);
            if (skillTree.v03_08_more_damage)
            {
                inbound_projectileStat.average_damage *= 1.3m;
                inbound_projectileStat.max_damage *= 1.6m;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, skillTree, this);
            if (skillTree.v03_08_more_damage)
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, skillTree, this);
            if (skillTree.v04_05_more_damage)
            {
                inbound_projectileStat.average_damage *= 1.4m;
                inbound_projectileStat.max_damage *= 1.4m;
                inbound_projectileStat.min_damage *= 1.4m;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, skillTree, this);
            if (skillTree.v04_05_more_damage)
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            inbound_projectileStat.speed /= 2m;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
            if (inbound_projectile != null)
            {
                inbound_projectile.speed /= 2m;
            }
            return inbound_projectile;
        }
    }
    class Item_013_Criticalx2 : Item
    {
        private static decimal SkillTree_IncreaseChance_magnification(SkillTree skillTree)
        {
            decimal hit_rate,magnification;
            if(skillTree.v02_13_increase_chance)
            {
                hit_rate = 0.4m;
            }else
            {
                hit_rate = 0.3m;
            }
            if(skillTree.v01_12_high_multiplier)
            {
                magnification = 2.5m;
            }
            else
            {
                magnification = 2m;
            }
            //return skillTree.v02_13_increase_chance ? 1.4m : (decimal)(1.0+1.0/3);
            return (1.0m-hit_rate) + hit_rate * magnification;
        }
        private static int SkillTree_IncreaseChance_Chance(SkillTree skillTree)
        {
            return skillTree.v02_13_increase_chance ? 7 : 0;
        }
        public Item_013_Criticalx2(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            inbound_projectileStat.max_damage *= skillTree.v01_12_high_multiplier ? 2.5m : 2m;
            inbound_projectileStat.average_damage = Decimal.Multiply(inbound_projectileStat.average_damage, SkillTree_IncreaseChance_magnification(skillTree));
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
            if (rand.Next(0, 100) < (33m + SkillTree_IncreaseChance_Chance(skillTree))) inbound_projectile.damage *= skillTree.v01_12_high_multiplier ? 2.5m : 2m;
            return inbound_projectile;
        }
    }
    class Item_014_Criticalx10 : Item
    {
        private static decimal SkillTree_IncreaseChance_magnification(SkillTree skillTree)
        {
            return skillTree.v02_15_increase_chance ? (decimal)(1m-0.06m+0.06m * (10m+SkillTree_High_Times(skillTree))) : (decimal)(1m - 0.04m + 0.04m * (10m + SkillTree_High_Times(skillTree)));
        }
        private static int SkillTree_IncreaseChance_Chance(SkillTree skillTree)
        {
            return skillTree.v02_15_increase_chance ? 2 : 0;
        }
        private static decimal SkillTree_High_Times(SkillTree skillTree)
        {
            return skillTree.v01_16_high_times ? 2m : 0m;
        }
        public Item_014_Criticalx10(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            inbound_projectileStat.max_damage *= (10m + SkillTree_High_Times(skillTree));
            inbound_projectileStat.average_damage = Decimal.Multiply(inbound_projectileStat.average_damage, SkillTree_IncreaseChance_magnification(skillTree));
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            //Projectile inbound_projectile = null;

            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
            if (rand.Next(0, 100) < (4 + SkillTree_IncreaseChance_Chance(skillTree))) inbound_projectile.damage *= 10m;
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, skillTree, this);
            inbound_projectileStat.min_damage = 0m;
            if (skillTree.v03_18_high_multiplier)
            {
                inbound_projectileStat.max_damage *= 4m;
                inbound_projectileStat.average_damage = Decimal.Multiply(inbound_projectileStat.average_damage, (Decimal)( (1.0m+2.0m+3.0m + 4m)/7m));
            }
            else if (skillTree.v03_16_high_multiplier)
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
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, skillTree, this);
            if (skillTree.v03_18_high_multiplier)
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
            else if (skillTree.v03_16_high_multiplier)
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
                        inbound_projectile.damage *= 2;
                        counter_instead_of_random_number += 1;
                        break;
                    case 4:
                        inbound_projectile.damage *= 3;
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            decimal magnification = skillTree.v06_13_high_multiplier ? 1.3m : 1.2m;
            inbound_projectileStat.average_damage *= magnification;
            inbound_projectileStat.max_damage *= magnification;
            inbound_projectileStat.min_damage *= magnification;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            decimal magnification = skillTree.v06_13_high_multiplier ? 1.3m : 1.2m;
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = null;

            if (Access_to_rel_right == to_thing)
            {
                inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            }
            else if (Access_to_rel_left == to_thing)
            {
                var projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
                inbound_projectileStat = projectileStat.Copy();
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = null;

            if (Access_to_rel_right == to_thing)
            {
                inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
            }
            else if (Access_to_rel_left == to_thing)
            {
                var projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
                inbound_projectile = projectile.Copy();
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = null;

            if (Access_to_rel_top == to_thing)
            {
                inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            }
            else if (Access_to_rel_right == to_thing || Access_to_rel_left == to_thing)
            {
                var projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
                inbound_projectileStat = projectileStat.Copy();
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = null;

            if (Access_to_rel_top == to_thing)
            {
                inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
            }
            else if (Access_to_rel_right == to_thing || Access_to_rel_left == to_thing)
            {
                var projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
                inbound_projectile = projectile.Copy();
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = null;
            if (Access_to_rel_right == to_thing)
            {
                inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, skillTree, this);
            }
            else    //Access_to_rel_left == to_thing
            {
                inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, skillTree, this).Copy();
            }
            if (skillTree.v08_09_high_multiplier)
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
            if (skillTree.v09_08_chance_to_split)
            {
                    inbound_projectileStat.magnification *= 0.05m * 1m + 0.95m / 2m;
            }else
            {
                inbound_projectileStat.magnification /= 2m;
            }
            return inbound_projectileStat;


        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            if (Access_to_rel_right == to_thing && to_right_projectile == null || Access_to_rel_left == to_thing && to_left_projectile == null)
            {
                var projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, skillTree, this);
                if (skillTree.v08_09_high_multiplier)
                {
                    projectile.damage *= 3m;
                }
                else
                {
                    projectile.damage *= 2m;
                }
                if (skillTree.v09_08_chance_to_split && rand.Next(0, 100) < 5)
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = null;
            if (Access_to_rel_top == to_thing)
            {
                inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, skillTree, this);
            }
            else if (Access_to_rel_right == to_thing)
            {
                inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, skillTree, this).Copy();
            }
            else    //Access_to_rel_left == to_thing
            {
                inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, skillTree, this).Copy();
            }
            if (skillTree.v08_07_high_multiplier)
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
            if (skillTree.v09_06_chance_to_split)
            {
                    inbound_projectileStat.magnification *= 0.05m * 1m + 0.95m / 3m;
            }else
            {
                inbound_projectileStat.magnification /= 3m;
            }
            return inbound_projectileStat;

        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            if (Access_to_rel_right == to_thing && to_right_projectile == null || Access_to_rel_left == to_thing && to_left_projectile == null || Access_to_rel_top == to_thing && to_top_projectile == null)
            {
                var projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, skillTree, this);
                if (skillTree.v08_07_high_multiplier)
                {
                    projectile.damage *= 4m;
                }
                else
                {
                    projectile.damage *= 3m;
                }
                if (skillTree.v09_06_chance_to_split && rand.Next(0, 100) < 5)
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
    }
    class Item_027_Round_area : Item
    {
        public Item_027_Round_area(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
        }
    }
    class Item_028_Rectangle_area : Item
    {
        public Item_028_Rectangle_area(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            if(skillTree.v07_08_clone)
            {
                inbound_projectileStat.magnification  += inbound_projectileStat.magnification * 0.1m + 1m * 0.9m;
            }else
            {
                inbound_projectileStat.magnification += 1m;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
            if (inbound_projectile != null)
            {
                if(skillTree.v07_08_clone && rand.Next(0,100) < 10)
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
    class Item_035_Money_crossing : Item
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = null;

            if (Access_to_rel_top == to_thing)
            {
                if (Access_from_rel_down != null)
                {
                    inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
                }
            }
            else if (Access_to_rel_left == to_thing || Access_to_rel_right == to_thing)
            {
                if (Access_to_rel_left == to_thing)
                {
                    if (Access_from_rel_right != null)
                        inbound_projectileStat = Access_from_rel_right.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
                }
                else if (Access_to_rel_right == to_thing)
                {
                    if (Access_from_rel_left != null)
                        inbound_projectileStat = Access_from_rel_left.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
                }
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = null;

            if (Access_to_rel_top == to_thing)
            {
                if (Access_from_rel_down != null)
                {
                    inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
                }

            }
            else if (Access_to_rel_left == to_thing || Access_to_rel_right == to_thing)
            {
                if (Access_to_rel_left == to_thing)
                {
                    if (Access_from_rel_right != null)
                        inbound_projectile = Access_from_rel_right.GetOutboundProjectile(shipParameter, profile,skillTree, this);
                }
                else if (Access_to_rel_right == to_thing)
                {
                    if (Access_from_rel_left != null)
                        inbound_projectile = Access_from_rel_left.GetOutboundProjectile(shipParameter, profile,skillTree, this);
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = null;

            if (Access_to_rel_top == to_thing)
            {
                if (Access_from_rel_down != null)
                {
                    inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
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
                        inbound_projectileStat = Access_from_rel_right.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
                }
                else if (Access_to_rel_right == to_thing)
                {
                    if (Access_from_rel_left != null)
                        inbound_projectileStat = Access_from_rel_left.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
                }
                var projectileStat = inbound_projectileStat;
                projectileStats_history[projectileStat] = projectileStat.Copy();
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = null;

            if (Access_to_rel_top == to_thing)
            {
                if (Access_from_rel_down != null)
                {
                    inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
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
                        inbound_projectile = Access_from_rel_right.GetOutboundProjectile(shipParameter, profile,skillTree, this);
                }
                else if (Access_to_rel_right == to_thing)
                {
                    if (Access_from_rel_left != null)
                        inbound_projectile = Access_from_rel_left.GetOutboundProjectile(shipParameter, profile,skillTree, this);
                }
                projectile_history[inbound_projectile] = inbound_projectile;
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
        private int Calc_additional_damage(SkillTree skillTree,Profile profile)
        {
            int additional = (int)Decimal.Round(Decimal.Multiply(profile.Highest_Reached_Tier_in_World_Map, 0.1m), MidpointRounding.AwayFromZero);
            if(skillTree.v08_17_more_damage)
            {
                additional += (int)Decimal.Round(Decimal.Multiply(profile.Highest_Cleared_Tier_in_World_Map , 0.05m), MidpointRounding.AwayFromZero);
            }
            if(skillTree.v09_16_more_damage)
            {
                decimal hour = profile.Play_Hour > 100 ? 100:profile.Play_Hour;
                additional += (int)Decimal.Round(Decimal.Multiply(hour, 2m), MidpointRounding.AwayFromZero);
            }
            return additional;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            int additional = Calc_additional_damage(skillTree,profile);
            inbound_projectileStat.average_damage += additional;
            inbound_projectileStat.max_damage += additional;
            inbound_projectileStat.min_damage += additional;

            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
            int additional = Calc_additional_damage(skillTree,profile);
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

        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            const int Count = 1000;
            decimal total_damage = new();
            decimal max_damage = new();
            decimal? min_damage = null;
            decimal? last_damage_for_stats = null;
            Projectile projectile = new();
            int j = 0;
            for (int i = 0; i < Count; i++)
            {
                projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
                if (projectile != null)
                {
                    j += 1;
                    if (last_damage_for_stats != null && last_damage_for_stats > projectile.damage) projectile.damage *= skillTree.v02_07_more_damage? 8m : 4m;
                    total_damage += projectile.damage;
                    max_damage = max_damage < projectile.damage ? projectile.damage : max_damage;
                    min_damage = (min_damage == null || min_damage > projectile.damage) ? projectile.damage : min_damage;
                    last_damage_for_stats = projectile.damage;
                }
            }
            ProjectileStat inbound_projectileStat = new();
            inbound_projectileStat.average_damage = total_damage / j;
            inbound_projectileStat.max_damage = max_damage;
            inbound_projectileStat.min_damage = (decimal)min_damage;
            inbound_projectileStat.magnification = projectile.magnification;
            inbound_projectileStat.speed = projectile.speed;
            inbound_projectileStat.lifetime = projectile.lifetime;
            inbound_projectileStat.Legendary_EnableGuideDamage = projectile.Legendary_EnableGuideDamage;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
            if (last_damage != null)
            {
                if (last_damage > inbound_projectile.damage) inbound_projectile.damage *= skillTree.v02_07_more_damage ? 8m : 4m;

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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            decimal late_damage_magnification = (inbound_projectileStat.lifetime + 0.4m) / inbound_projectileStat.lifetime;
            inbound_projectileStat.average_damage *= late_damage_magnification;
            inbound_projectileStat.max_damage *= late_damage_magnification;
            inbound_projectileStat.min_damage *= late_damage_magnification;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
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
        public Item_104_Unused_tile(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsLegendary = true;
        }
        private decimal Calc_additional_damage_magnification(SkillTree skillTree)
        {
            int num_unused_tiles = 0;
            var thing_1dim_layout = thing_layout.Cast<Thing>();
            IEnumerable<Thing> IEnull = thing_1dim_layout.Where(thing => thing.GetType().Name == "Parts_Null");
            num_unused_tiles = IEnull.Count<Thing>();
            if(skillTree.v08_05_legendary_as_unused_tile)
            {
                IEnull = thing_1dim_layout.Where(thing => thing.IsLegendary == true);
                num_unused_tiles += IEnull.Count<Thing>();
            }
            if(skillTree.v09_04_guide_as_unused_tile)
            {
                IEnull = thing_1dim_layout.Where(thing => thing.IsGuide == true);
                num_unused_tiles += IEnull.Count<Thing>();
            }
            return 1m + 0.1m * num_unused_tiles;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            //ProjectileStat inbound_projectileStat = null;

            decimal additional_damage_magnification = Calc_additional_damage_magnification(skillTree);
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            inbound_projectileStat.average_damage *= additional_damage_magnification;
            inbound_projectileStat.max_damage *= additional_damage_magnification;
            inbound_projectileStat.min_damage *= additional_damage_magnification;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            //Projectile inbound_projectile = null;

            decimal additional_damage_magnification = Calc_additional_damage_magnification(skillTree);
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, skillTree, this);
            decimal magnification = 1m;
            if (skillTree.v04_17_increase_thresholds)
            {
                if (inbound_projectileStat.speed is >= 0.3m and <= 1.2m)
                {
                    magnification = Math.Truncate(-10m / 3m * inbound_projectileStat.speed + 6m);
                }
                else if (inbound_projectileStat.speed < 0.3m)
                {
                    magnification = 5m;
                }
            }
            else
            {
                if (inbound_projectileStat.speed is >= 0.2m and <= 1)
                {
                    magnification = Math.Truncate(-3.75m * inbound_projectileStat.speed + 5.75m);
                }
                else if (inbound_projectileStat.speed < 0.2m)
                {
                    magnification = 5m;
                }
            }
            inbound_projectileStat.average_damage *= magnification;
            inbound_projectileStat.max_damage *= magnification;
            inbound_projectileStat.min_damage *= magnification;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, skillTree, this);
            decimal magnification = 1m;
            if (skillTree.v04_17_increase_thresholds)
            {
                if (inbound_projectile.speed is >= 0.3m and <= 1.2m)
                {
                    magnification = Math.Truncate(-10m / 3m * inbound_projectile.speed + 6m);
                }
                else if (inbound_projectile.speed < 0.3m)
                {
                    magnification = 5m;
                }
            }
            else
            {
                if (inbound_projectile.speed is >= 0.2m and <= 1)
                {
                    magnification = Math.Truncate(-3.75m * inbound_projectile.speed + 5.75m);
                }
                else if (inbound_projectile.speed < 0.2m)
                {
                    magnification = 5m;
                }
            }
            inbound_projectile.damage *= magnification;

            return inbound_projectile;
        }
    }
    class Item_106_Combine10 : Item
    {
        int count = 0;
        public Item_106_Combine10(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromDOWN = true;
            IsAccessToTOP = true;
            IsLegendary = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, skillTree, this);
            if (skillTree.v02_17_only_6_projectile)
            {
                inbound_projectileStat.average_damage *= 12m;
                inbound_projectileStat.max_damage *= 12m;
                inbound_projectileStat.min_damage *= 12m;
                inbound_projectileStat.magnification /= 6m;
            }
            else
            {
                inbound_projectileStat.average_damage *= 20m;
                inbound_projectileStat.max_damage *= 20m;
                inbound_projectileStat.min_damage *= 20m;
                inbound_projectileStat.magnification /= 10m;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = null;
            count += 1;
            if (count >= (skillTree.v02_17_only_6_projectile ? 6 : 10))
            {
                inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, skillTree, this);
                if (inbound_projectile != null)
                {
                    inbound_projectile.damage *= (skillTree.v02_17_only_6_projectile ? 12m : 20m);
                }
                count = 0;
            }
            return inbound_projectile;
        }
    }

    //TO BE SUPPORT
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            inbound_projectileStat.Legendary_EnableGuideDamage = true;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
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
        private decimal SkillTree_Add5damage(SkillTree skillTree)
        {
            int step = 0;
            if (skillTree.v00_07_add_5_damage)
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
        private static decimal SkillTree_Add30damage(SkillTree skillTree)
        {
            return skillTree.v01_08_add_30_damage ? 30m : 0m;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            decimal skillTree_Add5damage = SkillTree_Add5damage(skillTree);
            decimal skillTree_Add30damage = SkillTree_Add30damage(skillTree);
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            inbound_projectileStat.average_damage += 100m + skillTree_Add5damage + skillTree_Add30damage;
            inbound_projectileStat.max_damage += 100m + skillTree_Add5damage + skillTree_Add30damage;
            inbound_projectileStat.min_damage += 100m + skillTree_Add5damage + skillTree_Add30damage;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            decimal skillTree_Add5damage = SkillTree_Add5damage(skillTree);
            decimal skillTree_Add30damage = SkillTree_Add30damage(skillTree);
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
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
        private decimal Calc_additional_damage(SkillTree skillTree)
        {
            var thing_1dim_layout = thing_layout.Cast<Thing>();
            IEnumerable<Thing> IEunusedEjection = thing_1dim_layout.Where(thing => thing.GetType().Name == "Parts_02_Ejector").Where(thing => thing.Access_from_abs_top == null).Where(thing => thing.Access_from_abs_right == null).Where(thing => thing.Access_from_abs_down == null).Where(thing => thing.Access_from_abs_left == null);
            int unused_ejection = IEunusedEjection.Count<Thing>();
            decimal additional_damage =  unused_ejection * 10m;
            if(skillTree.v07_18_more_damage)
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            //ProjectileStat inbound_projectileStat = null;

            decimal additional_damage = Calc_additional_damage(skillTree);
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile,skillTree, this);
            inbound_projectileStat.average_damage += additional_damage;
            inbound_projectileStat.max_damage += additional_damage;
            inbound_projectileStat.min_damage += additional_damage;
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile,SkillTree skillTree, Thing to_thing)
        {
            //Projectile inbound_projectile = null;

            decimal additional_damage = Calc_additional_damage(skillTree);
            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile,skillTree, this);
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
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = Access_from_rel_down.GetOutboundProjectileStat(shipParameter, profile, skillTree, this);
            if (skillTree.v07_04_chance_more_clone)
            {
                inbound_projectileStat.magnification *= 2.2m;
            }
            else
            {
                inbound_projectileStat.magnification *= 2m;
            }
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            //Projectile inbound_projectile = null;

            Projectile inbound_projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, skillTree, this);
            if (inbound_projectile != null)
            {
                if (skillTree.v07_04_chance_more_clone && rand.Next(0,100) < 20)
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
