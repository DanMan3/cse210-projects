using System;

class Program
{
    static void Main(string[] args)
    {
        var firstNumber = new Fraction();
        var secondNumber = new Fraction(4);
        var thirdNumber = new Fraction(100, 13);
        var fourthNumber = new Fraction(10, 5);

        Console.WriteLine($"{firstNumber.GetFractionString()} --> {firstNumber.GetDecimalValue()}");
        Console.WriteLine($"{secondNumber.GetFractionString()} --> {secondNumber.GetDecimalValue()}");
        Console.WriteLine($"{thirdNumber.GetFractionString()} --> {thirdNumber.GetDecimalValue()}");
        Console.WriteLine($"{fourthNumber.GetFractionString()} --> {fourthNumber.GetDecimalValue()}");
    }

}