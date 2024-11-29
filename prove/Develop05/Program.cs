using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    // Base Class
    abstract class Activity
    {
        protected string Name { get; set; }
        protected string Description { get; set; }
        protected int Duration { get; set; }

        public Activity(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void StartMessage()
        {
            Console.WriteLine($"Starting {Name}...");
            Console.WriteLine(Description);
            Console.Write("Enter duration (in seconds): ");
            Duration = int.Parse(Console.ReadLine());
            PauseWithAnimation("Prepare to begin...", 3);
        }

        public void EndMessage()
        {
            Console.WriteLine("Good job! You have completed the activity.");
            PauseWithAnimation($"{Name} completed for {Duration} seconds.", 3);
        }

        protected void PauseWithAnimation(string message, int seconds)
        {
            Console.WriteLine(message);
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"...{i}...");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        public abstract void Run();
    }

    // Derived Class: BreathingActivity
    class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity", "This activity helps you relax by focusing on your breathing.")
        {
        }

        public override void Run()
        {
            StartMessage();
            for (int i = 0; i < Duration / 6; i++) // Each cycle is 6 seconds
            {
                Console.WriteLine("Breathe in...");
                PauseWithAnimation("", 3);
                Console.WriteLine("Breathe out...");
                PauseWithAnimation("", 3);
            }
            EndMessage();
        }
    }

    // Derived Class: ReflectionActivity
    class ReflectionActivity : Activity
    {
        private List<string> Prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> Questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity() : base("Reflection Activity", "Reflect on times of strength and resilience.")
        {
        }

        public override void Run()
        {
            StartMessage();
            Random random = new Random();
            Console.WriteLine(Prompts[random.Next(Prompts.Count)]);
            PauseWithAnimation("Reflecting...", 3);

            int elapsed = 0;
            while (elapsed < Duration)
            {
                Console.WriteLine(Questions[random.Next(Questions.Count)]);
                PauseWithAnimation("", 5);
                elapsed += 5;
            }
            EndMessage();
        }
    }

    // Derived Class: ListingActivity
    class ListingActivity : Activity
    {
        private List<string> Prompts = new List<string>
        {
            "Who are people you appreciate?",
            "What are your personal strengths?",
            "Who are people you have helped this week?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base("Listing Activity", "List as many positive things as you can.")
        {
        }

        public override void Run()
        {
            StartMessage();
            Random random = new Random();
            Console.WriteLine(Prompts[random.Next(Prompts.Count)]);
            PauseWithAnimation("Get ready to list items...", 3);

            int count = 0;
            int elapsed = 0;
            DateTime startTime = DateTime.Now;

            while (elapsed < Duration)
            {
                Console.Write("Enter an item: ");
                Console.ReadLine();
                count++;
                elapsed = (int)(DateTime.Now - startTime).TotalSeconds;
            }

            Console.WriteLine($"You listed {count} items!");
            EndMessage();
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Activities");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                Activity activity = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        Thread.Sleep(1000);
                        continue;
                }

                activity.Run();
            }
        }
    }
}