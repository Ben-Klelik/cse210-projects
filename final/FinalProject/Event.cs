

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
}