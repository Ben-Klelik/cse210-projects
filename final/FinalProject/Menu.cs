using System.Dynamic;

class Menu
{
    string _menuTitle;
string _inputPrompt;
    List<string> _options = [];
    List<string> _optionNames = [];

    public Menu(string title)
    {
        _menuTitle = title;
        _inputPrompt = null;
    }

    public Menu(string title, string inputPrompt)
    {
        _menuTitle = title;
        _inputPrompt = inputPrompt;
    }

    string GetInputPrompt()
    {
        if (_inputPrompt is not null)
            return _inputPrompt;
        return $"Choose (1-{_options.Count}): ";
    }

    public void Display()
    {
        Console.WriteLine(_menuTitle);
        int i = 0;
        foreach (var option in _options)
        {
            Console.WriteLine($"({i}) {option}");
        }
        Console.Write(_inputPrompt);
    }

    public int SelectByNum()
    {
        return int.Parse(Console.ReadLine());
    }

    public string GetNameFromNum(int num)
    {
        return _optionNames[num];
    }

    public void AddOption(string description, string name)
    {
        _options.Add(description);
        _optionNames.Add(name);
    }

    public void RemoveOption(int num)
    {
        _options.RemoveAt(num);
        _optionNames.RemoveAt(num);
    }

    public void InsertOption(string description, string name, int num)
    {
        _options.Insert(num, description);
        _optionNames.Insert(num, name);
    }

    public void ClearOptions()
    {
        _options.Clear();
        _optionNames.Clear();
    }

    public string GetDescriptionFromNum(int num)
    {
        return _optionNames[num];
    }

    public int? FindOptionByName(string name)
    {
        for (int i = 0; i < _options.Count; i++)
        {
            if (_options[i].Equals(name))
                return i;
        }
        return null;
    }
}