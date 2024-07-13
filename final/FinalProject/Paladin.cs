class Paladin : Character
{
    public Paladin()
    {
        _baseHealth = 50;
        _health = 50;
        _baseArmor = 40;
        _weapon = new Item("Pointy Shield", Item.TYPE.Weapon, 10.0);
        _armor = new Item("Soft Shield", Item.TYPE.Armor, 2.0);
    }
}