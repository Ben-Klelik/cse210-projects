abstract class Goal
{
    protected int _pointReward;
    protected string _title;
    protected string _requirement;
    protected bool _rewardClaimed;
    public Goal(int pointReward, string title, string requirement)
    {
        _pointReward = pointReward;
        _title = title;
        _requirement = requirement;
    }
    abstract public void MarkComplete();
    abstract public int ClaimReward();
    abstract public string StringifyData();
    abstract public void Display();
    public override string ToString()
    {
        return $"{_title} : {_requirement}";
    }
}