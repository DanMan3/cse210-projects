using System;


public abstract class Activity
{
    protected string _date;
    protected double _minutes;

    public Activity(double minutes)
    {
        _date = DateTime.Now.ToString("dd MMM yyyy");
        _minutes = minutes;
    }



    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();


    public virtual string GetSummary()
    {

        return $"{_date} {GetType().Name} ({_minutes} min) - Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }


}