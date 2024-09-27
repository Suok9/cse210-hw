
using System;

namespace GuessMyNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            Random random = new Random();

            while (playAgain)
            {
                int magicNumber = random.Next(1, 101);
                int guesses = 0;

                Console.WriteLine("Welcome to Guess My Number!");

                while (true)
                {
                    Console.Write("What is your guess? ");
                    int guess;
                    if (int.TryParse(Console.ReadLine(), out guess) && guess >= 1 && guess <= 100)
                    {
                        guesses++;

                        if (guess < magicNumber)
                            Console.WriteLine("Higher");
                        else if (guess > magicNumber)
                            Console.WriteLine("Lower");
                        else
                        {
                            Console.WriteLine("You guessed it!");
                            Console.WriteLine($"It took you {guesses} guesses.");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 100.");
                    }
                }

                Console.Write("Would you like to play again? (yes/no): ");
                string response = Console.ReadLine().ToLower();
                playAgain = response == "yes";
            }
        }
    }
}
