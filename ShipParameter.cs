using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    public class ShipParameter
    {
        public decimal base_damage;
        public decimal fire_rate;
        public decimal projectile_speed;
        public decimal projectile_lifetime;

        public ShipParameter()
        {
            base_damage = 1m;
            fire_rate = 2.7m;
            projectile_speed = 1m;
            projectile_lifetime = 3m;

        }

        public ShipParameter(decimal fireRate, decimal projectileSpeed)
        {
            base_damage = 1m;
            fire_rate = fireRate;
            projectile_speed = projectileSpeed;
            projectile_lifetime = 3m;
        }
    }
}
