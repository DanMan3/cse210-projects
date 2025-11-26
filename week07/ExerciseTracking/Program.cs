using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>()
        {
            new Cycling(15, 7.0),
            new Running(20, 6.7),
            new Swimming(30, 10),
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}