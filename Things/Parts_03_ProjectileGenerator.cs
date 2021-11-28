using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
  //  namespace Item
   // {
    class Parts_03_ProjectileGenerator : Parts
    {
        public Parts_03_ProjectileGenerator(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessToTOP = true;
        }
        public override List<Projectile> GetOutboundProjectile(ShipParameter shipParameter,Thing to_thing)
        {
            List<Projectile> inbound_projectiles = new();
            var projectile = new Projectile();
            projectile.average_damage = shipParameter.base_damage;
            projectile.max_damage = shipParameter.base_damage;
            projectile.min_damage = shipParameter.base_damage;
            projectile.fire_rate = shipParameter.fire_rate;
            projectile.speed = shipParameter.projectile_speed;
            inbound_projectiles.Add(projectile);
            
            return inbound_projectiles;
        }

    }
}
