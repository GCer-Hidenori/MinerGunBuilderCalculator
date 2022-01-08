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
        public bool v02_13_increase_chance = false;
        public bool v02_15_increase_chance = false; //criticalx10
        public bool v01_16_high_times = false;  //criticalx10

        // random critinal
        // Multipliers are instead 0,1,1,2 or 3.
        public bool v03_16_high_multiplier = false;

        // random critinal
        // Multipliers are instead 0,0,0,1,2,3 or 4.
        public bool v03_18_high_multiplier = false;

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
