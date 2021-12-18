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
            public decimal average;
            public decimal mean;
            public decimal max;
            public decimal min;
            public decimal total_damage;
            public decimal average_per_sec;
            public decimal ejected;
            public decimal ejected_per_sec;
        }
        public static Stats Calculate(List<decimal> inputs,int fire_time_sec)
        {
            int count;
            decimal sum = 0;
            inputs.Sort();

            for (count = 0; count < inputs.Count; count++)
            {
                sum += inputs[count];
            }
            count = inputs.Count;
            return new Stats()
            {
                average = sum / count,
                mean = inputs[count / 2],
                min = inputs[0],
                max = inputs[count - 1],
                total_damage = sum,
                average_per_sec = sum / fire_time_sec,
                ejected = count,
                ejected_per_sec = new decimal(count) / fire_time_sec
            };
        }
        
    }
}
