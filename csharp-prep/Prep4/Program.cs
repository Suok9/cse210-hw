
using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberListProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = new List<double>();

            Console.WriteLine("Enter a list of numbers, type 0 when finished.");

            while (true)
            {
                Console.Write("Enter number: ");
                double number;
                if (double.TryParse(Console.ReadLine(), out number) && number == 0)
                    break;
                else if (double.TryParse(Console.ReadLine(), out number))
                    numbers.Add(number);
                else
                    Console.WriteLine("Invalid input. Please enter a number.");
            }

            // Core Requirements
            double sum = numbers.Sum();
            double average = numbers.Average();
            double max = numbers.Max();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average}");
            Console.WriteLine($"The largest number is: {max}");

            // Stretch Challenges
            double smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(double.MaxValue).Min();
            if (smallestPositive != double.MaxValue)
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            else
                Console.WriteLine("No positive numbers found.");

            var sortedList = numbers.OrderBy(n => n).ToList();
            Console.WriteLine("The sorted list is: " + string.Join(" ", sortedList));
        }
    }
}
