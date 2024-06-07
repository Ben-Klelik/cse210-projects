using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new("Himdo Nominim", "Architechture");
        Console.WriteLine(assignment.GetSummary());
        MathAssignment mathAssignment = new("Himdo Nominimim", "Math", "4.5", "1-40");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
        WritingAssignment writingAssignment = new("Himdi Monimin", "English 250", "The great gastby by Bigmin Manly");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}