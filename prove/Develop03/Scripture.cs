using Microsoft.VisualBasic;

class Scripture
{
    Word[] _verse;
    Reference _reference;
    Random random;
    int _wordsHidden = 0;
    bool[] _alreadyHidden;
    public Scripture(Word[] verse, Reference reference)
    {
        _verse = verse;
        _reference = reference;
    }
    public override string ToString()
    {
        return _reference + ": " + _verse;
    }

    public void HideWords()
    {
        // Find 3 different random words and set their hide property
        for (int i = 0; i < 3; i++)
        {
            if (_wordsHidden < _verse.Length)
                break;
            int randomVal;
            do 
            {
                randomVal = random.Next(0, _verse.Length - 1);
            } while (_verse[randomVal].GetIsHidden());
            _verse[randomVal].Hide();
            _wordsHidden++;
        } 
    }
}