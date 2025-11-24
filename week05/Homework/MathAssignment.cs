

public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;


    public MathAssignment(string name, string assignment, string textbookSection, string problems) : base(name, assignment)
    {
        _textbookSection = textbookSection;
        _problems = problems;

    }


    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}