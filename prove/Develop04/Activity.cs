class Activity
{
    private string _activityName;
    private string _description;
    protected int _activityDuration;
    protected string[] _prompts;
    private List<int> _readPrompts = [];
    protected Animation _waitAnimation = new(["!", "l", "I", "j", "(", ")", "{", "}", "[", "]", "\\", "|", "/"]);
    protected Animation _delayAnimation = new(["00","OO","oo","..","oo","OO"]);
    protected DateTime _startTime;
    protected Random random;
    public Activity(string name, string description)
    {
        _activityName = name;
        _description = description;
        random = new();
    }
    protected string RandomUnreadPrompt()
    {
        int i;
        do
        {
            i = random.Next(_prompts.Length);
            if (!_readPrompts.Contains(i))
            {
                _readPrompts.Add(i);
                if (_readPrompts.Count >= _prompts.Length)
                    _readPrompts.Clear();
                return _prompts[i];
            }
        } while(true);
    }
    protected bool IsTimeUp()
    {
        return DateTime.Now > _startTime.AddSeconds(_activityDuration);
    }
    virtual public void Start()
    {
        _startTime = DateTime.Now;

        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName} Activity.\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long, in seconds, would you engage in this activity? ");
        _activityDuration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready... ");
        _delayAnimation.Start(3, 3.0);
        Console.Clear();
    }
    protected void OnEnd()
    {
        Console.WriteLine("Well done!!");
        _delayAnimation.Start(2, 3.0);
        Console.WriteLine($"\nThank you for completing {_activityDuration} seconds of {_activityName}");
        _delayAnimation.Start(3, 3.0);
        Console.Clear();
    }
}