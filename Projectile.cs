using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    public class Projectile
    {
        public List<Projectile> self_and_ancestors = new();

        public decimal average_damage;
        public decimal max_damage;
        public decimal min_damage;
        public decimal speed;
        public decimal fire_rate;

        public Projectile()
        {
            self_and_ancestors.Add(this);
        }

        public Projectile Copy()
        {
            var projectile = new Projectile
            {
                average_damage = average_damage,
                max_damage = max_damage,
                min_damage = min_damage,
                speed = speed,
                fire_rate = fire_rate
            };
            projectile.self_and_ancestors.AddRange(self_and_ancestors);

            return projectile;
        }
    }
}
