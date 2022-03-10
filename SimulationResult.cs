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
        public List<decimal> projectile_damages;
        public List<decimal> projectile_effective_damges;
        public Statistics.Stats stats_projectile_damage;
        public Statistics.Stats stats_projectile_effective_damage;
        public int ejected_count;
        public decimal ejected_count_per_sec;
    }
}
