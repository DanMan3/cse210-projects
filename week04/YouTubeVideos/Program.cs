using System;
using System.IO;
using System.Text.Json.Nodes;

class Program
{
    static void Main(string[] args)
    {

        var json = "videos.json";
        var jsonObjs = GetVideosFromFile(json);
        var constructedVideos = ConstructVideos(jsonObjs);


        Console.Clear();
        foreach (var video in constructedVideos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length (sec): {video.GetLength()}");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");

            Console.WriteLine();

            Console.WriteLine("------ Comments ------");
            var comments = video.GetComments();

            foreach (var comment in comments)
            {
                Console.WriteLine();
                Console.WriteLine(comment.GetCommenterName());
                Console.WriteLine(comment.GetText());
            }
            Console.WriteLine();
            Console.WriteLine("____________________");
            Console.WriteLine();
        }

    }



    static List<JsonObject> GetVideosFromFile(string file)
    {

        var json = File.ReadAllText(file);
        var parsed = JsonNode.Parse(json);
        var videos = new List<JsonObject>();


        // "parsed" parses to a JsonObject that compiles to a JsonArray, so cast it now and use the data.
        if (parsed is JsonArray arr)
        {
            foreach (var item in arr)
            {
                if (item is JsonObject obj)
                {
                    videos.Add(obj);
                }
            }
        }
        return videos;

    }


    public static List<Video> ConstructVideos(List<JsonObject> videosJsonObjects)
    {

        var listOfVideos = new List<Video>();

        foreach (var item in videosJsonObjects)
        {
            var comments = item["comments"];
            if (comments is JsonArray commentsArray)
            {
                var video = new Video(item["title"].ToString(), item["author"].ToString(), item["length"].ToString(), commentsArray);
                listOfVideos.Add(video);
            }

        }
        return listOfVideos;

    }
}