using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerGunBuilderCalculator
{
    public class Statistics
    {
        public struct Stats
        {
            public decimal average_damage;
            public decimal mean_damage;
            public decimal max_damage;
            public decimal min_damage;
            public decimal total_damage;
            public decimal average_damage_per_sec;
        }
        public static Stats Calculate(List<decimal> damages,int fire_time_sec)
        {
            int count;
            decimal sum_damage = 0;
            damages.Sort();
            for (count = 0; count < damages.Count; count++)
            {
                sum_damage += damages[count];
            }
            count = damages.Count;
            return new Stats()
            {
                average_damage = sum_damage / count,
                mean_damage = damages[count / 2],
                min_damage = damages[0],
                max_damage = damages[count - 1],
                total_damage = sum_damage,
                average_damage_per_sec = sum_damage / fire_time_sec
            };
        }
        public static decimal Calc_round_area(int round_area_count,int pierce,HashSet<string> skillList)
        {
            decimal radius;
            if(skillList.Contains("07_00"))
            {
                radius = (0.567m * (decimal)round_area_count + 1.167m) / 2.0m;
            }
            else
            {
                radius = (0.756m * (decimal)round_area_count + 0.195m) / 2.0m;
            }
            if(radius >= pierce)
            {
                double theta = Math.Asin((double)(pierce / radius));
                return (decimal)Math.PI * radius * radius / 2m + radius * radius * (decimal)theta + pierce * radius * (decimal)Math.Cos(theta); 
            }
            return radius * radius * (decimal)Math.PI / 2m;

        }
        public static decimal Calc_rectangle_area(int rectangle_area_count,int pierce,HashSet<string> skillList)
        {
            decimal width,height;
            if(skillList.Contains("08_01"))
            {
                width = 1.81m * rectangle_area_count + 0.6m;
                height = 0.5m * rectangle_area_count;
            }
            else
            {
                width = 1.5m * rectangle_area_count + 1.9m;
                height = 0.43m * rectangle_area_count + 0.5m;
            }
            if(skillList.Contains("09_00"))
            {
                (width,height) = (height,width);
            }
            if (height / 2m >= pierce)
            {
                return (height / 2m + pierce) * width;
            }
            else
            {
                return height * width;
            }
        }
        
    }
}
