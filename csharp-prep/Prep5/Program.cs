using System;
class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();
        string userName = GetUserName();
        int userNumber = GetUserNumber();
        int squaredNumber = CalculateSquare(userNumber);
        DisplayResult(userName, squaredNumber);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Square Calculator!");
    }

    static string GetUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine().Trim();
    }

    static int GetUserNumber()
    {
        while (true)
        {
            Console.Write("Please enter your favorite number: ");
            if (int.TryParse(Console.ReadLine(), out int number))
                return number;
            Console.WriteLine("Invalid input. Please enter a whole number.");
        }
    }

    static int CalculateSquare(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}.");
    }
}
