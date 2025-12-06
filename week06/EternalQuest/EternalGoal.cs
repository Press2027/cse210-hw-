public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return GetPoints();  // Always gains points
    }

    public override bool IsComplete() => false;

    public override string GetStatus()
    {
        return "[∞] " + GetName();
    }

    public override string Serialize()
    {
        return $"EternalGoal:{GetName()},{GetDescription()},{GetPoints()}";
    }
}
