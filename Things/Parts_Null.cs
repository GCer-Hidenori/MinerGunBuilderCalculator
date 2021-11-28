using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    //namespace Item
    //{
    class Parts_Null : Parts
    {
        public Parts_Null(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsRemovable = false;
            IsRotatable = false;
        }
    }

}
