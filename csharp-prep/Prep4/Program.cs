using System;

class Program
{
    static void Main(string[] args)
    {
        int input;
        var numberList = new List<int>();
        Console.WriteLine("Give a list of numbers (enter 0 to end the list):");
        while (true)
        {
            Console.Write("n: ");
            input = int.Parse(Console.ReadLine());
            if (input == 0) { break; }
            numberList.Add(input);
        }

        double sum = numberList.Sum();
        double min = numberList.Where(n => n >= 0).Min();
        double max = numberList.Max();
        double avg = numberList.Average();
        Console.WriteLine($"Sum : {sum}");
        Console.WriteLine($"Average : {avg}");
        Console.WriteLine($"Largest num : {max}");
        Console.WriteLine($"Smallest positive : {min}");
        Console.WriteLine($"Ordered list : ");
        numberList.Sort();
        foreach (int num in numberList)
        {
            Console.WriteLine($": {num}");
        }
    }
}