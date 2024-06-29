class Checklist : Goal
{
    private int _count = 0;
    private int _bonus;
    private int _objective;
    public Checklist(int objective, int bonus, int pointReward, string title, string requirement)
    : base(pointReward, title, requirement)
    {
        _bonus = bonus;
        _objective = objective;
    }
    
    public void setCount(int n)
    {
        _count = n;
    }

    public override int ClaimReward()
    {
        if (_rewardClaimed)
            return 0;
        _rewardClaimed = true;
        _count++;
        if (_count == _objective)
            return _pointReward + _bonus;
        return _pointReward;
    }

    public override void Display()
    {
        Console.WriteLine($"[{_count}/{_objective}] {_title} :: {_requirement}");
    }

    override public void MarkComplete()
    {
        if (_count < _objective)
            _rewardClaimed = false;
    }

    public override string StringifyData()
    {
        return $"Checklist;;{_count};;{_objective};;{_title};;{_requirement};;{_bonus};;{_pointReward}";
    }
    

    public static Checklist ConstructFromString(string dataString)
    {
        var list = dataString.Split(";;");
        var count = int.Parse(list[1]);
        var objective = int.Parse(list[2]);
        var title = list[3];
        var requirement = list[4];
        var bonus = int.Parse(list[5]);
        var reward = int.Parse(list[6]);
        Checklist checklist = new(objective, bonus, reward, title, requirement);
        checklist.setCount(count);
        return checklist;
    }
}