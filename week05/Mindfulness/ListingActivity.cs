
public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>();


    public ListingActivity()
    {
        string name = "Listing";
        string description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        SetName(name);
        SetDescription(description);

        _prompts = new List<string>()
        {
            "Who are people that you love?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
        };

    }

    public void Run()
    {

        DisplayStartingMessage();
        Console.Clear();

        Console.WriteLine("Getting Ready...");
        ShowSpinner(3);
        Console.WriteLine();


        int duration = GetDuration();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($" ---{GetRandomPrompt()} ---");
        Console.Write($"You may begin in: ");
        ShowCountDown(3);
        Console.WriteLine();

        _count = 0;

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            _count += 1;

        }

        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }


    public string GetRandomPrompt()
    {
        if (_prompts == null || _prompts.Count == 0) return "";

        Random _rng = new Random();

        int index = _rng.Next(0, _prompts.Count);
        return _prompts[index];
    }


    // public List<string> GetListFromUser()
    // {

    // }
}