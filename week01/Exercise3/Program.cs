using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {

        string playAgain = "";

        while (playAgain != "n")
        {

            Random randomGenerator = new Random();
            int magicNum = randomGenerator.Next(1, 101);

            Console.Write("What is the magic number? ");
            string num = Console.ReadLine();
            int numOfGuesses = 1;
            int userGuess = int.Parse(num);

            while (userGuess != magicNum)
            {
                if (userGuess > magicNum)
                {
                    Console.WriteLine("Lower");
                }
                else if (userGuess < magicNum)
                {
                    Console.WriteLine("Higher");
                }

                numOfGuesses += 1;
                string next = Console.ReadLine();
                userGuess = int.Parse(next);

            }
            Console.WriteLine("You guessed it!");
            Console.WriteLine($"Your total number of guesses: {numOfGuesses}");

            Console.Write("Would you like to play again? (y/n) ");
            playAgain = Console.ReadLine();

        }
    }
}
