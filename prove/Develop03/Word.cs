using System.Text;
using System.Text.RegularExpressions;

partial class Word
{
    string _text;
    bool _isHidden;
    public Word(string text)
    {
        _text = text;
    }
    public void Hide()
    {
        _isHidden = true;
    }
    public void Unhide()
    {
        _isHidden = false;
    }
    public bool GetIsHidden()
    {
        return _isHidden;
    }
    public override string ToString()
    {
        if (_isHidden)
        {
            return EachLetter().Replace(_text, "_");
        }
        return _text;
    }

    [GeneratedRegex("[A-z]")]
    private static partial Regex EachLetter();
}