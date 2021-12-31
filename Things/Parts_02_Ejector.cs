using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    class Parts_02_Ejector : Parts
    {
        public Parts_02_Ejector(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromTOP = true;
            IsAccessFromRIGHT = true;
            IsAccessFromDOWN = true;
            IsAccessFromLEFT = true;
        }
    }
}
