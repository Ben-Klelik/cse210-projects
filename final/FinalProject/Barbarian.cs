class Barbarian : Character
{
    public Barbarian()
    {
        _baseHealth = 200;
        _health = 200;
        _baseArmor = 15;
        _weapon = new Item("Rusty Axe", Item.TYPE.Weapon, 30.0);
        _armor = new Item("Loin Cloth", Item.TYPE.Armor, 1.2);
    }
}