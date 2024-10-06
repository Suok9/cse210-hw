using System;

class Program
{
    static void Main()
    {
        // Test constructors
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(5);
        Fraction f3 = new Fraction(6, 7);

        Console.WriteLine("Constructor Tests:");
        Console.WriteLine(f1.GetFractionString()); // 1/1
        Console.WriteLine(f2.GetFractionString()); // 5/1
        Console.WriteLine(f3.GetFractionString()); // 6/7

        // Test getters and setters
        f1.Numerator = 3;
        f1.Denominator = 4;
        Console.WriteLine("Getter/Setter Tests:");
        Console.WriteLine(f1.GetFractionString()); // 3/4
        Console.WriteLine(f1.Numerator); // 3
        Console.WriteLine(f1.Denominator); // 4

        // Test GetDecimalValue
        Console.WriteLine("Decimal Value Tests:");
        Console.WriteLine(f1.GetDecimalValue()); // 0.75
        Console.WriteLine(f2.GetDecimalValue()); // 5.0
        Console.WriteLine(f3.GetDecimalValue()); // 0.8571428571428571
    }
}
