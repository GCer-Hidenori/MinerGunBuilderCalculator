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

        /*
        public bool V00_07_add_5_damage
        {
            set
            {
                v00_07_add_5_damage = value;
            }
            get
            {
                return v00_07_add_5_damage;
            }
        }
        */
    }
}
