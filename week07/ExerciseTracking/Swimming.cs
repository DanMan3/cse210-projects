

public class Swimming : Activity
{
    private double _laps;

    public Swimming(double minutes, double laps) : base(minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000 * 0.62;
    }

    public override double GetPace()
    {
        return _minutes / GetDistance();
    }

    public override double GetSpeed()
    {
        return GetDistance() / _minutes * 60;
    }

}