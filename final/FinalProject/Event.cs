

class Event
{
    private Func<bool> _start;

    public Event(Func<bool> start)
    {
        _start = start;
    }

    public void Start()
    {
        _start();
    }

    public void Describe(string description)
    {
        throw new NotImplementedException();
    }

    public void Entitle(string title)
    {
        throw new NotImplementedException();
    }

    public void Compare(Item item1, Item item2)
    {
        throw new NotImplementedException();
    }
}