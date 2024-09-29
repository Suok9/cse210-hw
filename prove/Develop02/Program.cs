// Random prompts
// Date tracking
// Menu-driven interface
using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    // JournalEntry class
    public class JournalEntry
    {
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Date { get; set; }

        public JournalEntry(string prompt, string response, string date)
        {
            Prompt = prompt;
            Response = response;
            Date = date;
        }
    }

    // Journal class
    public class Journal
    {
        public List<JournalEntry> Entries { get; set; }

        public Journal()
        {
            Entries = new List<JournalEntry>();
        }

        public void AddEntry(JournalEntry entry)
        {
            Entries.Add(entry);
        }

        public void DisplayEntries()
        {
            foreach (var entry in Entries)
            {
                Console.WriteLine($"Date: {entry.Date}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                Console.WriteLine($"Response: {entry.Response}");
                Console.WriteLine();
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in Entries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }
        }

        public void LoadFromFile(string filename)
        {
            Entries.Clear();
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        JournalEntry entry = new JournalEntry(parts[1], parts[2], parts[0]);
                        Entries.Add(entry);
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            string[] prompts = {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };

            while (true)
            {
                Console.WriteLine("Journal Program");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display journal");
                Console.WriteLine("3. Save journal to file");
                Console.WriteLine("4. Load journal from file");
                Console.WriteLine("5. Exit");

                Console.Write("Choose an option: ");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            Random rand = new Random();
                            string prompt = prompts[rand.Next(prompts.Length)];
                            Console.WriteLine($"Prompt: {prompt}");
                            Console.Write("Response: ");
                            string response = Console.ReadLine();
                            string date = DateTime.Now.ToString("yyyy-MM-dd");
                            JournalEntry entry = new JournalEntry(prompt, response, date);
                            journal.AddEntry(entry);
                            break;
                        case 2:
                            journal.DisplayEntries();
                            break;
                        case 3:
                            Console.Write("Enter filename: ");
                            string filename = Console.ReadLine();
                            journal.SaveToFile(filename);
                            break;
                        case 4:
                            Console.Write("Enter filename: ");
                            filename = Console.ReadLine();
                            journal.LoadFromFile(filename);
                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please choose again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
}
