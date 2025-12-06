using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public int GetScore() => _score;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void ListGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    public void RecordEvent(int index)
    {
        Goal g = _goals[index];
        int points = g.RecordEvent();
        _score += points;

        Console.WriteLine($"You gained {points} points!");
    }

    public void Save(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            sw.WriteLine(_score);

            foreach (Goal g in _goals)
                sw.WriteLine(g.Serialize());
        }
    }

    public void Load(string filename)
    {
        _goals.Clear();

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":");
            string type = parts[0];
            string[] data = parts[1].Split(",");

            if (type == "SimpleGoal")
            {
                AddGoal(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
            }
            else if (type == "EternalGoal")
            {
                AddGoal(new EternalGoal(data[0], data[1], int.Parse(data[2])));
            }
            else if (type == "ChecklistGoal")
            {
                AddGoal(new ChecklistGoal(
                    data[0], data[1], int.Parse(data[2]),
                    int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])
                ));
            }
        }
    }
}
