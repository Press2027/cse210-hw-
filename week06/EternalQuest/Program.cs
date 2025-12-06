using System;

namespace EternalQuest
{
    class Program
    {
        static void Main()
        {
            GoalManager manager = new GoalManager();
            int choice = 0;

            while (choice != 7)
            {
                Console.WriteLine($"\nYou have {manager.GetScore()} points.");
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Create Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Load");
                Console.WriteLine("7. Quit");
                Console.Write("Choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: CreateGoal(manager); break;
                    case 2: manager.ListGoals(); break;
                    case 3:
                        manager.ListGoals();
                        Console.Write("Which goal? ");
                        manager.RecordEvent(int.Parse(Console.ReadLine()) - 1);
                        break;
                    case 4:
                        Console.Write("Save file: ");
                        manager.Save(Console.ReadLine());
                        break;
                    case 5:
                        Console.Write("Load file: ");
                        manager.Load(Console.ReadLine());
                        break;
                }
            }
        }

        static void CreateGoal(GoalManager manager)
        {
            Console.WriteLine("1. Simple");
            Console.WriteLine("2. Eternal");
            Console.WriteLine("3. Checklist");

            int type = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Description: ");
            string desc = Console.ReadLine();

            Console.Write("Points: ");
            int points = int.Parse(Console.ReadLine());

            if (type == 1)
                manager.AddGoal(new SimpleGoal(name, desc, points));
            else if (type == 2)
                manager.AddGoal(new EternalGoal(name, desc, points));
            else if (type == 3)
            {
                Console.Write("Target Count: ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("Bonus: ");
                int bonus = int.Parse(Console.ReadLine());

                manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
            }
        }
    }
}
