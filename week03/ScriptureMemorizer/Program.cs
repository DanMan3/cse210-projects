// For extra credit, I added a FileLoader class that retrieves a scripture list from a Json file, which is also included with the project.

using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;


class Program
{
    static void Main(string[] args)
    {
        var file = "scriptures.json";
        var jsonObjs = FileLoader.GetScripturesFromFile(file);
        var constructedScriptures = ScriptureConstructor.ConstructScriptureObjects(jsonObjs);


        if (constructedScriptures == null || constructedScriptures.Count == 0)
        {
            Console.WriteLine("No scriptures available.");
            return;
        }

        var randomIndex = Random.Shared.Next(constructedScriptures.Count);
        var randomScripture = constructedScriptures[randomIndex];
        Console.WriteLine(randomScripture.GetDisplayText());


        string userInput = "";

        Console.Clear();
        Console.WriteLine(randomScripture.GetDisplayText());
        do
        {
            Console.WriteLine();
            Console.WriteLine("press enter to continue or type 'quit' to finish: ");
            userInput = Console.ReadLine();
            Console.Clear();
            randomScripture.HideRandomWords(1);
            Console.WriteLine(randomScripture.GetDisplayText());

            if (randomScripture.IsCompletelyHidden())
            {
                break;
            }


        } while (!userInput.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase));

    }




}