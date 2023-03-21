using System;

namespace Hello_World
{
    class Program
    {
        static void Main(string[] args)
        {
 
            string des = "The total value of 10 numbers: ";
            int sum = 0;
            int j = 0;
            for (int i = 1; i <= 10; i++) 
            {
                Console.WriteLine($"Please input the {i} number:");
                int val = Convert.ToInt32(Console.ReadLine());
                sum += val;
                j++;
            }
            if (j != 10)
            {
                Console.WriteLine(des + sum);
            }

        }
    }
}
