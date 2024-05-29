class Word
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
    public bool GetIsHidden()
    {
        return _isHidden;
    }
    public override string ToString()
    {
        if (_isHidden)
            return new string ('_', _text.Length);
        return _text;
    }
}