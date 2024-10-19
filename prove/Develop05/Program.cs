using System;
using System.Threading;

// Base class for activities
public abstract class Activity
{
    protected int duration;

    public Activity(int duration)
    {
        this.duration = duration;
    }

    public virtual void Start()
    {
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    public virtual void End()
    {
        Console.WriteLine("You have done a great job!");
        Thread.Sleep(2000); // Pause for 2 seconds
        Console.WriteLine($"Activity completed. Duration: {duration} seconds");
        Thread.Sleep(2000); // Pause for 2 seconds
    }
}

// Breathing activity
public class BreathingActivity : Activity
{
    public BreathingActivity(int duration) : base(duration) { }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
    }

    public void Run()
    {
        for (int i = 0; i < duration / 4; i++)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(2000); // Pause for 2 seconds
            Console.Write("....");
            Thread.Sleep(1000); // Pause for 1 second
            Console.WriteLine("Breathe out...");
            Thread.Sleep(2000); // Pause for 2 seconds
            Console.Write("....");
            Thread.Sleep(1000); // Pause for 1 second
        }
        End();
    }
}

// Reflection activity
public class ReflectionActivity : Activity
{
    private string[] prompts = new string[]
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = new string[]
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?"
    };

    public ReflectionActivity(int duration) : base(duration) { }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine(prompt);
    }

    public void Run()
    {
        Random rand = new Random();
        for (int i = 0; i < duration / 10; i++)
        {
            string question = questions[rand.Next(questions.Length)];
            Console.WriteLine(question);
            Thread.Sleep(5000); // Pause for 5 seconds
            Console.Write("Reflecting...");
            for (int j = 0; j < 5; j++)
            {
                Thread.Sleep(1000); // Pause for 1 second
                Console.Write(".");
            }
            Console.WriteLine();
        }
        End();
    }
}

// Listing activity
public class ListingActivity : Activity
{
    private string[] prompts = new string[]
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base(duration) { }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    public void Run()
    {
        Console.WriteLine("List your items:");
        int count = 0;
        for (int i = 0; i < duration / 10; i++)
        {
            Console.Write("Item " + (count + 1) + ": ");
            string item = Console.ReadLine();
            count++;
            Thread.Sleep(1000); // Pause for 1 second
        }
        Console.WriteLine($"You listed {count} items.");
        End();
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Select an activity (1-4): ");
            
            // Read and parse user choice
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue; // Ask for input again
            }

            if (choice == 4) // Exit option
            {
                Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                break; // Exit the loop
            }

            Console.Write("Enter the duration in seconds: ");
            int duration;
            if (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.WriteLine("Invalid duration. Please try again.");
                continue; // Ask for input again
            }

            Activity activity = null;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity(duration);
                    break;
                case 2:
                    activity = new ReflectionActivity(duration);
                    break;
                case 3:
                    activity = new ListingActivity(duration);
                    break;
            }

            activity.Start();
            if (activity is BreathingActivity breathingActivity)
            {
                breathingActivity.Run();
            }
            else if (activity is ReflectionActivity reflectionActivity)
            {
                reflectionActivity.Run();
            }
            else if (activity is ListingActivity listingActivity)
            {
                listingActivity.Run();
            }
        }
    }
}