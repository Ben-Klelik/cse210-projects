class Listing : Activity
{
    public Listing(string title, string description)
    : base (title, description)
    {

        _prompts = [
            "What are you wearing?",
            "What made you feel good today?",
            "Where did you sit that was comfortable?",
            "What trinket happened to be useful to you today?",
            "Who are you happy about seeing today?",
            "Is there anything that you wish you had?",
            "How was the weather?",
            "What could you not part with today?",
            "What made your taste buds happy today?"
        ];
    }
    public override void Start()
    {
        base.Start();

        Console.WriteLine("Prepare to write down your responses to the upcoming prompts.");
        _delayAnimation.Start(5, 3.0);

        do
        {
            Console.Write($"- {RandomUnreadPrompt()}  "); Console.ReadLine();
        } while (!IsTimeUp());

        base.OnEnd();
    }
}