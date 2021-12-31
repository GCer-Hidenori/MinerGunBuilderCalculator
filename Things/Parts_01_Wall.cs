using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    class Parts_01_Wall : Thing
    {
        public Parts_01_Wall(Thing[,] thing_layout) : base(thing_layout)
        {
            IsRotatable = false;
        }        
    }
}
