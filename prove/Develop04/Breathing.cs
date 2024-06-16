class Breathing(string title, string description) : Activity(title, description)
{
    private Animation breathIn = new Animation(["o- ", "o< ", "o| ", "O< ", "o-"]);
    private Animation breathHold = new Animation([" O-", "-O ", " O-", "-O "]);
    private Animation breathOut = new Animation(["O<        ", "o<-=####  ", "o<  -+==##", "o-  -==-  ", "o-        "]);
    public override void Start()
    {

        base.Start();
        
        do
        {
            Console.Write("Breath in "); breathIn.Start(3, 1);
            // Console.Clear();
            Console.Write("Breath hold "); breathHold.Start(8, 1);
            // Console.Clear();
            Console.Write("Breath out "); breathOut.Start(5, 1);
            // Console.Clear();
        } while (!IsTimeUp());

        base.OnEnd();
    }
}