using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    public class Projectile
    {
        //public List<Projectile> self_and_ancestors = new();
        public decimal damage;
        public decimal magnification;
        public decimal speed;
        public decimal lifetime;
        public bool slowdamage = false;
        public int round_area_count = 0;
        public int rectangle_area_count = 0;
        public int pierce_count = 0;

        public bool Legendary_EnableGuideDamage = false;
        public List<Crossing> list_of_crossing_passed = new();
        public Projectile()
        {
            //self_and_ancestors.Add(this);
        }
        public Projectile Copy()
        {
            var projectile = new Projectile
            {
                damage = damage,
                magnification = magnification,
                speed = speed,
                lifetime = lifetime,
                slowdamage = slowdamage,
                round_area_count = round_area_count,
                rectangle_area_count = rectangle_area_count,
                pierce_count = pierce_count,
                Legendary_EnableGuideDamage = Legendary_EnableGuideDamage,
                list_of_crossing_passed = new List<Crossing>(list_of_crossing_passed)
            };
            //projectile.self_and_ancestors.AddRange(self_and_ancestors);

            return projectile;
        }
        public decimal Calc_effective_damage(HashSet<string> skillList)
        {
            decimal effective_damage = 0m;
            int pierce = 0;
            Random rand = new Random();
            while(true)
            {
	            if (round_area_count != 0 || rectangle_area_count != 0)
	            {
	                if (round_area_count > 0)
	                {
	                    effective_damage += damage * Statistics.Calc_round_area(round_area_count,skillList);
	                }
	                if (rectangle_area_count > 0)
	                {
	                    effective_damage += damage * Statistics.Calc_rectangle_area(rectangle_area_count, skillList);
	                }
	            }
	            else
	            {
	                effective_damage += damage;
	            }
                if(!skillList.Contains("01_10") || skillList.Contains("01_10") &&  rand.Next(0,100)<70)
                {
                   pierce++;
                }
                if(pierce > pierce_count)break;
            }
            return effective_damage;
        }
    }
}
