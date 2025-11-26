
public class SimpleGoal : Goal
{
    protected bool _isComplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    { _isComplete = false; }

    public override void RecordEvent()
    {
        _isComplete = true;
    }


    public override bool IsComplete()
    {
        if (_isComplete) return true;
        else return false;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName};{_description};{_points};{_isComplete}";
    }


    public void SetComplete()
    {
        _isComplete = true;
    }

}