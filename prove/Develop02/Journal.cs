
class Journal
{
    private Random _random = new();
    public List<Entry> _entries = [];
    private List<Prompt> _prompts = [];
    public string _filename;
    public bool _isUnsaved = false;
    private const string JOURNAL_STORAGE_PATH = "./journals/";
    public void ListEntries()
    {
        int i = 1;
        _entries.Sort((a, b) => b.CompareTo(a));
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"({i}) {entry._date} : {entry._label}");
            i++;
        }
    }
    public void NewEntry()
    {
        Entry entry = new()
        {
            _prompt = RandomPrompt()
        };
        entry._userInput = entry.GetInput();
        entry._date = DateTime.Now;
        Console.Write($"Enter the entry name: ");
        entry._label = Console.ReadLine();
        _entries.Add(entry);
        _isUnsaved = true;
    }
    public void AddPrompt(Prompt prompt)
    {
        _prompts.Add(prompt);
    }
    private Prompt RandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
    public async void Save()
    {
        if (!Directory.Exists(JOURNAL_STORAGE_PATH))
        {
            Directory.CreateDirectory(JOURNAL_STORAGE_PATH);
        }

        if (_filename == null)
        {
            Console.WriteLine($"Create a new text file to save to.");
            Console.Write("Filename: ");
            _filename = Console.ReadLine();
        }
        string filepath = JOURNAL_STORAGE_PATH + _filename;

        if (!File.Exists(filepath))
        {
            await using (FileStream file = File.Create(filepath)){}
        }
        
        using StreamWriter journalFile = new(filepath);
        foreach (var entry in _entries)
        {
            journalFile.WriteLine($"{entry.Encode()}");
        }

        _isUnsaved = false;
    }
    public void Load()
    {
        if (_isUnsaved && !ConfirmLossOfUnsavedChanges())
            return;

        if (Directory.Exists(JOURNAL_STORAGE_PATH))
        {
            Console.WriteLine($"Select a journal file to load from.");
            var listOfJournals = Directory.GetFiles(JOURNAL_STORAGE_PATH);
            DisplayListOfJournals(listOfJournals);
            Console.Write("File index: ");
            int fileIndex = int.Parse(Console.ReadLine());
            string filepath = listOfJournals[fileIndex];
            if (File.Exists(filepath))
            {
                _entries.Clear();
                string[] lines = File.ReadAllLines(filepath);

                foreach (string line in lines)
                {
                    Entry entry = new();
                    entry.Decode(line);
                    _entries.Add(entry);
                }
                _filename = filepath.Split("/").Last();
                Console.WriteLine($"{_filename} loaded.");
                _isUnsaved = false;
            }
            else
            {
                Console.WriteLine($"The selected file does not exist.");
            }
        }
        else
        {
            Console.WriteLine($"You don't have any journal entries yet.");
        }
    }

    private void DisplayListOfJournals(string[] list)
    {
        int i = 0;
        foreach(string fileName in list)
        {
            Console.WriteLine($"({i}) {fileName} with {File.ReadAllLines(fileName).Length} entries.");
            i++;
        }
    }

    public bool ConfirmLossOfUnsavedChanges()
    {
        Console.WriteLine($"You will lose unsaved changes if you continue. Are you sure? (Y/N)");
        return Console.ReadLine().ToLower() == "y";
    }
}