// For extra credit, I made 50 text prompts, and my program loads all the journal prompts from a text file. I have a function at the bottom of this page
// that is named "loadPromptsFromFile" that runs before my PromptGenerator picks a random prompt.

using System;

class Program
{
    static void Main(string[] args)
    {
        var quit = false;
        var journal = new Journal();

        Console.WriteLine("Welcome to the Journal Program!");
        while (quit != true)
        {
            Console.WriteLine("Please Select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");


            var input = Console.ReadLine();
            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number (1-5).");
                continue;
            }



            if (choice == 1)
            {

                // Prompt the user
                var generatePrompt = new PromptGenerator();
                var journalPrompts = LoadPromptsFromFile();
                generatePrompt._prompts = journalPrompts;

                var userPrompt = generatePrompt.GetRandomPrompt();

                Console.WriteLine(userPrompt);
                Console.Write("> ");


                // Handle and store the user's response
                var userResponse = Console.ReadLine();
                var newEntry = new Entry();
                newEntry._promptText = userPrompt;
                newEntry._entryText = userResponse;


                journal.AddEntry(newEntry);


            }
            else if (choice == 2)
            {
                journal.DisplayAll();
                // Console.ReadLine();
            }
            else if (choice == 3)
            {
                Console.WriteLine("What is the filename?");
                Console.Write("> ");
                var userFileName = Console.ReadLine();
                journal.LoadFromFile(userFileName);
            }
            else if (choice == 4)
            {
                Console.WriteLine("What is the filename?");
                Console.Write("> ");
                var userFileName = Console.ReadLine();
                journal.SaveToFile(userFileName);
            }
            else if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
                quit = true;
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a valid option.");
            }

        }

    }


    public static List<string> LoadPromptsFromFile()
    {
        string fileName = "journal-prompts.txt";
        var lines = new List<string>(System.IO.File.ReadAllLines(fileName));

        return lines;
    }
}