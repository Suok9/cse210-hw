using System;
using System.Collections.Generic;

// Base Activity class
public abstract class Activity
{
    private DateTime date;
    private int minutes;

    public Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public DateTime Date { get { return date; } }
    public int Minutes { get { return minutes; } }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} {GetType().Name} ({Minutes} min): Distance {GetDistance():F2} miles, Speed {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}

// Running activity class
public class Running : Activity
{
    private double distance;

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance() { return distance; }
    public override double GetSpeed() { return (distance / Minutes) * 60; }
    public override double GetPace() { return Minutes / distance; }
}

// Cycling activity class
public class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetDistance() { return speed * Minutes / 60; }
    public override double GetSpeed() { return speed; }
    public override double GetPace() { return 60 / speed; }
}

// Swimming activity class
public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance() { return laps * 50 / 1000 * 0.62; }
    public override double GetSpeed() { return (GetDistance() / Minutes) * 60; }
    public override double GetPace() { return Minutes / GetDistance(); }
}

class Program
{
    static void Main(string[] args)
    {
        // Create activities
        Activity running = new Running(new DateTime(2022, 11, 3), 30, 3);
        Activity cycling = new Cycling(new DateTime(2022, 11, 3), 30, 6);
        Activity swimming = new Swimming(new DateTime(2022, 11, 3), 30, 20);

        // Add activities to list
        List<Activity> activities = new List<Activity>();
        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        // Display summaries
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}