class Barbarian : Character
{
    public Barbarian()
    {
        _name = "Barbarian";
        _baseHealth = 200;
        _health = 200;
        _baseArmor = 18;
        _baseStrength = 8;
        _weapon = new Item(Item.TYPE.Weapon, "Rusty Axe", 5.0);
        _armor = new Item(Item.TYPE.Armor, "Loin Cloth", 0);
    }

    protected override void LevelUp()
    {
        base.LevelUp();
        _baseStrength += 6;
        _baseHealth += 25;
        Console.WriteLine($"You got:");
        Console.WriteLine($" 6 more strength ( {_baseStrength - 6} -> {_baseStrength} )");
        Console.WriteLine($" 25 more health ( {_baseHealth - 25} -> {_baseHealth} )");
    }
}