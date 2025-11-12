
public class Word
{
    private string _text;
    private bool _isHidden;
    private bool _isWord;

    // Allow the boolean _isWord value to be accessed publically without exposing _isWord directly
    public bool CanHide => _isWord;


    public Word(string text, bool isWord = true)
    {
        _text = text;
        _isHidden = false;
        _isWord = isWord;
    }


    public void Hide()
    {
        if (_isWord) _isHidden = true;
    }
    public void Show()
    {
        _isHidden = false;
    }
    public bool IsHidden()
    {
        return _isHidden;
    }

    public bool IsWord()
    {
        return _isWord;
    }
    public string GetDisplayText()
    {
        if (!_isWord) return _text;
        if (!_isHidden) return _text;
        return new string('_', _text.Length);

    }
}