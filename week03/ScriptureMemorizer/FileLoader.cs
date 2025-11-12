

using System.Text.Json.Nodes;

public static class FileLoader
{
    public static List<JsonObject> GetScripturesFromFile(string file)
    {
        var json = File.ReadAllText(file);
        var parsed = JsonNode.Parse(json);
        var scriptures = new List<JsonObject>();

        if (parsed?["scriptures"] is JsonArray arr)
        {
            foreach (var item in arr)
            {
                // Checks to see whether the JsonNode instance "item" is actually a JsonObject at runtime, and if so, it declares a new local variable obj of type JsonObject.
                if (item is JsonObject obj)
                    scriptures.Add(obj);

            }
        }
        return scriptures;
    }

}