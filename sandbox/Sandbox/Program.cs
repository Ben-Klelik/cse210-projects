using System;

class Program
{
    static void Main(string[] args)
    {
        Course course1 = new()
        {
            _className = "Prog. w/Classes",
            _color = "green",
            _courseCode = "CSE 210",
            _numberOfCredits = 2f
        };
        Console.WriteLine("Hello Sandbox World!");
    }
}