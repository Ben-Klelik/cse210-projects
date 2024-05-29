class Fraction
{
    private int _top;
    public int GetTop() { return _top; }
    public void SetTop(int val) { _top = val; }
    private int _bottom;
    public int GetBottom() { return _bottom; }
    public void SetBottom(int val) { _bottom = val; }
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}