using Microsoft.VisualBasic;

class Scripture
{
    Word[] _verse;
    Reference _reference;
    Random random = new();
    int _wordsHidden = 0;
    public Scripture(Word[] verse, Reference reference)
    {
        _verse = verse;
        _reference = reference;
    }
    public override string ToString()
    {
        return _reference + "\n\t" + string.Join(' ', _verse.Select(word => word.ToString()));
    }

    public void HideWords()
    {
        // Find 3 different random words and set their hide property
        for (int i = 0; i < 3; i++)
        {
            // If there are no more words to hide then just don't do any of the following.
            if (_wordsHidden >= _verse.Length) break;

            // Select a verse at random until it is one that is unhidden
            int randomVal;
            do { randomVal = random.Next(0, _verse.Length);
            } while (_verse[randomVal].GetIsHidden());

            _verse[randomVal].Hide();
            _wordsHidden++;
        } 
    }

    public void ResetWords()
    {
        foreach (var word in _verse)
        {
            word.Unhide();
        }
        _wordsHidden = 0;
    }
}