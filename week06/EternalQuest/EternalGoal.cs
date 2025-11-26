

public class EternalGoal : Goal
{
    private int _timesCompleted;
    public EternalGoal(string name, string description, string points, int timesCompleted = 0) : base(name, description, points)
    {
        _timesCompleted = timesCompleted;
    }


    public override void RecordEvent()
    {
        _timesCompleted++;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName};{_description};{_points};{_timesCompleted}";
    }

    public override string GetDetailsString()
    {
        return $"{_shortName}: ({_description}) -- Times completed: {_timesCompleted}";
    }

}