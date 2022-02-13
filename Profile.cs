using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    public class Profile
    {
        public int Highest_Reached_Tier_in_World_Map = 0;
        public int Highest_Cleared_Tier_in_World_Map = 0;
        public decimal Play_Hour = 0;
        public HashSet<string> skillList = new();

        public Profile()
        {

        }
    }
}
