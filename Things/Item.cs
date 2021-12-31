using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    class Item : Thing
    {
        public Item(Thing[,] thing_layout) : base(thing_layout)
        {
            this.thing_layout = thing_layout;
        }
    }
}
