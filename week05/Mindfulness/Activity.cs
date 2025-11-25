
public class Activity
{
    private string _name;
    private string _description;
    private int _duration;


    public Activity()
    {
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like your session? ");
        var userInput = Console.ReadLine();
        SetDuration(userInput);

    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {GetDuration()} seconds of the {_name} Activity.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {

        var spinnerCharacters = new List<string> { "|", "/", "-", "\\", }; // |/-\|/-\|

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = spinnerCharacters[i];
            Console.Write(s);
            Thread.Sleep(500);
            Console.Write("\b \b");

            i++;

            if (i >= spinnerCharacters.Count)
            {
                i = 0;
            }
        }



    }

    public void ShowCountDown(int second)
    {
        for (int i = second; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    private void SetDuration(string seconds)
    {
        int numOfSeconds;

        int.TryParse(seconds, out numOfSeconds);

        _duration = numOfSeconds;
    }

    public void SetName(string name)
    {
        _name = name;
    }
    public void SetDescription(string description)
    {
        _description = description;
    }


    public int GetDuration()
    {
        return _duration;
    }


}