using System;



using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Journal App");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.Write("Choose an option: ");
            int choice = Convert.ToInt32(Console.ReadLine());

             switch (choice)
        {
            case 1:
                journal.WriteNewEntry();
                break;
            case 2:
                journal.DisplayJournal();
                break;
            case 3:
                journal.SaveJournalToFile();
                break;
            case 4:
                journal.LoadJournalFromFile();
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
     

       
        }
    }
}

class Journal
{
    public List<Entry> Entries { get; set; }

    public Journal()
    {
        Entries = new List<Entry>();
    }

    public void WriteNewEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        Entry entry = new Entry(prompt, response, DateTime.Now);
        Entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in Entries)
        {
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine();
        }
    }

    public void SaveJournalToFile()
    {
        Console.Write("Enter a filename: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in Entries)
            {
                writer.WriteLine($"{entry.Prompt}|{entry.Response}|{entry.Date}");
            }
        }
    }

    public void LoadJournalFromFile()
    {
        Console.Write("Enter a filename: ");
        string filename = Console.ReadLine();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                Entry entry = new Entry(parts[0], parts[1], DateTime.Parse(parts[2]));
                Entries.Add(entry);
            }
        }
    }

    private string GetRandomPrompt()
    {
        string[] prompts = new string[]
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        return prompts[new Random().Next(prompts.Length)];
    }
}

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public Entry(string prompt, string response, DateTime date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}
