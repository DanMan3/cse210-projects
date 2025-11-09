
public class Entry
{

    public string _date;
    public string _promptText;
    public string _entryText;

    public Entry()
    {
        _date = DateTime.Now.ToShortDateString();
        _promptText = string.Empty;
        _entryText = string.Empty;
    }

    public void Display()
    {
        Console.WriteLine($"{_date} -- Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");
    }


}