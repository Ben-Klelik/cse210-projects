class Paladin : Character
{
    public Paladin()
    {
        _name = "Paladin";
        _baseHealth = 50;
        _health = 50;
        _baseArmor = 8;
        _baseStrength = 8;
        _weapon = new Item(Item.TYPE.Weapon, "Pointy Shield", 2);
        _armor = new Item(Item.TYPE.Armor, "Soft Shield", 20);
    }

    protected override void LevelUp()
    {
        base.LevelUp();
        _baseArmor += 2;
        _baseStrength += 2;
        _baseHealth += 10;
        Console.WriteLine($"You got:");
        Console.WriteLine($" 2 more armor ( {_baseArmor - 2} -> {_baseArmor} )");
        Console.WriteLine($" 2 more strength ( {_baseStrength - 2} -> {_baseStrength} )");
        Console.WriteLine($" 10 more health ( {_baseHealth - 10} -> {_baseHealth} )");
    }
}