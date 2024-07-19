class Item
{
    public enum TYPE {Weapon, Armor, Consumable}
    public enum ADDTYPE {Flat, Multiplier}
    public enum STAT {Health, Defense, Strength}
    private string _name; public string GetName() { return _name; }
    private TYPE _type; public TYPE GetItemType() { return _type; }
    private STAT _stat; public STAT GetStat() { return _stat; }
    private ADDTYPE _addType; public ADDTYPE GetAddType() { return _addType; }
    private double _amount; public double GetAmount() { return _amount; }

    public Item(TYPE type, string name, STAT stat, ADDTYPE addType, double amount)
    {
        _name = name;
        _type = type;
        _stat = stat;
        _addType = addType;
        _amount = amount;
    }

    public Item(TYPE type, string name, double amount)
    {
        _name = name;
        _type = type;
        if (_type == TYPE.Armor)
        {
            _stat = STAT.Defense;
            _addType = ADDTYPE.Flat;
        }
        else if (_type == TYPE.Weapon)
        {
            _stat = STAT.Strength;
            _addType = ADDTYPE.Flat;
        }
        else if (_type == TYPE.Consumable)
        {
            _stat = STAT.Health;
            _addType = ADDTYPE.Flat;
        }
        _amount = amount;
    }

    public double ApplyItemStats(double amount)
    {
        return _addType == ADDTYPE.Flat ? amount + _amount : amount * _amount;
    }
}