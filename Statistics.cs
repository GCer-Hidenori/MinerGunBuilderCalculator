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
        public static decimal Calc_round_area(int round_area_count,HashSet<string> skillList)
        {
            decimal radius;
            if(skillList.Contains("07_00"))
            {
                radius = 0.938m * (decimal)round_area_count + 0.0781m ;
            }
            else
            {
                radius = 0.703m * (decimal)round_area_count + 0.469m;
            }
            return radius * radius * (decimal)Math.PI;

        }
        public static decimal Calc_rectangle_area(int rectangle_area_count,HashSet<string> skillList)
        {
            decimal width,height;
            if(skillList.Contains("08_01"))
            {
                width = 2.266m * rectangle_area_count + 0.313m;
                height = 1.172m * rectangle_area_count;
            }
            else
            {
                width = 1.875m * rectangle_area_count + 0.938m;
                height = 1.016m * rectangle_area_count + 0.0781m;
            }
            if(skillList.Contains("09_00"))
            {
                (width,height) = (height,width);
            }
            return height * width;
        }
        
    }
}
