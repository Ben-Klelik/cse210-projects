
abstract class Character
{
    protected string _name;
    protected int _level = 0;
    protected int _baseHealth;
    protected int _health;
    protected int _baseArmor;
    protected int _baseStrength;
    protected Item _armor;
    protected Item _weapon;
    protected Item _consumable;
    public enum BUFF_ADD_TYPE {Flat, Multiplier}
    public enum BUFF_STAT {Health, Defense, Strength}
    protected class Buff
    {
        BUFF_ADD_TYPE _addType;
        BUFF_STAT _stat;
        int _duration;
        double _amount;
        public Buff(BUFF_STAT stat, BUFF_ADD_TYPE addType, int duration)
        {
            _stat = stat;
            _addType = addType;
            _duration = duration;
        }
        public double ApplyBuffStats(double amount)
        {
            return _addType == BUFF_ADD_TYPE.Flat ? amount + _amount : amount * _amount;
        }
        public void ChangeDuration(int amount)
        {
            _duration += amount;
        }
        public void TickAway()
        {
            _duration--;
        }
        public bool DurationEnded()
        {
            return _duration <= 0;
        }
        public BUFF_STAT GetBuffedStat()
        {
            return _stat;
        }
        public bool IsStat(BUFF_STAT stat)
        {
            return stat == _stat;
        }
        public bool IsAddType(BUFF_ADD_TYPE type)
        {
            return type == _addType;
        }
    }
    protected List<Buff> activeBuffs = [];
    public void AddBuff(BUFF_STAT stat, BUFF_ADD_TYPE addType, int duration)
    {
        activeBuffs.Add(new Buff(stat, addType, duration));
    }
    public void DoBuffDecay()
    {
        activeBuffs.ForEach((buff) => buff.TickAway());
        activeBuffs.RemoveAll((buff) => buff.DurationEnded());

        // foreach (Buff buff in activeBuffs)
        //     buff.TickAway();
        

        // for (int i = activeBuffs.Count - 1; i >= 0; i--)
        //     if (activeBuffs[i].DurationEnded())
        //         activeBuffs.RemoveAt(i);
    }
    public Event swapEquipment;
    protected Event levelUp;

    public Character()
    {
        _baseHealth = 10000;
        _health = 100000;
        _baseArmor = 10000;
        _baseStrength = 10000;
    }

    public double ApplyBuffsToStat(double amount, BUFF_STAT stat)
    {
        foreach (Buff buff in activeBuffs)
            if (buff.IsStat(stat) && buff.IsAddType(BUFF_ADD_TYPE.Flat))
                amount = buff.ApplyBuffStats(amount);

        foreach (Buff buff in activeBuffs)
            if (buff.IsStat(stat) && buff.IsAddType(BUFF_ADD_TYPE.Multiplier))
                amount = buff.ApplyBuffStats(amount);

        return amount;
    }

    public double GetAttackDamage()
    {
        return ApplyBuffsToStat(_weapon.ApplyItemStats(_baseStrength), BUFF_STAT.Strength);
    }

    public void DisplayEquipment()
    {
        Console.WriteLine("Display equipment not implemented");
    }

    public void DisplayCharacterInfo()
    {
        Console.WriteLine($"Name: {_name}\nHealth: {_health}\nBase Health: {_baseHealth}\nBase Armor: {_baseArmor}\nBuffed Armor: {ApplyBuffsToStat(_baseArmor, BUFF_STAT.Defense)}\nBase Strength: {_baseStrength}\nBuffed Strength: {ApplyBuffsToStat(_baseStrength, BUFF_STAT.Strength)}");
    }
}