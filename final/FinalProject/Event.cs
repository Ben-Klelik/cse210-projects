

class Event
{
    protected Func<bool> _start;

    public Event(Func<bool> start)
    {
        _start = start;
    }

    public void Start()
    {
        while(_start()); // if the event returns true, it simply restarts the event
    }

    // public void Describe(string description)
    // {
    //     throw new NotImplementedException();
    // }

    // public void Entitle(string title)
    // {
    //     throw new NotImplementedException();
    // }

    // public void Compare(Item item1, Item item2)
    // {
    //     throw new NotImplementedException();
    // }
}