class Simple(int pointReward, string title, string requirement) : Goal(pointReward, title, requirement)
{

    private bool _completed = false;

    public void SetCompleted(bool completed) { _completed = completed; }

    public override int ClaimReward()
    {
        if (_rewardClaimed)
            return 0;
        _rewardClaimed = true;
        return _pointReward;
    }

    public static Simple ConstructFromString(string dataString)
    {
        var list = dataString.Split(";;");
        var title = list[1];
        var requirement = list[2];
        var reward = int.Parse(list[3]);
        Simple simple = new(reward, title, requirement);
        simple.SetCompleted(list[4].Equals("t"));
        return simple;
    }

    public override void Display()
    {
        char completionMark = _completed ? 'X' : ' ';
        Console.WriteLine($"[ {completionMark} ] {_title} :: {_requirement}");
    }

    public override void MarkComplete()
    {
        _rewardClaimed = false;
        _completed = true;
    }

    public override string StringifyData()
    {
        return $"Simple;;{_title};;{_requirement};;{_pointReward};;{(_completed ? 't':'f')}";
    }
}