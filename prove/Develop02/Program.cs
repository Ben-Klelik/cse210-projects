using System;

class Program
{
    static void AddPrompts(Journal journal)
    {
        journal.AddPrompt(new Prompt("What was the most fun this that happened today?"));
        journal.AddPrompt(new Prompt("Something nice."));
        journal.AddPrompt(new Prompt("Who played the biggest role in your life today?"));
        journal.AddPrompt(new Prompt("Something hard you did."));
        journal.AddPrompt(new Prompt("Something silly that you did."));
        journal.AddPrompt(new Prompt("How was your day today?"));
        journal.AddPrompt(new Prompt("Who did you talk to the most?"));
    }
    static void DisplayMenu()
    {
        Console.WriteLine($"(0) exit");
        Console.WriteLine($"(1) new entry");
        Console.WriteLine($"(2) display entry");
        Console.WriteLine($"(3) save");
        Console.WriteLine($"(4) load");
    }
    static void Main(string[] args)
    {
        Journal journal = new();
        AddPrompts(journal);
        int input_num;
        do
        {
            DisplayMenu();
            input_num = int.Parse(Console.ReadLine());
            switch (input_num)
            {
                case 1:
                    journal.NewEntry();
                    break;
                case 2:
                    Console.WriteLine($"Select an entry from the following list:\n(0) exit");
                    journal.ListEntries();
                    int list_input_num = int.Parse(Console.ReadLine());
                    if (list_input_num != 0)
                        Console.WriteLine($"{journal._entries[list_input_num - 1]}\n-------------\n");
                    break;
                case 3:
                    Console.WriteLine($"Saving...");
                    journal.Save();
                    Console.WriteLine($"Saved");
                    break;
                case 4:
                    Console.WriteLine($"Starting load process.");
                    journal.Load();
                    break;
                case 0: break;
                default:
                    Console.WriteLine($"invalid input");
                    break;
            }
        } while (!(input_num == 0 && (!journal._isUnsaved || journal.ConfirmLossOfUnsavedChanges())));
    }
}