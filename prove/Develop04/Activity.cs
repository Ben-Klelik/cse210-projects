class Activity
{
    private string _name;
    private string _description;
    protected int _activityDuration;
    protected string[] _prompts;
    private int[] _readPrompts;
    protected Animation waitAnimation = new(2.0, ["#", "!"]);
    protected Animation delayAnimation = new(0.5, ["00","OO","oo","..","oo","OO"]);
    protected DateTime _startTime;
    private Random random;
    public Activity(string name, string description)
    {
        _name = name;
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
                _readPrompts.Append(i);
                if (_readPrompts.Length >= _prompts.Length)
                    ClearReadPrompts();
                return _prompts[i];
            }
        } while(true);
    }
    protected int GetTimeLeft()
    {
        return (DateTime.Now - _startTime).Seconds;
    }
    private void ClearReadPrompts()
    {
        _readPrompts = [];
    }
    
    virtual public void Start(int duration)
    {
        _startTime = DateTime.Now;
        _activityDuration = duration;
    }
    protected void OnEnd()
    {
        
    }
}