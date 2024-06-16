using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new(["Breathing Activity", "Listing Activity", "Reflection Activity", "Exit"]);
        Breathing breathing = new("Breathing", "This activity will help you make long, calming breaths.\nFirst you will breath in.\nSecond you will hold your breath.\nThird you will breath out.");
        Reflection reflection = new("Reflection", "This activity will help you reflect on your day.");
        Listing listing = new("Listing", "This activity will help you be grateful.");
        while (true)
        {
            Console.Clear();
            menu.Display();
            string input = menu.GetSelection();
            if (input == "Breathing Activity") {
                breathing.Start();
            } else if (input == "Listing Activity") {
                listing.Start();
            } else if (input == "Reflection Activity") {
                reflection.Start();
            } else if (input == "Exit") {
                break;
            } else {
                Console.WriteLine("Invalid input");
            }
        }
        Console.WriteLine($"Goodbye?");
    }
}