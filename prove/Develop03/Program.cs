using System;

class Program
{
    
    static Word[] ToWords(string str)
    {
        string[] strWords = str.Split(' ');
        List<Word> listWords = [];
        foreach (string word in strWords)
        {
            listWords.Add(new Word (word));
        }
        return listWords.ToArray();
    }

    static void FillScriptures(List<Scripture> scriptures)
    {
        scriptures.Add( new Scripture(
            ToWords("Some scripture text."),
            new Reference("Hi", "23", "2-4")));
    }
    
    static void Main(string[] args)
    {
        List<Scripture> scriptures = [];
        FillScriptures(scriptures);
        Console.WriteLine("Hello Develop03 World!");
    }
}