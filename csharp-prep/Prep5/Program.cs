using System;

class Program
{
    static void DisplayWelcome()
    {
        Console.WriteLine($"Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write($"Enter your name: ");
        return Console.ReadLine();
    }

    static string PromptUserNumber()
    {
        Console.Write($"Enter your favorite number: ");
        return Console.ReadLine();
    }

    static double SquareNumber(double num)
    {
        return num * num;
    }

    static void DisplayResult(string name, double squared)
    {
        Console.WriteLine($"{name}, the square of your number is {squared}");
    }

    static void Main(string[] args)
    {
        DisplayWelcome();
        var userName = PromptUserName();
        var userNum = double.Parse(PromptUserNumber());
        DisplayResult(userName, SquareNumber(userNum));
    }
}