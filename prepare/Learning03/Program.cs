using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Out.WriteLine($"{new Fraction().GetFractionString()}");
        Console.Out.WriteLine($"{new Fraction().GetDecimalValue()}");
        Console.Out.WriteLine($"{new Fraction(23).GetFractionString()}");
        Console.Out.WriteLine($"{new Fraction(23).GetDecimalValue()}");
        Console.Out.WriteLine($"{new Fraction(10, 13).GetFractionString()}");
        Console.Out.WriteLine($"{new Fraction(10, 13).GetDecimalValue()}");
    }
}