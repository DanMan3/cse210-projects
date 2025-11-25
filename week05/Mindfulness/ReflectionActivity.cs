
public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();


    public ReflectionActivity()
    {
        string name = "Reflecting";
        string description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

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



        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write($"You may begin in: ");
        ShowCountDown(6);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write($"> {GetRandomQuestion()} ");
            ShowSpinner(10);
            Console.WriteLine();
        }


        DisplayEndingMessage();


    }



    public string GetRandomPrompt()
    {
        if (_prompts == null || _prompts.Count == 0) return "";

        Random _rng = new Random();

        int index = _rng.Next(0, _prompts.Count);
        return _prompts[index];
    }


    public string GetRandomQuestion()
    {
        if (_questions == null || _questions.Count == 0) return "";

        Random _rng = new Random();

        int index = _rng.Next(0, _questions.Count);
        return _questions[index];
    }



}