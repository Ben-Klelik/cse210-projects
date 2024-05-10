public class Resume
{
  public string _name;
  public List<Job> _jobs = [];
  public void Display()
  {
    Console.WriteLine($"{_name} has the following jobs:");
    foreach (Job job in _jobs)
    {
      job.Display();
    }
  }
}