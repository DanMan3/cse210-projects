

public class Comment
{
    private string _commenterName;
    private string _text;

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }


    public string getCommenterName()
    {
        return _commenterName;
    }

    public string getText()
    {
        return _text;
    }

}