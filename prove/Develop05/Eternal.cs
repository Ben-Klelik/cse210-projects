class Eternal(int pointReward, string title, string requirement) : Goal(pointReward, title, requirement)
{
    public override int ClaimReward()
    {
        if (_rewardClaimed)
            return 0;
        _rewardClaimed = true;
        return _pointReward;
    }

    public static Eternal ConstructFromString(string dataString)
    {
        var list = dataString.Split(";;");
        var title = list[1];
        var requirement = list[2];
        var reward = int.Parse(list[3]);
        return new(reward, title, requirement);
    }

    public override void Display()
    {
        Console.WriteLine($"- - - {_title} :: {_requirement}");
    }

    public override void MarkComplete()
    {
        _rewardClaimed = false;
    }

    public override string StringifyData()
    {
        return $"Eternal;;{_title};;{_requirement};;{_pointReward}";
    }
}