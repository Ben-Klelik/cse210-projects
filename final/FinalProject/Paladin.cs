class Paladin : Character
{
    public Paladin()
    {
        _name = "Paladin";
        _baseHealth = 50;
        _health = 50;
        _baseArmor = 40;
        _baseStrength = 3;
        _weapon = new Item(Item.TYPE.Weapon, "Pointy Shield", 5.0);
        _armor = new Item(Item.TYPE.Armor, "Soft Shield", 15);
    }

    protected override void LevelUp()
    {
        base.LevelUp();
        _baseArmor += 3;
    }
}