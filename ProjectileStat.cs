using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    public class ProjectileStat
    {
        //public List<ProjectileStat> self_and_ancestors = new();

        public decimal average_damage;
        public decimal max_damage;
        public decimal min_damage;

        public decimal speed;
        public decimal lifetime;
        public decimal magnification;
        public bool slowdamage = false;
        public int round_area_count = 0;
        public int rectangle_area_count = 0;
        public int pierce_count = 0;

        public bool Legendary_EnableGuideDamage = false;
        public List<Crossing> list_of_crossing_passed = new();

        public ProjectileStat()
        {
            //self_and_ancestors.Add(this);
        }

        public ProjectileStat Copy()
        {
            var projectileStats = new ProjectileStat
            {
                average_damage = average_damage,
                max_damage = max_damage,
                min_damage = min_damage,
                speed = speed,
                lifetime = lifetime,
                magnification = magnification,
                slowdamage = slowdamage,
                round_area_count = round_area_count,
                rectangle_area_count = rectangle_area_count,
                pierce_count = pierce_count,
                Legendary_EnableGuideDamage = Legendary_EnableGuideDamage,
                list_of_crossing_passed = new List<Crossing>(list_of_crossing_passed)
            };
            //projectileStats.self_and_ancestors.AddRange(self_and_ancestors);

            return projectileStats;
        }
        /*
        private decimal Calc_round_area(int pierce)
        {
            decimal radius = (0.567m * (decimal)round_area_count + 1.167m) / 2.0m;
            if(radius >= pierce)
            {
                double theta = Math.Asin((double)(pierce / radius));
                return (decimal)Math.PI * radius * radius / 2m + radius * radius * (decimal)theta + pierce * radius * (decimal)Math.Cos(theta); 
            }
            return radius * radius * (decimal)Math.PI / 2m;

        }
        */
        /*
        private decimal Calc_rectangle_area(int pierce)
        {
            decimal width = 1.5m * rectangle_area_count + 1.9m;
            decimal height = 0.43m * rectangle_area_count + 0.5m;
            if (height / 2m >= pierce)
            {
                return (height / 2m + pierce) * width;
            }
            else
            {
                return height * width;
            }
        }
        */

        public decimal Calc_average_effective_damage(HashSet<string> skillList)
        {
            decimal damage = 0m;
            for(int pierce = 0;pierce < pierce_count + 1;pierce++)
            {
                if (round_area_count != 0 || rectangle_area_count != 0)
                {
                    if (round_area_count > 0)
                    {
                        damage += average_damage * Statistics.Calc_round_area(round_area_count,pierce,skillList);
                    }
                    if (rectangle_area_count > 0)
                    {
                        damage += average_damage * Statistics.Calc_rectangle_area(rectangle_area_count,pierce);
                    }
                }
                else
                {
                    damage += average_damage;
                }
            }
            return damage;
        }
        public decimal Calc_min_effective_damage(HashSet<string> skillList)
        {
            decimal damage = 0m;
            for(int pierce = 0;pierce < pierce_count + 1;pierce++)
            {
                if (round_area_count != 0 || rectangle_area_count != 0)
                {
                    if (round_area_count > 0)
                    {
                        damage += min_damage * Statistics.Calc_round_area(round_area_count,pierce,skillList);
                    }
                    if (rectangle_area_count > 0)
                    {
                        damage += min_damage * Statistics.Calc_rectangle_area(rectangle_area_count,pierce);
                    }
                }
                else
                {
                    damage += average_damage;
                }
            }
            return damage;
        }
        public decimal Calc_max_effective_damage(HashSet<string> skillList)
        {
            decimal damage = 0m;
            for(int pierce = 0;pierce < pierce_count + 1;pierce++)
            {
                if (round_area_count != 0 || rectangle_area_count != 0)
                {
                    if (round_area_count > 0)
                    {
                        damage += max_damage * Statistics.Calc_round_area(round_area_count,pierce, skillList);
                    }
                    if (rectangle_area_count > 0)
                    {
                        damage += max_damage * Statistics.Calc_rectangle_area(rectangle_area_count,pierce);
                    }
                }
                else
                {
                    damage += average_damage;
                }
            }
            return damage;
        }
    }
}
