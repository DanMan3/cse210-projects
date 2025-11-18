
using System.Text.Json.Nodes;

public class Video
{
    private string _title;
    private string _author;
    private string _length;
    private List<Comment> _comments;


    public Video(string title, string author, string length, JsonArray comments)
    {

        _title = title;
        _author = author;
        _length = length;
        _comments = CreateCommentObjects(comments);

    }


    private List<Comment> CreateCommentObjects(JsonArray commentsArr)
    {
        var commentsList = new List<Comment>();
        foreach (var c in commentsArr)
        {
            if (c is JsonObject co)
            {
                var commenter = co["commenterName"].ToString();
                var text = co["text"].ToString();
                var comment = new Comment(commenter, text);
                commentsList.Add(comment);
            }
        }

        return commentsList;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetAuthor()
    {
        return _author;
    }

    public int GetLength()
    {

        return GetLengthInSeconds();
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }


    public int GetLengthInSeconds()
    {
        if (string.IsNullOrWhiteSpace(_length)) return 0;

        var parts = _length.Split(':');
        int total = 0;
        int multiplier = 1; // seconds, then minutes, then hours...

        for (int i = parts.Length - 1; i >= 0; i--)
        {
            if (!int.TryParse(parts[i], out int value))
            {
                // invalid numeric part -> return 0 (or you can throw)
                return 0;
            }

            total += value * multiplier;
            multiplier *= 60;
        }

        return total;
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }


}