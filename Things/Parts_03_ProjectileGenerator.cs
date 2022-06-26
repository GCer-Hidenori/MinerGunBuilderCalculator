using System.Collections.Generic;

namespace MinerGunBuilderCalculator
{
    internal class Parts_03_ProjectileGenerator : Parts
    {
        public override string Id { get; set; } = "02";
        public override string Name { get; set; } = nameof(Parts_03_ProjectileGenerator);

        public Parts_03_ProjectileGenerator(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessToTOP = true;
        }

        private static decimal SkillTree_Add5damage(HashSet<string> skillList)
        {
            if (skillList.Contains("05_10"))
            {
                return 5;
            }
            else
            {
                return 0;
            }
        }

        public override ProjectileStat GetOutboundProjectileStat(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            ProjectileStat inbound_projectileStat = new();
            inbound_projectileStat.average_damage = shipParameter.base_damage + SkillTree_Add5damage(profile.skillList);
            inbound_projectileStat.max_damage = shipParameter.base_damage + SkillTree_Add5damage(profile.skillList);
            inbound_projectileStat.min_damage = shipParameter.base_damage + SkillTree_Add5damage(profile.skillList);
            inbound_projectileStat.magnification = 1;
            inbound_projectileStat.speed = shipParameter.projectile_speed;
            inbound_projectileStat.lifetime = shipParameter.projectile_lifetime;

            return inbound_projectileStat;
        }

        public override Projectile GetOutboundProjectile(ShipParameter shipParameter, Profile profile, Thing to_thing)
        {
            Projectile projectile = new();
            projectile.damage = shipParameter.base_damage + SkillTree_Add5damage(profile.skillList);
            projectile.magnification = 1;
            projectile.speed = shipParameter.projectile_speed;
            projectile.lifetime = shipParameter.projectile_lifetime;
            return projectile;
        }
    }
}