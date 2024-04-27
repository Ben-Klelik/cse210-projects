using System;

class Program
{
    static string Uppercase(string pizza)
    {
        return pizza.Substring(0,1).ToUpper() + pizza.Substring(1).ToLower();
    }
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string fname = Uppercase(Console.ReadLine());
        Console.Write("What is your last name? ");
        string lname = Uppercase(Console.ReadLine());
        Console.WriteLine($"Your name is {lname}, {fname} {lname}.");
    }
}