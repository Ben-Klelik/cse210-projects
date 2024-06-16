using System.Text;

class Animation
{
    private string[] _animationFrames = [];
    public Animation(string[] animationFrames)
    {
        _animationFrames = animationFrames;
    }
    public void Start(int duration)
    {
        Start(duration, duration);
    }
    public void Start(int duration, int cycles)
    {
        Start(duration, 1.0 / duration * _animationFrames.Length / cycles);
    }
    public void Start(int duration, double animationRate)
    {
        DateTime startTime = DateTime.Now;
        int i = 0;
        int size = _animationFrames.Length;
        int delay = (int)(1.0 / animationRate * 1000);
        while (DateTime.Now < startTime.AddSeconds(duration))
        {
            Console.Write($"{_animationFrames[i]}");
            Thread.Sleep(delay);
            Console.Write(
                new string('\b', _animationFrames[i].Length) +
                new string(' ', _animationFrames[i].Length) +
                new string('\b', _animationFrames[i].Length)
                );
            i = (i + 1) % size;
        }
        Console.Write("\n");
    }
}