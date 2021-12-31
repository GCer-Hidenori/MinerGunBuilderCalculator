using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    class Item : Thing
    {
        public Item(Thing[,] _thing_layout) : base(_thing_layout)
        {
            thing_layout = _thing_layout;
        }
    }
}
