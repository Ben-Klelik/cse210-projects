using System;

class Program
{
    private static int AskForDuration()
    {
        Console.WriteLine($"How long would you like to spend? (sec)");
        return int.Parse(Console.ReadLine());
    }
    static void Main(string[] args)
    {
        Menu menu = new(["Breathing Activity", "Listing Activity", "Reflection Activity", "Exit"]);
        Breathing breathing = new("Breathing Activity", "Welcome to the breathing activity.");
        while (true)
        {
            menu.Display();
            string input = menu.GetSelection();
            if (input == "Breathing Activity") {
                breathing.Start(AskForDuration());
            } else if (input == "Listing Activity") {

            } else if (input == "Reflection Activity") {

            } else if (input == "Exit") {
                break;
            } else {
                Console.WriteLine("Invalid input");
            }
        }
        Console.WriteLine($"Goodbye?");
    }
}