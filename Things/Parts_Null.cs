using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    class Parts_Null : Parts
    {
        public Parts_Null(Thing[,] thing_layout) : base(thing_layout)
        {
            IsRemovable = false;
            IsRotatable = false;
        }
    }

}
