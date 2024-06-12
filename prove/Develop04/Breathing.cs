class Breathing : Activity
{
    private Animation breathIn = new Animation(3, ["o-", "o<", "o|"]);
    private Animation breathHold = new Animation(3, ["O-", "-O", "O-"]);
    private Animation breathOut = new Animation(3, ["O<", "o|-=####", "-<  -==-", "--"]);
    public Breathing(string title, string description) : base(title, description){}
    public override void Start(int duration)
    {
        base.Start(duration);

        do
        {
            Console.Write("Breath in "); breathIn.Start(3); Console.Clear();
            Console.Write("Breath hold "); breathHold.Start(8); Console.Clear();
            Console.Write("Breath out "); breathOut.Start(5); Console.Clear();
        } while (GetTimeLeft() > 0);
    }
}