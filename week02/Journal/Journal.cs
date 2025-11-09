

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine($"{entry._date} -- Prompt: {entry._promptText}");
            Console.WriteLine($"{entry._entryText}");
            Console.WriteLine();
        }

    }

    public void SaveToFile(string file)
    {
        if (_entries != null)
        {
            using (var outputFile = new StreamWriter(file))
            {
                foreach (var e in _entries)
                {
                    outputFile.WriteLine(e._date);
                    outputFile.WriteLine(e._promptText);
                    outputFile.WriteLine(e._entryText);
                    outputFile.WriteLine();

                }
            }
        }
    }

    public void LoadFromFile(string file)
    {
        var lines = System.IO.File.ReadAllLines(file);
        _entries.Clear();

        for (int i = 0; i < lines.Length;)
        {
            // skip empty lines
            if (string.IsNullOrWhiteSpace(lines[i]))
            {
                i++;
                continue;
            }

            // 3 lines per entry: date, prompt text, entry text
            if (i + 2 >= lines.Length) break;
            var date = lines[i++];
            var prompt = lines[i++];
            var entryLine = lines[i++];

            // decode \n back into actually new lines
            var entryText = entryLine.Replace("\\n", "\n");


            var e = new Entry();
            e._date = date;
            e._promptText = prompt;
            e._entryText = entryText;
            _entries.Add(e);
        }


    }


}