using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you trust?",
        "What are your personal goals?",
        "Who did you inspire this week?",
        "When have you felt peace of mind recently?",
        "Who are your bestfriends?"
    };

    public ListingActivity() :
        base("Listing",
        "This activity helps you reflect by listing some good things in your life.")
    {}

    public void Run()
    {
        StartMessage();
        Console.Clear();

        Random rand = new Random();
        Console.WriteLine("List as many responses as you can to the prompt:\n");
        Console.WriteLine($"--- {_prompts[rand.Next(_prompts.Count)]} ---");

        Console.WriteLine("\nYou can  begin in...");
        Countdown(5);

        List<string> items = new List<string>();

        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
        Spinner(4);

        EndMessage();
    }
}
