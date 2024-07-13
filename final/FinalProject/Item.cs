class Item
{
    public enum TYPE {Weapon, Armor, Consumable}
    public enum ADDTYPE {Flat, Multiplier}
    public enum STAT {Health, Defense, Strength}
    private string _name; public string GetName() { return _name; }
    private TYPE _type; public TYPE GetItemType() { return _type; }
    private STAT _stat; public STAT GetStat() { return _stat; }
    private ADDTYPE _addType;
    private double _amount;

    public Item(string name, TYPE type, STAT stat, ADDTYPE addType, double amount)
    {
        _name = name;
        _type = type;
        _stat = stat;
        _addType = addType;
        _amount = amount;
    }

    public Item(string name, TYPE type, double amount)
    {
        if (_type == TYPE.Consumable)
            throw new Exception("Type must be armor or weapon to use this constructor");

        _name = name;
        _type = type;
        if (_type == TYPE.Armor)
        {
            _stat = STAT.Defense;
            _addType = ADDTYPE.Multiplier;
        }
        else if (_type == TYPE.Weapon)
        {
            _stat = STAT.Strength;
            _addType = ADDTYPE.Flat;
        }
        _amount = amount;
    }

    public double ApplyItemStats(double amount)
    {
        return _addType == ADDTYPE.Flat ? amount + _amount : amount * _amount;
    }
}