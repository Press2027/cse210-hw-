using System;
using System.Threading;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time you stood up for the people.",
        "Think of a time you did difficult job.",
        "Think of a time you cared for the need.",
        "Think of a time you sacrifice yourself for the sake of your friend."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "How did you feel during this experience?",
        "Have you ever done anything like this before?",
        "What did you learn from this experience?",
        "How can this help you in the future?"
    };

    public ReflectionActivity() :
        base("Reflection", 
        "This activity will help you reflect on times when you showed strength and resilience.")
    {}

    public void Run()
    {
        StartMessage();
        Console.Clear();

        // Show random prompt
        Random rand = new Random();
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($"--- {_prompts[rand.Next(_prompts.Count)]} ---\n");
        Console.WriteLine("Press ENTER when you're ready to continue.");
        Console.ReadLine();

        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        Console.Clear();
        Console.WriteLine("Now reflect on the following questions:\n");

        while (DateTime.Now < endTime)
        {
            string q = _questions[rand.Next(_questions.Count)];
            Console.WriteLine(q);
            Spinner(5); // pause with spinner
            Console.WriteLine();
        }

        EndMessage();
    }
}
