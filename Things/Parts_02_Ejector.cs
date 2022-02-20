using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    class Parts_02_Ejector : Parts
    {
        public Parts_02_Ejector(Thing[,] thing_layout) : base(thing_layout)
        {
            IsAccessFromTOP = true;
            IsAccessFromRIGHT = true;
            IsAccessFromDOWN = true;
            IsAccessFromLEFT = true;
        }
        public List<ProjectileStat> GetOutboundProjectileStatList(ShipParameter shipParameter, Profile profile)
        {
            List<ProjectileStat> inbound_projectileStats = new();
            if (Access_from_abs_top != null)
            {
                ProjectileStat projectileStat;
                if ((projectileStat = Access_from_abs_top.GetOutboundProjectileStat(shipParameter, profile, this)) != null)
                {
                    inbound_projectileStats.Add(projectileStat);
                }
            }
            if (Access_from_abs_right != null)
            {
                ProjectileStat projectileStat;
                if ((projectileStat = Access_from_abs_right.GetOutboundProjectileStat(shipParameter, profile, this)) != null)
                {
                    inbound_projectileStats.Add(projectileStat);
                }
            }
            if (Access_from_abs_down != null)
            {
                ProjectileStat projectileStat;
                if ((projectileStat = Access_from_abs_down.GetOutboundProjectileStat(shipParameter, profile, this)) != null)
                {
                    inbound_projectileStats.Add(projectileStat);
                }
            }
            if (Access_from_abs_left != null)
            {
                ProjectileStat projectileStat;
                if ((projectileStat = Access_from_abs_left.GetOutboundProjectileStat(shipParameter, profile, this)) != null)
                {
                    inbound_projectileStats.Add(projectileStat);
                }
            }
            return inbound_projectileStats;
        }
        public List<Projectile> GetOutboundProjectileList(ShipParameter shipParameter,Profile profile)
        {
            Projectile projectile = new();
            List<Projectile> projectileList = new();
            if (Access_from_rel_top != null)
            {
                if((projectile = Access_from_rel_top.GetOutboundProjectile(shipParameter,profile,this)) != null)
                {
                    projectileList.Add(projectile);
                }
            }
            if (Access_from_rel_right != null)
            {
                if((projectile = Access_from_rel_right.GetOutboundProjectile(shipParameter,profile,this)) != null)
                {
                    projectileList.Add(projectile);
                }
            }
            if (Access_from_rel_down != null)
            {
                if((projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter,profile,this)) != null)
                {
                    projectileList.Add(projectile);
                }
            }
            if (Access_from_rel_left != null)
            {
                if((projectile = Access_from_rel_left.GetOutboundProjectile(shipParameter,profile,this)) != null)
                {
                    projectileList.Add(projectile);
                }
            }
            return projectileList;
        }
    }
}
