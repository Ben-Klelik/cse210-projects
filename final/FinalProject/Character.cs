
abstract class Character
{
    protected string _name;
    protected int _level = 1; public int GetLevel(){ return _level; }
    protected int _xp = 0;
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
        public Buff(BUFF_STAT stat, BUFF_ADD_TYPE addType, int duration, double amount)
        {
            _stat = stat;
            _addType = addType;
            _duration = duration;
            _amount = amount;
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
    public void AddBuff(BUFF_STAT stat, BUFF_ADD_TYPE addType, int duration, double amount)
    {
        activeBuffs.Add(new Buff(stat, addType, duration, amount));
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
    public void SwapEquipment(Item newItem)
    {
        Item ci = newItem.GetItemType() == Item.TYPE.Weapon ? _weapon : newItem.GetItemType() == Item.TYPE.Armor ? _armor : null;
        if (ci is null && _consumable is not null)
            ci = _consumable;
        
        if (ci is null)
        {
            Console.WriteLine($"You do not currently have an item of this type");
        }
        else
        {
            Console.WriteLine($":Current Item: {ci.GetName()}");
            Console.WriteLine($"Buff amount:    {ci.GetAmount()}");
            Console.WriteLine($"Buff type:      {(ci.GetAddType() == Item.ADDTYPE.Flat ? "constant" : "multiplier")}");
        }
        Console.WriteLine();
        Console.WriteLine($":New Item:     {newItem.GetName()}");
        Console.WriteLine($"Buff amount:    {newItem.GetAmount()}");
        Console.WriteLine($"Buff type:      {(newItem.GetAddType() == Item.ADDTYPE.Flat ? "constant" : "multiplier")}");
        Console.WriteLine($"Increased Stat: {(newItem.GetStat() == Item.STAT.Health ? "health" : newItem.GetStat() == Item.STAT.Defense ? "defense" : "strength")}");
        Menu menu = new("Swap or not?");
        if (newItem.GetItemType() == Item.TYPE.Consumable)
        {
            menu.AddOption("Drink the new item", "drink");
            if (ci is not null)
                menu.AddOption("Swap and drink your current item", "swig");
        }
        menu.AddOption("Swap what you have with the new item", "swap");
        menu.AddOption("Keep what you have", "keep");
        menu.Display();
        string choice = menu.GetNameFromNum(menu.SelectByNum());

        if (choice == "drink")
        {
            _consumable = newItem;
            UseConsumable();
            _consumable = ci;
        }
        else if (choice == "swig")
        {
            UseConsumable();
            _consumable = newItem;
        }
        else if (choice == "swap")
        {
            switch (newItem.GetItemType())
            {
                case Item.TYPE.Weapon:
                    _weapon = newItem;
                    break;
                case Item.TYPE.Armor:
                    _armor = newItem;
                    break;
                case Item.TYPE.Consumable:
                    _consumable = newItem;
                    break;
            };
        }
        else if (choice == "keep")
        {
            Console.WriteLine("You keep what you had before");
        }
    }

    public bool HasConsumable()
    {
        return _consumable is not null;
    }
    virtual protected void LevelUp()
    {
        _level++;
    }
    public Menu battleOptions = new("What will you do?");

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
        double strength = _baseStrength;
        if (_armor.GetStat() == Item.STAT.Strength)
            strength = _armor.ApplyItemStats(_baseStrength);
        
        if (_weapon.GetStat() == Item.STAT.Strength)
            strength = _weapon.ApplyItemStats(strength);
        
        return ApplyBuffsToStat(strength, BUFF_STAT.Strength);
    }

    public int Damage(int amount)
    {
        double armor = _baseArmor;
        if (_armor.GetStat() == Item.STAT.Defense)
            armor = _armor.ApplyItemStats(_baseArmor);
        
        if (_weapon.GetStat() == Item.STAT.Defense)
            armor = _weapon.ApplyItemStats(armor);
        
        double armorMultiplier = 1 / (1 + Math.Exp(-4 + 0.11 * armor));
        int damageAmount = (int) Math.Max(armorMultiplier * amount, 0);
        _health -= damageAmount;
        return damageAmount;
    }

    public bool IsDead()
    {
        return _health <= 0;
    }

    public void DisplayEquipment()
    {
        Console.WriteLine($"Weapon");
        Console.WriteLine($":Name:   {_weapon.GetName()}");
        Console.WriteLine($"  Amount:  {_weapon.GetAmount()}");
        Console.WriteLine($"  AddType: {(_weapon.GetAddType() == Item.ADDTYPE.Flat ? "constant" : "multiplier")}");
        Console.WriteLine($"  Stat:    {(_weapon.GetStat() == Item.STAT.Health ? "health" : _weapon.GetStat() == Item.STAT.Defense ? "defense" : "strength")}");
        Console.WriteLine();
        Console.WriteLine($"Armor");
        Console.WriteLine($":Name:   {_armor.GetName()}");
        Console.WriteLine($"  Amount:  {_armor.GetAmount()}");
        Console.WriteLine($"  AddType: {(_armor.GetAddType() == Item.ADDTYPE.Flat ? "constant" : "multiplier")}");
        Console.WriteLine($"  Stat:    {(_armor.GetStat() == Item.STAT.Health ? "health" : _armor.GetStat() == Item.STAT.Defense ? "defense" : "strength")}");
        Console.WriteLine();
        if (_consumable is not null)
        {
            Console.WriteLine($"Consumable");
            Console.WriteLine($":Name:   {_consumable.GetName()}");
            Console.WriteLine($"  Amount:  {_consumable.GetAmount()}");
            Console.WriteLine($"  AddType: {(_consumable.GetAddType() == Item.ADDTYPE.Flat ? "constant" : "multiplier")}");
            Console.WriteLine($"  Stat:    {(_consumable.GetStat() == Item.STAT.Health ? "health" : _consumable.GetStat() == Item.STAT.Defense ? "defense" : "strength")}");
        }
    }

    public void DisplayCharacterInfo()
    {
        int buffedArm = ApplyBuffsToStat(_baseArmor, BUFF_STAT.Defense);
        int buffedStr = ApplyBuffsToStat(_baseStrength, BUFF_STAT.Strength);
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Health: {_health}");
        Console.WriteLine($"Base Health: {_baseHealth}");
        Console.WriteLine($"Base Armor: {_baseArmor}");
        if (_baseArmor != buffedArm)
            Console.WriteLine($"Buffed Armor: {buffedArm}");
        Console.WriteLine($"Base Strength: {_baseStrength}");
        if (_baseStrength != buffedStr)
            Console.WriteLine($"Buffed Strength: {buffedStr}");
    }

    public void UseConsumable()
    {
        BUFF_STAT buffStat;
        BUFF_ADD_TYPE buffType;
        buffStat = _consumable.GetStat() == Item.STAT.Health ? BUFF_STAT.Health : _consumable.GetStat() == Item.STAT.Defense ? BUFF_STAT.Defense : BUFF_STAT.Strength;
        buffType = _consumable.GetAddType() == Item.ADDTYPE.Flat ? BUFF_ADD_TYPE.Flat : BUFF_ADD_TYPE.Multiplier;
        AddBuff(buffStat, buffType, 10, _consumable.GetAmount());
        _consumable = null;
    }

    public void GetXPFromKill(int level)
    {
        _xp += 5 * level * level;
        int xpRequirement = _level * _level * 100 + 50; 
        int levelUps = _xp / xpRequirement;
        for (int i = 0; i < levelUps; i++)
        {
            _xp -= xpRequirement;
            LevelUp();
        }
    }
}