using System;
using System.Collections.Generic;


namespace JournalApp
{
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
                Console.WriteLine("5. Exit");

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
                    case 5:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }

    public class Journal
    {
        public List<JournalEntry> Entries { get; set; } = new List<JournalEntry>();

        public void WriteNewEntry()
        {
            Console.WriteLine("Write a new entry:");
            string entry = Console.ReadLine();
            Entries.Add(new JournalEntry(entry, DateTime.Now, "Your Location", "Sunny", "photo.jpg"));
        }

        public void DisplayJournal()
        {
            foreach (var entry in Entries)
            {
                Console.WriteLine($"Entry: {entry.Entry}\nDate: {entry.Date}\nLocation: {entry.Location}\nWeather: {entry.Weather}\nPhoto: {entry.Photo}\n");
            }
        }

        public void SaveJournalToFile()
        {
            string json = JsonConvert.SerializeObject(Entries, Formatting.Indented);
            File.WriteAllText("journal.json", json);
        }

        public void LoadJournalFromFile()
        {
            if (File.Exists("journal.json"))
            {
                string json = File.ReadAllText("journal.json");
                Entries = JsonConvert.DeserializeObject<List<JournalEntry>>(json);
            }
            else
            {
                Console.WriteLine("No journal file found.");
            }
        }
    }

    public class JournalEntry
    {
        public string Entry { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Weather { get; set; }
        public string Photo { get; set; }

        public JournalEntry(string entry, DateTime date, string location, string weather, string photo)
        {
            Entry = entry;
            Date = date;
            Location = location;
            Weather = weather;
            Photo = photo;
        }
    }
}
