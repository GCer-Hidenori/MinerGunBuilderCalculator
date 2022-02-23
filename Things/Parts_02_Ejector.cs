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
            List<ProjectileStat> inbound_projectileStatList = new();
            if (Access_from_abs_top != null)
            {
                ProjectileStat projectileStat;
                if ((projectileStat = Access_from_abs_top.GetOutboundProjectileStat(shipParameter, profile, this)) != null)
                {
                    inbound_projectileStatList.Add(projectileStat);
                }
            }
            if (Access_from_abs_right != null)
            {
                ProjectileStat projectileStat;
                if ((projectileStat = Access_from_abs_right.GetOutboundProjectileStat(shipParameter, profile, this)) != null)
                {
                    inbound_projectileStatList.Add(projectileStat);
                }
            }
            if (Access_from_abs_down != null)
            {
                ProjectileStat projectileStat;
                if ((projectileStat = Access_from_abs_down.GetOutboundProjectileStat(shipParameter, profile, this)) != null)
                {
                    inbound_projectileStatList.Add(projectileStat);
                }
            }
            if (Access_from_abs_left != null)
            {
                ProjectileStat projectileStat;
                if ((projectileStat = Access_from_abs_left.GetOutboundProjectileStat(shipParameter, profile, this)) != null)
                {
                    inbound_projectileStatList.Add(projectileStat);
                }
            }
            foreach (ProjectileStat projectileStat in inbound_projectileStatList)
            {
                if (projectileStat.slowdamage)
                {
                    decimal magnification = 1m;
                    if (profile.skillList.Contains("04_17"))
                    {
                        if (projectileStat.speed is >= 0.3m and <= 1.2m)
                        {
                            magnification = Math.Truncate(-10m / 3m * projectileStat.speed + 6m);
                        }
                        else if (projectileStat.speed < 0.3m)
                        {
                            magnification = 5m;
                        }
                    }
                    else
                    {
                        if (projectileStat.speed is >= 0.2m and <= 1)
                        {
                            magnification = Math.Truncate(-3.75m * projectileStat.speed + 5.75m);
                        }
                        else if (projectileStat.speed < 0.2m)
                        {
                            magnification = 5m;
                        }
                    }
                    projectileStat.average_damage *= magnification;
                    projectileStat.max_damage *= magnification;
                    projectileStat.min_damage *= magnification;
                }
            }
            return inbound_projectileStatList;
        }
        public List<Projectile> GetOutboundProjectileList(ShipParameter shipParameter, Profile profile)
        {
            List<Projectile> projectileList = new();
            if (Access_from_rel_top != null)
            {
                Projectile projectile = new();
                if ((projectile = Access_from_rel_top.GetOutboundProjectile(shipParameter, profile, this)) != null)
                {
                    projectileList.Add(projectile);
                }
            }
            if (Access_from_rel_right != null)
            {
                Projectile projectile = new();
                if ((projectile = Access_from_rel_right.GetOutboundProjectile(shipParameter, profile, this)) != null)
                {
                    projectileList.Add(projectile);
                }
            }
            if (Access_from_rel_down != null)
            {
                Projectile projectile = new();
                if ((projectile = Access_from_rel_down.GetOutboundProjectile(shipParameter, profile, this)) != null)
                {
                    projectileList.Add(projectile);
                }
            }
            if (Access_from_rel_left != null)
            {
                Projectile projectile = new();
                if ((projectile = Access_from_rel_left.GetOutboundProjectile(shipParameter, profile, this)) != null)
                {
                    projectileList.Add(projectile);
                }
            }
            foreach (Projectile projectile in projectileList)
            {
                if (projectile.slowdamage)
                {
                    decimal magnification = 1m;
                    if (profile.skillList.Contains("04_17"))
                    {
                        if (projectile.speed is >= 0.3m and <= 1.2m)
                        {
                            magnification = Math.Truncate(-10m / 3m * projectile.speed + 6m);
                        }
                        else if (projectile.speed < 0.3m)
                        {
                            magnification = 5m;
                        }
                    }
                    else
                    {
                        if (projectile.speed is >= 0.2m and <= 1)
                        {
                            magnification = Math.Truncate(-3.75m * projectile.speed + 5.75m);
                        }
                        else if (projectile.speed < 0.2m)
                        {
                            magnification = 5m;
                        }
                    }
                    projectile.damage *= magnification;
                }
            }
            return projectileList;
        }
    }
}
