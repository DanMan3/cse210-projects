

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, string points, int target, int bonus, int amountCompleted = 0) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }



    public override void RecordEvent()
    {
        _amountCompleted += 1;
    }

    public override bool IsComplete()
    {
        if (_amountCompleted >= _target) return true; else return false;
    }

    public override string GetDetailsString()
    {
        return $"{_shortName}: ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName};{_description};{_points};{_target};{_bonus};{_amountCompleted};";
    }

    public int GetBonus()
    {
        return _bonus;
    }


}



