class Prompt
{
    private string _text;

    public override string ToString()
    {
        return _text.ToString();
    }

    public Prompt(string text)
    {
        this._text = text;
    }
}