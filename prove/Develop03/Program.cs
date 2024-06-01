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
        return [.. listWords];
    }

    static void FillScriptures(List<Scripture> scriptures)
    {
        scriptures.Add( new Scripture(
            ToWords("If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him."),
            new Reference("James", "1", "5")));
        scriptures.Add( new Scripture(
            ToWords("But the wisdom that is from above is first pure, then peaceable, gentle, and easy to be intreated, full of mercy and good fruits, without partiality, and without hypocrisy."),
            new Reference("James", "3", "17")
        ));
        scriptures.Add( new Scripture(
            ToWords("Happy is the man that findeth wisdom, and the man that getteth understanding. For the merchandise of it is better than the merchandise of silver, and the gain thereof than fine gold. She is more precious than rubies: and all the things thou canst desire are not to be compared unto her. Length of days is in her right hand; and in her left hand riches and honour. Her ways are ways of pleasantness, and all her paths are peace. She is a tree of life to them that lay hold upon her: and happy is every one that retaineth her."),
            new Reference("Proverbs", "3", "13-18")
        ));
        scriptures.Add( new Scripture(
            ToWords("The way of a fool is right in his own eyes: but he that hearkeneth unto counsel is wise."),
            new Reference("Proverbs", "12", "15")
        ));
        scriptures.Add( new Scripture(
            ToWords("For I will give you a mouth and wisdom, which all your adversaries shall not be able to gainsay nor resist."),
            new Reference("Luke", "21", "15")
        ));
        // scriptures.Add( new Scripture(
        //     ToWords(""),
        //     new Reference("", "", "")
        // ));
    }
    
    static void Main(string[] args)
    {
        List<Scripture> scriptures = [];
        FillScriptures(scriptures);
        string input;
        Random random = new();
        Scripture selectedScripture = scriptures[random.Next(scriptures.Count)];
        Console.Clear();
        Console.WriteLine("Your scripture has been selected. Remember well:\n");
        while (true)
        {
            Console.WriteLine(selectedScripture);
            Console.WriteLine("\nPress enter to continue, type \"q\" to exit and \"r\" to reset.");
            input = Console.ReadLine();
            if (input.ToLower() == "q")
                break;
            else if (input.ToLower() == "r")
                selectedScripture.ResetWords();
            else
                selectedScripture.HideWords();
            Console.Clear();
            Console.WriteLine("\n");
        }
    }
}