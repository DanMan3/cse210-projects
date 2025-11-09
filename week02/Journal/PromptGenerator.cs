
public class PromptGenerator
{
    public List<String> _prompts;
    private Random _randomPrompt = new Random();

    public string GetRandomPrompt()
    {
        if (_prompts == null || _prompts.Count == 0)
        {
            return string.Empty;
        }

        int index = _randomPrompt.Next(_prompts.Count);
        return _prompts[index];
    }
}