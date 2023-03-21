using System;

namespace _1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter INTEGERS! NO FLOAT");
            Console.WriteLine("Enter the numbers that you want to calculate: ");
            int i = Convert.ToInt32(Console.ReadLine());
            Avera(i);
            static float Avera(int i)
            {
                int[] value = new int[i]; // define array and create variable name - number of values will be stored
                int j, sum = 0;
                for (j = 0; j < i; j++)
                {
                    Console.WriteLine($"Enter {j + 1} number: ");
                    value[j] = Convert.ToInt32(Console.ReadLine());
                    sum += value[j];
                }
                Console.WriteLine("Sum of all numbers: " + sum);
                float average = (float)((float)sum / (float)i);
                Console.WriteLine($"Average of {i} numbers: " + average);
                Check(average);
                return average;
            }
            static void Check(float average)
            {
                if (average >= 10)
                {
                    Console.WriteLine("Double digits");
                }
                else
                {
                    Console.WriteLine("Single digit");
                }
            }
        }
    }
}

