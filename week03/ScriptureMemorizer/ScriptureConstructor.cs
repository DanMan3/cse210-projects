using System.Text.Json.Nodes;

public static class ScriptureConstructor
{
    public static List<Scripture> ConstructScriptureObjects(List<JsonObject> scriptureJsonObjects)
    {
        var listOfScriptures = new List<Scripture>();

        foreach (var item in scriptureJsonObjects)
        {
            var book = item["book"].ToString() ?? "";
            // safely get chapter
            int chapter;
            var chapterNode = item["chapter"];
            if (chapterNode is JsonValue chVal)
                chapter = chVal.GetValue<int>();
            else if (!int.TryParse(chapterNode?.ToString(), out chapter))
                chapter = 0;

            // safely get verse
            int verse;
            var verseNode = item["verse"];
            if (verseNode is JsonValue vVal)
                verse = vVal.GetValue<int>();
            else if (!int.TryParse(verseNode?.ToString(), out verse))
                verse = 0;
            var text = item["text"].ToString() ?? "";
            int? endVerse = null;
            var endNode = item["end-verse"];
            if (endNode is JsonValue evVal)
                endVerse = evVal.GetValue<int>();
            else if (int.TryParse(endNode?.ToString(), out var ev))
                endVerse = ev;

            // choose constructor depending on whether there is an end verse or not
            Reference newReference = endVerse.HasValue
                ? new Reference(book, chapter, verse, endVerse.Value)
                : new Reference(book, chapter, verse);

            var newScripture = new Scripture(newReference, text);
            listOfScriptures.Add(newScripture);


        }
        return listOfScriptures;
    }
}