using System;
using System.Collections.Generic;


// 1. Added mood tracking (user rates their day 1–5).
// 2. Saves and loads journal data in JSON format for modern, structured storage.
// 3. Improved interface messages and added emoji feedback.

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        string choice = "";

        Console.WriteLine("📔 Welcome to your Personal Journal!Preston!\n");

        while (choice != "5")
        {
            Console.WriteLine("Menu (select):");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file (JSON)");
            Console.WriteLine("4. Load the journal from a file (JSON)");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1–5): ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, prompts);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save to (e.g., journal.json): ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load from (e.g., journal.json): ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    Console.WriteLine("👋 Goodbye! Keep journaling!");
                    break;

                default:
                    Console.WriteLine("⚠️ Invalid choice. Please try again.\n");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal, List<string> prompts)
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        int mood = 0;
        while (mood < 1 || mood > 5)
        {
            Console.Write("Rate your mood (1–5): ");
            int.TryParse(Console.ReadLine(), out mood);
        }

        string date = DateTime.Now.ToShortDateString();
        Entry newEntry = new Entry(date, prompt, response, mood);
        journal.AddEntry(newEntry);

        Console.WriteLine("✅ Entry added successfully!\n");
    }
}
