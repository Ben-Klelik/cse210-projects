using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        var rng = new Random();
        do
        {
            int input;
            int guesses = 0;
            int magicNumber = rng.Next(1, 101);
            Console.WriteLine("Guess a number between 1 and 100");
            do
            {
                Console.WriteLine("Guess: ");
                input = int.Parse(Console.ReadLine());
                if (input < magicNumber)
                {
                    Console.WriteLine("Guess Higher");
                }
                else if (input > magicNumber)
                {
                    Console.WriteLine("Guess Lower");
                }
                guesses++;
            } while (input != magicNumber);
            Console.WriteLine($"Correct! You got it in {guesses} guesses.");
            Console.WriteLine("Do you want to play again (Y/N)");
        } while (Console.ReadLine().ToLower() == "y");
    }
}