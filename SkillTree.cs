using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    public class SkillTree
    {
        //public Form_SkillTree form_SkillTree;
        public bool v00_07_add_5_damage = false;
        public bool v01_08_add_30_damage = false;
        public bool v04_11_add_5_damage = false;
        public bool v05_10_add_5_damage = false;
        public bool v03_12_add_5_damage = false;

        //criticalx2
        //Increased chance of 40% for damage multiplier.
        public bool v02_13_increase_chance = false;
        //criticalx2
        //Higher multiplier of times 2.5.
        public bool v01_12_high_multiplier = false;

        //criticalx10
        public bool v02_15_increase_chance = false;
        public bool v01_16_high_times = false;

        // random critinal
        // Multipliers are instead 0,1,1,2 or 3.
        public bool v03_16_high_multiplier = false;

        // random critinal
        // Multipliers are instead 0,0,0,1,2,3 or 4.
        public bool v03_18_high_multiplier = false;

        // Charge
        // Adds instead 30% of damage to following projectiles.
        public bool v06_13_high_multiplier = false;

        // Combine10
        // Combines only 6 projectiles instead
        public bool v02_17_only_6_projectile = false;

        // Slow damage
        // Increase the speed thresholds to 1.2 to 0.3.
        public bool v04_17_increase_thresholds = false;

        // Curve Left
        // Adds up to 40% more damage with bigger ejection curve angle.
        public bool v05_06_more_damage = false;

        // Curve Right
        // Adds up to 40% more damage with bigger ejection curve angle.
        public bool v04_05_more_damage = false;

        // Random curve
        // Adds up to 60% more damage with bigger ejection curve angle.
        public bool v03_08_more_damage = false;

        // More than lower
        // 8x damage instead of 4x.
        public bool v02_07_more_damage = false;

        // Add 1 damage
        // Adds +5 additional damage.
        public bool v05_08_more_damage = false;
        // Add 1 damage
        // Adds +20 additional damage for each in ship.
        public bool v05_00_more_damage = false;

        // Spread left
        // Adds up to 50% more damage with bigger ejection angle.
        public bool v06_11_more_damage = false;
        // Spread right
        // Adds up to 50% more damage with bigger ejection angle.
        public bool v07_12_more_damage = false;

        // Small spread
        // Adds up to 25% more damage with bigger ejection angle.
        public bool v08_11_more_damage = false;

        public ShipLayoutManager shipLayoutManager;
        public SkillTree()
        {
        }
        
        /*
        public SkillTree(ShipLayoutManager shipLayoutManager )
        {
            this.shipLayoutManager = shipLayoutManager;
        }
        */

    }
}
