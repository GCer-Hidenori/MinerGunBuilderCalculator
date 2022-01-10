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
