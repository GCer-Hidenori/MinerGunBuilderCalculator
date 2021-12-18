using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    struct SimulationResult
    {
        public string ejector_name;
        public List<decimal> damages;
        public Statistics.Stats stats;
    }
}
