using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    class Parts_03_ProjectileGenerator : Parts
    {
        public Parts_03_ProjectileGenerator(Thing[,] _thing_layout) : base(_thing_layout)
        {
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter,Profile profile,Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = new();
            var projectileStat = new ProjectileStat();
            projectileStat.average_damage = shipParameter.base_damage;
            projectileStat.max_damage = shipParameter.base_damage;
            projectileStat.min_damage = shipParameter.base_damage;
            projectileStat.magnification = 1;
            projectileStat.speed = shipParameter.projectile_speed;
            inbound_projectileStat = projectileStat;
            
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile projectile = new();
            projectile.damage = shipParameter.base_damage;
            projectile.magnification = 1;
            projectile.speed = shipParameter.projectile_speed;
            return projectile;
        }
    }
}
