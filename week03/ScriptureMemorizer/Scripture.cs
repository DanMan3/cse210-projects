
using System.Text.RegularExpressions;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private List<int> _hiddenWords = new List<int>();

    public Scripture(Reference Reference, string text)
    {
        _reference = Reference;

        var words = Regex.Matches(text, @"\p{L}+['-]?\p{L}*|\p{N}+|[^\s\p{L}\p{N}]|\s+");

        foreach (Match t in words)
        {
            // Is it a word? If so, it can be hidden
            var isWord = t.Value;
            var canHide = Regex.IsMatch(isWord, @"^\p{L}+['-]?\p{L}*$|^\p{N}+$");
            var word = new Word(isWord, canHide);
            _words.Add(word);
        }

    }



    public void HideRandomWords(int numberToHide)
    {

        for (var i = 0; i < numberToHide; i++)
        {

            var candidates = _words
            // Pair each word with its index
            .Select((w, idx) => new { w, idx })
            // Keep only hideable, not yet hidden words
            .Where(x => x.w.CanHide && !x.w.IsHidden())
            // Yields a list of indices (indexes) that are safe to hide
            .Select(x => x.idx)
            .ToList(); // candidates = list<int> that are valid words that can be hidden

            if (candidates.Count == 0)
                break;


            var wordsToHide = Random.Shared.Next(candidates.Count);
            var wordIndex = candidates[wordsToHide];

            _words[wordIndex].Hide();
            if (!_hiddenWords.Contains(wordIndex))
                _hiddenWords.Add(wordIndex);
        }
    }

    public string GetDisplayText()
    {
        var editedWords = string.Concat(_words.Select(w => w.GetDisplayText()));
        editedWords = Regex.Replace(editedWords, @"\s+", " ").Trim();

        var scriptureVerse = _reference.GetDisplayText();

        var displayText = $"{scriptureVerse} {editedWords}";

        return displayText;
    }

    public bool IsCompletelyHidden()
    {
        // returns true only if every word is hidden
        var status = _words.Where(w => w.CanHide).All(w => w.IsHidden());


        return status;


    }

}