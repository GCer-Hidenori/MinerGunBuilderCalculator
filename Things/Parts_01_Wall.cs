using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    class Parts_01_Wall : Thing
    {
        public Parts_01_Wall(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsRotatable = false;
        }        
    }
}
