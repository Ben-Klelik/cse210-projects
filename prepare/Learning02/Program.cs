using System;

class Program
{
    static void Main(string[] args)
    {
        var job1 = new Job
        {
            _company = "Apple",
            _jobTitle = "Software Engineer",
            _startYear = "2003",
            _endYear = "2007"
        };
        var job2 = new Job
        {
            _company = "Amazon",
            _jobTitle = "Driver",
            _startYear = "2008",
            _endYear = "2010"
        };
        var job3 = new Job
        {
            _company = "Blizzard",
            _jobTitle = "Lead Engineer",
            _startYear = "2010",
            _endYear = "2022"
        };
        var resume1 = new Resume();
        resume1._name = "John Doe";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        resume1._jobs.Add(job3);
        resume1.Display();
    }
}