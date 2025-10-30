using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);

    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string num = Console.ReadLine();
        int userNum = int.Parse(num);
        return userNum;
    }

    static int SquareNumber(int userNumber)
    {
        int squared = userNumber * userNumber;
        return squared;

    }

    static void DisplayResult(string userName, int userNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {userNumber}");
    }
}