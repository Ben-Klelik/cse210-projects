class Reference
{
    string _book;
    string _chapter;
    string _verse;
    public Reference(string book, string chapter, string verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }
    public override string ToString()
    {
        return $"{_book} {_chapter}:{_verse}";
    }
}