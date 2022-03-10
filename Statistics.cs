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
        /*
        public static Stats Calculate_old(List<decimal> ejector_damages,int fire_time_sec,decimal eject_count)
        {
            int count;
            decimal sum_damage = 0;
            ejector_damages.Sort();

            for (count = 0; count < ejector_damages.Count; count++)
            {
                sum_damage += ejector_damages[count];
            }
            //count = inputs.Count;
            count = (int)eject_count;
            return new Stats()
            {
                average_damage = sum_damage / count,
                mean_damage = ejector_damages[count / 2],
                min_damage = ejector_damages[0],
                max_damage = ejector_damages[count - 1],
                total_damage = sum_damage,
                average_damage_per_sec = sum_damage / fire_time_sec,
                ejected_count = count,
                ejected_count_per_sec = new decimal(count) / fire_time_sec
            };
        }
        */
        public static decimal Calc_round_area(int round_area_count,int pierce)
        {
            decimal radius = (0.567m * (decimal)round_area_count + 1.167m) / 2.0m;
            if(radius >= pierce)
            {
                double theta = Math.Asin((double)(pierce / radius));
                return (decimal)Math.PI * radius * radius / 2m + radius * radius * (decimal)theta + pierce * radius * (decimal)Math.Cos(theta); 
            }
            return radius * radius * (decimal)Math.PI / 2m;

        }
        public static decimal Calc_rectangle_area(int rectangle_area_count,int pierce)
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
        
    }
}
