public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = currentCount;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        _currentCount++;

        if (_currentCount == _targetCount)
            return GetPoints() + _bonus;
        else
            return GetPoints();
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus()
    {
        string box = IsComplete() ? "[X] " : "[ ] ";
        return $"{box}{GetName()} — Completed {_currentCount}/{_targetCount}";
    }

    public override string Serialize()
    {
        return $"ChecklistGoal:{GetName()},{GetDescription()},{GetPoints()},{_targetCount},{_bonus},{_currentCount}";
    }
}
