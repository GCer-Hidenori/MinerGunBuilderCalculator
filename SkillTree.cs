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
