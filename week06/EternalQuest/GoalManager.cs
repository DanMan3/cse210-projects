using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score;


    public GoalManager() { }

    public void Start()
    {
        var proceed = true;

        Console.Clear();

        do
        {
            // Console.Clear();
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine();
            Console.WriteLine("Menu Options: \n  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Record Event\n  6. Quit");
            Console.Write("Select a choice from the menu: ");
            var userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                CreateGoal();
            }
            else if (userChoice == "2")
            {
                ListGoalDetails();
            }
            else if (userChoice == "3")
            {
                SaveGoals();
            }
            else if (userChoice == "4")
            {
                LoadGoals();
            }
            else if (userChoice == "5")
            {
                RecordEvent();
            }
            else if (userChoice == "6")
            {
                proceed = false;
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
                Thread.Sleep(2000);
            }

        } while (proceed);
    }

    public void DisplayPlayerInfo() { }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetName()}");
        }
        Console.WriteLine();
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            if (_goals[i].IsComplete())
            {
                Console.WriteLine($"  {i + 1}. [X] {_goals[i].GetDetailsString()}");
            }
            else
            {
                Console.WriteLine($"  {i + 1}. [ ] {_goals[i].GetDetailsString()}");
            }
        }
        Console.WriteLine();
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are: \n  1. Simple Goal\n  2. Eternal Goal \n  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        var userChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        var nameOfGoal = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        var description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        var points = Console.ReadLine();

        if (userChoice == "1")
        {
            SimpleGoal simpleGoal = new SimpleGoal(nameOfGoal, description, points);
            _goals.Add(simpleGoal);
        }
        else if (userChoice == "2")
        {
            EternalGoal eternalGoal = new EternalGoal(nameOfGoal, description, points);
            _goals.Add(eternalGoal);
        }
        else if (userChoice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            var timesAccomplishedInput = Console.ReadLine();
            int.TryParse(timesAccomplishedInput, out int timesAccomplished);

            Console.Write("What is the bonus for accomplishing it that many times? ");
            var timesForBonusInput = Console.ReadLine();
            int.TryParse(timesForBonusInput, out int timesForBonus);

            ChecklistGoal checklistGoal = new ChecklistGoal(nameOfGoal, description, points, timesAccomplished, timesForBonus);
            _goals.Add(checklistGoal);
        }
        else
        {
            Console.WriteLine("Invalid choice. Please select a number 1-3.");
            Thread.Sleep(1500);
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        var userInputString = Console.ReadLine();

        if (!int.TryParse(userInputString, out int userInput) || userInput < 1 || userInput > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }
        int index = userInput - 1;

        var goal = _goals[index];

        if (goal is ChecklistGoal checklist)
        {
            bool wasComplete = checklist.IsComplete();
            goal.RecordEvent();

            var points = goal.GetPoints();
            _score += points;
            Console.WriteLine($"Congratulations! You have earned {points} points!");

            if (!wasComplete && checklist.IsComplete())
            {
                var bonus = checklist.GetBonus();
                _score += bonus;
            }
        }
        else
        {
            goal.RecordEvent();
            var points = goal.GetPoints();
            _score += points;
            Console.WriteLine($"Congratulations! You have earned {points} points!");
        }

        Console.WriteLine($"You now have {_score} points");
    }

    public void SaveGoals()
    {
        Console.WriteLine("What is the filename for the goal file? ");
        var file = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(file)) return;

        var lines = new List<string>
        {
            _score.ToString()
        };

        foreach (var goal in _goals)
        {
            lines.Add(goal.GetStringRepresentation());
        }

        File.WriteAllLines(file, lines);
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        var filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        var lines = File.ReadAllLines(filename);
        if (lines.Length == 0) return;

        // First line: The score
        if (!int.TryParse(lines[0], out _score)) _score = 0;

        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            var line = lines[i];

            var parts = line.Split(new[] { ':' }, 2);
            if (parts.Length < 2) continue;

            var type = parts[0];
            var payload = parts[1];
            var fields = payload.Split(';');

            var name = fields.Length > 0 ? fields[0] : "";
            var desc = fields.Length > 1 ? fields[1] : "";
            var points = fields.Length > 2 ? fields[2] : "0";

            if (type == "SimpleGoal")
            {
                var completion = fields.Length > 3 ? fields[3] : "";
                bool.TryParse(completion, out bool isComplete);

                var goal = new SimpleGoal(name, desc, points);
                if (isComplete)
                {
                    goal.SetComplete();
                }
                _goals.Add(goal);
            }
            else if (type == "EternalGoal")
            {
                var timesCompletedString = fields.Length > 3 ? fields[3] : "";
                int.TryParse(timesCompletedString, out int timesCompleted);
                var goal = new EternalGoal(name, desc, points, timesCompleted);
                _goals.Add(goal);

            }

            else if (type == "ChecklistGoal")
            {
                var numOfTimesString = fields.Length > 3 ? fields[3] : "0";
                if (!int.TryParse(numOfTimesString, out int numberOfTimesParsed))
                {
                    numberOfTimesParsed = 0;
                }

                var bonusString = fields.Length > 4 ? fields[4] : "0";
                int.TryParse(bonusString, out int bonusParsed);

                var amountCompletedString = fields.Length > 5 ? fields[5] : "0";
                int.TryParse(amountCompletedString, out int amountCompleted);


                var goal = new ChecklistGoal(name, desc, points, numberOfTimesParsed, bonusParsed, amountCompleted);

                _goals.Add(goal);
            }
        }

    }


}