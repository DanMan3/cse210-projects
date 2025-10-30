using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);

        int d = Math.Abs(grade) % 10;

        string op;

        if (d >= 7)
        {
            op = "+";
        }
        else if (d <= 3)
        {
            op = "-";
        }
        else
        {
            op = null;
        }





        if (grade >= 90)
        {
            if (op == "+" || grade == 100)
            {
                op = null;
            }
            Console.Write($"Your grade is A{op}");
            Console.WriteLine();
        }
        else if (grade >= 80)
        {
            Console.Write($"Your grade is B{op}");
            Console.WriteLine();
        }

        else if (grade >= 70)
        {
            Console.Write($"Your grade is C{op}");
            Console.WriteLine();
        }
        else if (grade >= 60)
        {
            Console.Write($"Your grade is D{op}");
            Console.WriteLine();
        }
        else if (grade < 60)
        {
            Console.WriteLine("Your grade is F");
            Console.WriteLine();
        }
    }
}