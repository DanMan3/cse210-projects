
public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        string name = "Breathing";
        string description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";

        SetName(name);
        SetDescription(description);
    }


    public void Run()
    {
        DisplayStartingMessage();
        Console.Clear();

        int duration = GetDuration();





        Console.WriteLine("Getting Ready...");
        ShowSpinner(3);

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {

            Console.WriteLine();
            Console.Write("Breathe in...");
            ShowCountDown(6);
            Console.WriteLine();
            Console.Write("Now breathe out...");
            ShowCountDown(4);
            Console.WriteLine();


        }

        DisplayEndingMessage();

    }



}