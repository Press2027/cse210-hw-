using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() :
        base("Breathing", 
        "This activity will help you relax by guiding you through slow breathing.\nFocus on your breath and clear your mind.")
    {}

    public void Run()
    {
        StartMessage();
        Console.Clear();

        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            Countdown(4);

            Console.Write("Breathe out...");
            Countdown(6);

            Console.WriteLine();
        }

        EndMessage();
    }
}
