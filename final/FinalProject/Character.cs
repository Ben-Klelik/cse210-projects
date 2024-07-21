
abstract class Character
{
    protected string _name;
    protected int _level = 1; public int GetLevel(){ return _level; }
    protected int _xp = 0;
    protected int _baseHealth;
    protected int _health; public int GetHealth(){ return _health; }
    protected int _baseArmor;
    protected int _baseStrength;
    protected Item _armor;
    protected Item _weapon;
    protected Item _consumable;
    public enum STAT {Health, Defense, Strength}
    protected class Buff
    {
        Item.ADDTYPE _addType;
        STAT _stat;
        int _duration;
        double _amount;
        public Buff(STAT stat, Item.ADDTYPE addType, int duration, double amount)
        {
            _stat = stat;
            _addType = addType;
            _duration = duration;
            _amount = amount;
        }
        public double ApplyBuffStats(double amount)
        {
            return _addType == Item.ADDTYPE.Flat ? amount + _amount : amount * _amount;
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
        public STAT GetBuffedStat()
        {
            return _stat;
        }
        public bool IsStat(STAT stat)
        {
            return stat == _stat;
        }
        public bool IsAddType(Item.ADDTYPE type)
        {
            return type == _addType;
        }
    }
    protected List<Buff> activeBuffs = [];
    public void AddBuff(STAT stat, Item.ADDTYPE addType, int duration, double amount)
    {
        activeBuffs.Add(new Buff(stat, addType, duration, amount));
    }
    public void DoBuffDecay()
    {
        activeBuffs.ForEach((buff) => buff.TickAway());
        activeBuffs.RemoveAll((buff) => buff.DurationEnded());
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
            Console.WriteLine($"Buff type:      {(ci.GetAddType() == Item.ADDTYPE.Flat ? "flat" : "multiplier")}");
        }
        Console.WriteLine();
        Console.WriteLine($":New Item:     {newItem.GetName()}");
        Console.WriteLine($"Buff amount:    {newItem.GetAmount()}");
        Console.WriteLine($"Buff type:      {(newItem.GetAddType() == Item.ADDTYPE.Flat ? "flat" : "multiplier")}");
        Console.WriteLine($"Increased Stat: {(newItem.GetStat() == STAT.Health ? "health" : newItem.GetStat() == STAT.Defense ? "defense" : "strength")}");
        Menu menu = new("Swap or not?");
        if (newItem.GetItemType() == Item.TYPE.Consumable)
        {
            menu.AddOption("Consume the new item", "drink");
            if (ci is not null)
                menu.AddOption("Swap and consume your current item", "swig");
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
        Console.WriteLine($"Yay! You leveled up!");
        Console.WriteLine($"Level ( {_level - 1} -> {_level} )");
        if (_level == 10)
            Console.WriteLine($"You are now max level and can level up no more");
    }
    public void HealToFull()
    {
        _health = _baseHealth;
    }
    public Character()
    {
        _baseHealth = 10000;
        _health = 100000;
        _baseArmor = 10000;
        _baseStrength = 10000;
    }

    public int ApplyBuffsToStat(double amount, STAT stat)
    {
        foreach (Buff buff in activeBuffs)
            if (buff.IsStat(stat) && buff.IsAddType(Item.ADDTYPE.Flat))
                amount = buff.ApplyBuffStats(amount);

        foreach (Buff buff in activeBuffs)
            if (buff.IsStat(stat) && buff.IsAddType(Item.ADDTYPE.Multiplier))
                amount = buff.ApplyBuffStats(amount);

        return (int) amount;
    }

    public bool DoesCriticalHit()
    {
        return Random.Shared.NextDouble() < 0.1;
    }

    public int GetAttackDamage()
    {
        return (int) GetModifiedStat(STAT.Strength);
    }

    public int Damage(int amount)
    {
        double armor = GetModifiedStat(STAT.Defense);
        
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
        Console.WriteLine($"  Stat:    {(_weapon.GetStat() == STAT.Health ? "health" : _weapon.GetStat() == STAT.Defense ? "defense" : "strength")}");
        Console.WriteLine();
        Console.WriteLine($"Armor");
        Console.WriteLine($":Name:   {_armor.GetName()}");
        Console.WriteLine($"  Amount:  {_armor.GetAmount()}");
        Console.WriteLine($"  AddType: {(_armor.GetAddType() == Item.ADDTYPE.Flat ? "constant" : "multiplier")}");
        Console.WriteLine($"  Stat:    {(_armor.GetStat() == STAT.Health ? "health" : _armor.GetStat() == STAT.Defense ? "defense" : "strength")}");
        Console.WriteLine();
        if (_consumable is not null)
        {
            Console.WriteLine($"Consumable");
            Console.WriteLine($":Name:   {_consumable.GetName()}");
            Console.WriteLine($"  Amount:  {_consumable.GetAmount()}");
            Console.WriteLine($"  AddType: {(_consumable.GetAddType() == Item.ADDTYPE.Flat ? "constant" : "multiplier")}");
            Console.WriteLine($"  Stat:    {(_consumable.GetStat() == STAT.Health ? "health" : _consumable.GetStat() == STAT.Defense ? "defense" : "strength")}");
        }
    }

    public void DisplayCharacterInfo()
    {   
        int modArm = (int) GetModifiedStat(STAT.Defense);
        int modStr = (int) GetModifiedStat(STAT.Strength);
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Level: {_level}");
        Console.WriteLine($"Health: {_health}");
        Console.WriteLine($"Max Health: {_baseHealth}");
        Console.WriteLine($"Armor: {_baseArmor} Modified: {modArm}");
        Console.WriteLine($"Strength: {_baseStrength} Modified: {modStr}");
    }

    public void UseConsumable()
    {
        if (_consumable.GetStat() == STAT.Health)
        {
            int beforeHealth = _health;
            _health = (int) Math.Min(_health + _consumable.GetAmount(), _baseHealth);
            Console.WriteLine($"Health ( {beforeHealth} -> {_health} )");
            Thread.Sleep(1000);
        }
        else
        {
            Item.ADDTYPE buffType;
            buffType = _consumable.GetAddType() == Item.ADDTYPE.Flat ? Item.ADDTYPE.Flat : Item.ADDTYPE.Multiplier;
            AddBuff(_consumable.GetStat(), buffType, 10, _consumable.GetAmount());
        }
        _consumable = null;
    }

    public void GetXPFromKill(int level)
    {
        if (_level != 10)
        {
            _xp += 5 * level * level;
            int xpRequirement = _level * _level * 15 + 5 * _level + 5; 
            int levelUps = _xp / xpRequirement;
            for (int i = 0; i < levelUps; i++)
            {
                _xp -= xpRequirement;
                if (_level != 10)
                {
                    LevelUp();
                    HealToFull();
                    if (_health != _baseHealth)
                        Console.WriteLine($"Health ( {_health} -> {_baseHealth} )");
                    Thread.Sleep(3000);
                }
            }
        }
    }

    public double GetModifiedStat(STAT stat)
    {
        if (stat == STAT.Health)
            return _health;
        else
        {
            double statValue = ApplyBuffsToStat( stat == STAT.Defense ? _baseArmor : _baseStrength, stat);
            if (_armor.GetStat() == stat)
                statValue = _armor.ApplyItemStats(statValue);
            if (_weapon.GetStat() == stat)
                statValue = _weapon.ApplyItemStats(statValue);
            return statValue;
        }
    }
}