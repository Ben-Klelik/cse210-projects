class Barbarian : Character
{
    public Barbarian()
    {
        _name = "Barbarian";
        _baseHealth = 200;
        _health = 200;
        _baseArmor = 5;
        _baseStrength = 8;
        _weapon = new Item(Item.TYPE.Weapon, "Rusty Axe", 15.0);
        _armor = new Item(Item.TYPE.Armor, "Loin Cloth", 0);
    }

    protected override void LevelUp()
    {
        base.LevelUp();
        _baseStrength += 3;
    }
}