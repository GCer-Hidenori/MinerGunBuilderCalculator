using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    public class ProjectileStat
    {
        public List<ProjectileStat> self_and_ancestors = new();

        public decimal average_damage;
        public decimal max_damage;
        public decimal min_damage;
        public decimal speed;
        public decimal magnification;

        public ProjectileStat()
        {
            self_and_ancestors.Add(this);
        }

        public ProjectileStat Copy()
        {
            var projectileStats = new ProjectileStat
            {
                average_damage = average_damage,
                max_damage = max_damage,
                min_damage = min_damage,
                speed = speed,
                magnification = magnification
            };
            projectileStats.self_and_ancestors.AddRange(self_and_ancestors);

            return projectileStats;
        }
    }
}
