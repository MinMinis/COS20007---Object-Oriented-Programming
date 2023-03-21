using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterTest
{
    public class MinMaxSummary : SummaryStrategy
    {
        private int Minimum(List<int> numbers)
        {
            int small = numbers[0];
            foreach (int i in numbers)
            {
                if (small > i)
                {
                    small = i;
                }
            }
            return small;
        }
        private int Maximum(List<int> numbers) 
        {
            int large = numbers[0];
            foreach (int i in numbers)
            {
                if (large < i)
                {
                    large = i;
                }
            }
            return large;
        }
        public override void PrintSummary(List<int> numbers) 
        {
            Console.WriteLine("Min Value: " + Minimum(numbers));
            Console.WriteLine("Max Value: " + Maximum(numbers));
        }
    }
}
