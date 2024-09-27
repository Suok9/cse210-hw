using System;

namespace GradeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Enter your grade percentage: ");
            int percentage = Convert.ToInt32(Console.ReadLine());

            
            string letter;
            string sign = "";

            if (percentage >= 90)
            {
                letter = "A";
                if (percentage % 10 < 3)
                    sign = "-";
            }
            else if (percentage >= 80)
            {
                letter = "B";
                if (percentage % 10 >= 7)
                    sign = "+";
                else if (percentage % 10 < 3)
                    sign = "-";
            }
            else if (percentage >= 70)
            {
                letter = "C";
                if (percentage % 10 >= 7)
                    sign = "+";
                else if (percentage % 10 < 3)
                    sign = "-";
            }
            else if (percentage >= 60)
            {
                letter = "D";
                if (percentage % 10 >= 7)
                    sign = "+";
                else if (percentage % 10 < 3)
                    sign = "-";
            }
            else
            {
                letter = "F";
            }

            
            Console.WriteLine($"Your grade is {letter}{sign}.");

            
            if (percentage >= 70)
                Console.WriteLine("Congratulations, you passed!");
            else
                Console.WriteLine("Better luck next time!");
        }
    }
}
