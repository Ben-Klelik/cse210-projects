class Reflection(string title, string description) : Activity(title, description)
{
    private string[] _basePrompt = [
        "Think of a time you talked to someone",
        "Think of a time you helped someone",
        "Think of a time you touched someone",
        "Think of a time you judged someone",
    ];

    public override void Start()
    {
        base.Start();

        _prompts = [
            "What were you thinking while you did that?",
            "Why were you thinking the way that you were?",
            "How were you feeling while you did this?",
            "How did you feel after you did this?",
            "How do you feel after thinking back to that time?",
        ];

        Console.WriteLine("Consider the following prompt, then press enter when you have something in mind.\n");

        Console.WriteLine($"---- {_basePrompt[random.Next(_basePrompt.Length)]} ----");
        Console.ReadLine();
        _delayAnimation.Start(2, 3.0);

        do
        {
            Console.Write($"- {RandomUnreadPrompt()}  "); _waitAnimation.Start(15, 1.0); Console.Write("\n");
        } while (!IsTimeUp());

        base.OnEnd();
    }
}