using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int num;


        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished. ");

        while (true)
        {
            Console.Write("Enter number: ");
            string userInput = Console.ReadLine();
            num = int.Parse(userInput);

            if (num == 0)
                break;

            numbers.Add(num);

        }

        int sum = numbers.Sum();
        double average = numbers.Average();
        int largestNum = numbers.Max();

        Console.WriteLine($"The sum is {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNum}");

    }
}