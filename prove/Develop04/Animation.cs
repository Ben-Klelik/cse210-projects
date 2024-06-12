class Animation
{
    private double _animationRate = 1.0;
    private string[] _animationFrames = [];
    public Animation(double animationRate, string[] animationFrames)
    {
        _animationRate = animationRate;
        _animationFrames = animationFrames;
    }
    public void Start(int duration)
    {
        DateTime startTime = DateTime.Now;
        int i = 0;
        int size = _animationFrames.Length;
        int delay = (int)(1.0 / _animationRate * 1000);
        while (DateTime.Now < startTime.AddSeconds(duration))
        {
            Console.Write($"{_animationFrames[i]}");
            Thread.Sleep(delay);
            for (int _ = 0; _ < _animationFrames[i].Length; _++)
            {
                Console.Write("\b \b");
            }
            i = (i + 1) % size;
        }
    }
}