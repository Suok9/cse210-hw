using System;
using System.Collections.Generic;
using System.IO;

// Base class for all goals
public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool IsCompleted { get; set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public abstract void RecordEvent();
}

// Simple goal class
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        IsCompleted = true;
        Console.WriteLine($"Completed {Name} and earned {Points} points!");
    }
}

// Eternal goal class
public class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded {Name} and earned {Points} points!");
    }
}

// Checklist goal class
public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }

    public ChecklistGoal(string name, int points, int targetCount) : base(name, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
    }

    public override void RecordEvent()
    {
        CurrentCount++;
        Console.WriteLine($"Recorded {Name} and earned {Points} points!");

        if (CurrentCount == TargetCount)
        {
            Console.WriteLine($"Completed {Name} and earned bonus {Points * 2} points!");
            IsCompleted = true;
        }
    }
}

// Program class
public class EternalQuest
{
    public List<Goal> Goals { get; set; }
    public int Score { get; set; }

    public EternalQuest()
    {
        Goals = new List<Goal>();
        Score = 0;
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        foreach (var goal in Goals)
        {
            Console.Write(goal.IsCompleted ? "[X] " : "[ ] ");
            Console.Write(goal.Name);

            if (goal is ChecklistGoal checklistGoal)
            {
                Console.Write($" ({checklistGoal.CurrentCount}/{checklistGoal.TargetCount})");
            }

            Console.WriteLine();
        }
    }

    public void RecordEvent(Goal goal)
    {
        goal.RecordEvent();
        Score += goal.Points;
    }

    public void SaveProgress(string filename)
    {
        using (var writer = new StreamWriter(filename))
        {
            writer.WriteLine(Score);
            foreach (var goal in Goals)
            {
                writer.WriteLine($"{goal.Name},{goal.Points},{goal.IsCompleted}");

                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{checklistGoal.TargetCount},{checklistGoal.CurrentCount}");
                }
            }
        }
    }

    public void LoadProgress(string filename)
    {
        using (var reader = new StreamReader(filename))
        {
            Score = int.Parse(reader.ReadLine());
            Goals.Clear();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var parts = line.Split(',');

                if (parts.Length == 3)
                {
                    Goal goal;
                    if (parts[0] == "Simple")
                    {
                        goal = new SimpleGoal(parts[1], int.Parse(parts[2]));
                    }
                    else if (parts[0] == "Eternal")
                    {
                        goal = new EternalGoal(parts[1], int.Parse(parts[2]));
                    }
                    else
                    {
                        var checklistGoal = new ChecklistGoal(parts[1], int.Parse(parts[2]), 0);
                        line = reader.ReadLine();
                        parts = line.Split(',');
                        checklistGoal.TargetCount = int.Parse(parts[0]);
                        checklistGoal.CurrentCount = int.Parse(parts[1]);
                        goal = checklistGoal;
                    }

                    goal.IsCompleted = bool.Parse(parts[2]);
                    Goals.Add(goal);
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var eternalQuest = new EternalQuest();

        // Create goals
        eternalQuest.Goals.Add(new SimpleGoal("Run a marathon", 1000));
        eternalQuest.Goals.Add(new EternalGoal("Read scriptures", 100));
        eternalQuest.Goals.Add(new ChecklistGoal("Attend temple", 50, 10));

        // Display goals
        eternalQuest.DisplayGoals();

        // Record events
        eternalQuest.RecordEvent(eternalQuest.Goals[0]);
        eternalQuest.RecordEvent(eternalQuest.Goals[1]);
        eternalQuest.RecordEvent(eternalQuest.Goals[2]);

        // Save progress
        eternalQuest.SaveProgress("progress.txt");

        // Load progress
        eternalQuest.LoadProgress("progress.txt");

        // Display goals and score after loading progress
        eternalQuest.DisplayGoals();
        Console.WriteLine($"Total Score: {eternalQuest.Score}");
    }
}