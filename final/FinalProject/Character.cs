
abstract class Character
{
    protected string _name;
    protected int _level = 1; public int GetLevel(){ return _level; }
    protected int _baseHealth;
    protected int _health;
    protected int _baseArmor;
    protected int _baseStrength;
    protected Item _armor;
    protected Item _weapon;
    // protected Item _consumable;
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
    // public Event swapEquipment;
    // protected Event levelUp;
    public Menu BattleOptions = new("What will you do?");

    public Character()
    {
        _baseHealth = 10000;
        _health = 100000;
        _baseArmor = 10000;
        _baseStrength = 10000;
    }

    public int ApplyBuffsToStat(double amount, BUFF_STAT stat)
    {
        foreach (Buff buff in activeBuffs)
            if (buff.IsStat(stat) && buff.IsAddType(BUFF_ADD_TYPE.Flat))
                amount = buff.ApplyBuffStats(amount);

        foreach (Buff buff in activeBuffs)
            if (buff.IsStat(stat) && buff.IsAddType(BUFF_ADD_TYPE.Multiplier))
                amount = buff.ApplyBuffStats(amount);

        return (int) amount;
    }

    public int GetAttackDamage()
    {
        return ApplyBuffsToStat(_weapon.ApplyItemStats(_baseStrength), BUFF_STAT.Strength);
    }

    public int Damage(int amount)
    {
        double armor = _baseArmor;
        if (_armor.GetStat() == Item.STAT.Defense)
        {
            armor = _armor.ApplyItemStats(_baseArmor);
        }
        if (_weapon.GetStat() == Item.STAT.Defense)
        {
            armor = _weapon.ApplyItemStats(armor);
        }
        
        double k = Math.Exp(armor);
        double armorMultiplier = 1.0 - k / (1.0 + k);
        int damageAmount = (int) Math.Max(amount * armorMultiplier, 0);
        _health -= damageAmount;
        return damageAmount;
    }

    public bool IsDead()
    {
        return _health <= 0;
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