using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

[Serializable]
public abstract class Goal
{
    public string Name { get; set; }
    public int Points { get; set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public abstract void MarkComplete();
    public abstract string ToString();
}

[Serializable]
public class SimpleGoal : Goal
{
    public bool Completed { get; set; }

    public SimpleGoal(string name, int points) : base(name, points)
    {
        Completed = false;
    }

    public override void MarkComplete()
    {
        Completed = true;
    }

    public override string ToString()
    {
        string status = Completed ? "Completed" : "Not Completed";
        return $"{Name}: {Points} points, {status}";
    }
}

[Serializable]
public class EternalGoal : Goal
{
    public int Count { get; set; }

    public EternalGoal(string name, int points) : base(name, points)
    {
        Count = 0;
    }

    public override void MarkComplete()
    {
        Count++;
    }

    public override string ToString()
    {
        return $"{Name}: {Points} points, Completed {Count} times";
    }
}

[Serializable]
public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int Count { get; set; }

    public ChecklistGoal(string name, int points, int targetCount) : base(name, points)
    {
        TargetCount = targetCount;
        Count = 0;
    }

    public override void MarkComplete()
    {
        Count++;
    }

    public override string ToString()
    {
        string status = Count >= TargetCount ? "Completed" : $"Completed {Count}/{TargetCount} times";
        return $"{Name}: {Points} points, {status}";
    }
}

public class EternalQuest
{
    public List<Goal> Goals { get; set; }
    public int Score { get; set; }

    public EternalQuest()
    {
        Goals = new List<Goal>();
        Score = 0;
    }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public void MarkGoalComplete(string goalName)
    {
        var goal = Goals.FirstOrDefault(g => g.Name == goalName);
        if (goal != null)
        {
            goal.MarkComplete();
            Score += goal.Points;
            Console.WriteLine($"Goal '{goalName}' marked complete. Score: {Score}");
        }
        else
        {
            Console.WriteLine($"Goal '{goalName}' not found.");
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in Goals)
        {
            Console.WriteLine(goal);
        }
        Console.WriteLine($"Score: {Score}");
    }

    public void Save(string filename)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(filename, jsonString);
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error saving file: {e.Message}");
        }
    }

    public static EternalQuest Load(string filename)
    {
        try
        {
            if (File.Exists(filename))
            {
                string jsonString = File.ReadAllText(filename);
                return JsonSerializer.Deserialize<EternalQuest>(jsonString);
            }
            else
            {
                Console.WriteLine("File not found.");
                return null;
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error loading file: {e.Message}");
            return null;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        EternalQuest quest = new EternalQuest();
        string filename = "eternal_quest.json";

        if (File.Exists(filename))
        {
            Console.WriteLine("Loading saved quest...");
            quest = EternalQuest.Load(filename);
        }

        while (true)
        {
            Console.WriteLine("\nEternal Quest");
            Console.WriteLine("1. Add goal");
            Console.WriteLine("2. Mark goal complete");
            Console.WriteLine("3. Display goals");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Load");
            Console.WriteLine("6. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter goal name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter goal points: ");
                    if (!int.TryParse(Console.ReadLine(), out int points))
                    {
                        Console.WriteLine("Invalid points input. Please enter a number.");
                        break;
                    }
                    Console.Write("Enter goal type (simple, eternal, checklist): ");
                    string goalType = Console.ReadLine().ToLower();

                    Goal goal;
                    if (goalType == "simple")
                    {
                        goal = new SimpleGoal(name, points);
                    }
                    else if (goalType == "eternal")
                    {
                        goal = new EternalGoal(name, points);
                    }
                    else if (goalType == "checklist")
                    {
                        Console.Write("Enter target count: ");
                        if (!int.TryParse(Console.ReadLine(), out int targetCount))
                        {
                            Console.WriteLine("Invalid target count input. Please enter a number.");
                            break;
                        }
                        goal = new ChecklistGoal(name, points, targetCount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid goal type. Please enter 'simple', 'eternal', or 'checklist'.");
                        break;
                    }

                    quest.AddGoal(goal);
                    break;

                case "2":
                    Console.Write("Enter goal name to mark complete: ");
                    string goalName = Console.ReadLine();
                    quest.MarkGoalComplete(goalName);
                    break;

                case "3":
                    quest.DisplayGoals();
                    break;

                case "4":
                    quest.Save(filename);
                    Console.WriteLine("Quest saved.");
                    break;

                case "5":
                    quest = EternalQuest.Load(filename);
                    if (quest != null)
                    {
                        Console.WriteLine("Quest loaded.");
                    }
                    break;

                case "6":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}