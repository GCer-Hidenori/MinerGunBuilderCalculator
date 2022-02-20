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
        public decimal damage;
        public decimal magnification;
        public decimal speed;
        public decimal lifetime;
        public bool slowdamage = false;

        public bool Legendary_EnableGuideDamage = false;
        public Projectile()
        {
            self_and_ancestors.Add(this);
        }
        public Projectile Copy()
        {
            var projectile = new Projectile
            {
                damage = damage,
                speed = speed,
                lifetime = lifetime,
                Legendary_EnableGuideDamage = Legendary_EnableGuideDamage,
                magnification = magnification
            };
            projectile.self_and_ancestors.AddRange(self_and_ancestors);

            return projectile;
        }
    }
}
