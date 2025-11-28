public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    // Constructor
    public MathAssignment(string studentName, string topic, string section, string problems)
        : base(studentName, topic) // Call base class constructor
    {
        _textbookSection = section;
        _problems = problems;
    }

    // Return math homework details
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}
