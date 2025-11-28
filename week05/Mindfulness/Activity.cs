
// Base Class
using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration; // seconds

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected int GetDuration() => _duration;

    // Common starting message
    public void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} Activity ---\n");
        Console.WriteLine(_description);
        Console.Write("\nEnter duration in seconds: ");

        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("\nPrepare to begin...");
        Spinner(4);
    }

    // Common ending message
    public void EndMessage()
    {
        Console.WriteLine("\nGreat job!");
        Spinner(3);
        Console.WriteLine($"\nYou have completed the {_name} activity.");
        Console.WriteLine($"Total duration: {_duration} seconds.");
        Spinner(4);
    }

    // Spinner animation
    protected void Spinner(int seconds)
    {
        string[] seq = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(seq[i]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i = (i + 1) % seq.Length;
        }
    }

    // Countdown animation
    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
        Console.WriteLine();
    }
}
