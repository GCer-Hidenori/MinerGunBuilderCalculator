using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinerGunBuilderCalculator
{
    public interface IShipLayoutChangeObserver
    {
        void ShipLayoutChanged(Thing[,] thing_layout, ShipParameter shipParameter);
    }
}
