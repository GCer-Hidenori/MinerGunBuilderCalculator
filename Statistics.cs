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
        }
        public static Stats Calculate(List<decimal> inputs)
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
                max = inputs[count - 1]
            };
        }
        
    }
}
