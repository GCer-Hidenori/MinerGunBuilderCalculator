using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    class Parts_03_ProjectileGenerator : Parts
    {
        public Parts_03_ProjectileGenerator(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessToTOP = true;
        }
        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter,Profile profile,SkillTree skillTree,Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = new();
            inbound_projectileStat.average_damage = shipParameter.base_damage;
            inbound_projectileStat.max_damage = shipParameter.base_damage;
            inbound_projectileStat.min_damage = shipParameter.base_damage;
            inbound_projectileStat.magnification = 1;
            inbound_projectileStat.speed = shipParameter.projectile_speed;
            inbound_projectileStat.lifetime = shipParameter.projectile_lifetime;
            
            return inbound_projectileStat;
        }
        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, SkillTree skillTree, Thing to_thing)
        {
            Projectile projectile = new();
            projectile.damage = shipParameter.base_damage;
            projectile.magnification = 1;
            projectile.speed = shipParameter.projectile_speed;
            projectile.lifetime = shipParameter.projectile_lifetime;
            return projectile;
        }
    }
}
