using System.Runtime.InteropServices;

class Menu
{
    private string[] _options;
    public Menu(string[] options)
    {
        _options = options;
    }
    public void Display()
    {
        Console.WriteLine("Select an option by its number.");
        int i = 1;
        foreach (string option in _options)
        {
            Console.WriteLine($"({i}){option}");
            i++;
        }
    }
    public string GetSelection()
    {
        int input;
        do
        {
            input = int.Parse(Console.ReadLine()) - 1;
            if (input < 0 || input >= _options.Length)
                Console.WriteLine($"Number must be between 1 and {_options.Length}");
        } while(input < 0 || input >= _options.Length);
        return _options[input];
    }
}