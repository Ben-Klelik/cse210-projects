using System;
using System.Xml.Serialization;

class Program
{

    static List<Goal> goals = [];
    static int totalPoints = 0;
    const string goalsStorageFolderPath = "./goals/";

    static void Main(string[] args)
    {
        Directory.CreateDirectory("./goals/");

        string choice;
        do
        {
            Console.Clear();
            Console.WriteLine($"Total points: {totalPoints}");
            Console.WriteLine();
            DisplayMainMenu();
            choice = GetMainMenuChoice();
            Console.WriteLine();
            switch (choice)
            {
                case "Display":
                    DisplayGoals();
                    KeyPrompt();
                    break;
                case "New":
                    CreateNewGoal();
                    Console.WriteLine($"New goal created...");
                    DisplayGoals();
                    KeyPrompt();
                    break;
                case "Mark":
                    Console.WriteLine("Select a goal to complete.");
                    Goal goal = GetGoalChoice();
                    goal.MarkComplete();
                    int pointsObtained = goal.ClaimReward();
                    totalPoints += pointsObtained;
                    if (pointsObtained > 0)
                        Console.WriteLine($"\nYou got {pointsObtained} points!");
                    KeyPrompt();
                    break;
                case "Save":
                    SaveGoals();
                    Console.WriteLine($"Save successful");
                    KeyPrompt();
                    break;
                case "Load":
                    LoadGoals();
                    Console.WriteLine($"Load successful");
                    Thread.Sleep(400);
                    break;
                case "Exit":
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    throw new Exception($"Invalid choice {choice}");
            }
        } while (!choice.Equals("Exit"));
        Thread.Sleep(200);
        Console.WriteLine("\nGoodbye");
    }

    static void KeyPrompt()
    {
        Console.Write("Press any key to continue...");
        Console.ReadKey();
        Console.Write('\n');
    }

    static void DisplayMainMenu()
    {
        Console.WriteLine($"(1) Display Goals");
        Console.WriteLine($"(2) New Goal");
        Console.WriteLine($"(3) Mark Goal Complete");
        Console.WriteLine($"(4) Save Goals");
        Console.WriteLine($"(5) Load Goals");
        Console.WriteLine($"(6) Exit");
    }

    static string GetMainMenuChoice()
    {
        Console.Write($"Select an option (1-6): ");
        int i = int.Parse(Console.ReadLine()) - 1;
        string[] choices = ["Display", "New", "Mark", "Save", "Load", "Exit"];
        return choices[i];
    }

    static void CreateNewGoal()
    {
        Console.WriteLine("What Goal Type would you like to use?");
        Console.WriteLine("Simple (1), Checklist (2), or Eternal (3)");
        Console.Write("Goal Type: ");
        int goalType = int.Parse(Console.ReadLine());
        Console.WriteLine("What should the title be?");
        string title = Console.ReadLine();
        Console.WriteLine("What should the requirement be?");
        string requirement = Console.ReadLine();
        Console.WriteLine("How many points should be given after completion?");
        int pointReward = int.Parse(Console.ReadLine());
        if (goalType == 1) // Simple
        {
            goals.Add(new Simple(pointReward, title, requirement));
        }
        else if (goalType == 2) // Checklist
        {
            Console.WriteLine("How many completions before bonus?");
            int objective = int.Parse(Console.ReadLine());
            Console.WriteLine("How many points is the bonus worth?");
            int bonus = int.Parse(Console.ReadLine());
            goals.Add(new Checklist(objective, bonus, pointReward, title, requirement));
        }
        else if (goalType == 3) // Eternal
        {
            goals.Add(new Eternal(pointReward, title, requirement));
        }
        else
        {
            throw new Exception($"invalid goal type provided (1-3) got: {goalType}");
        }
        Console.WriteLine();
        Console.WriteLine("Goal created successfully");
    }

    static void SaveGoals()
    {
        Console.WriteLine("Type in the name you want to save the file as. Example: fun_goals");
        using StreamWriter outputFile = new(goalsStorageFolderPath + Console.ReadLine() + ".txt");
        outputFile.WriteLine($"Program;;{totalPoints}");
        foreach (var goal in goals)
        {
            outputFile.WriteLine(goal.StringifyData());
        }
    }

    static void LoadGoals()
    {
        Console.WriteLine("Type in the name of the file you want to load. Example: fun_goals");
        string[] lines = File.ReadAllLines(goalsStorageFolderPath + Console.ReadLine() + ".txt");

        goals.Clear();
        foreach (string line in lines)
        {
            string className = line.Split(";;")[0];
            switch (className)
            {
                case "Simple":
                    goals.Add(Simple.ConstructFromString(line));
                    break;
                case "Checklist":
                    goals.Add(Checklist.ConstructFromString(line));
                    break;
                case "Eternal":
                    goals.Add(Eternal.ConstructFromString(line));
                    break;
                case "Program":
                    totalPoints = int.Parse(line.Split(";;")[1]);
                    break;
                default:
                    throw new Exception("Class Name not recognized while reading file");
            }
        }
    }

    static void DisplayGoals()
    {
        Console.WriteLine(" -Goals List- ");
        foreach (Goal goal in goals)
        {
            goal.Display();
        }
        Console.WriteLine();
    }

    static Goal GetGoalChoice()
    {
        int i = 0;
        foreach (Goal goal in goals)
        {
            i++;
            Console.WriteLine($"({i}) : {goal}");
        }
        Console.Write($"Goal ({1} - {i}): ");
        return goals[int.Parse(Console.ReadLine()) - 1];
    }


}