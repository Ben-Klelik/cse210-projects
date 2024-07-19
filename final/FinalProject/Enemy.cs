using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

class Enemy
{
    int _level; public int GetLevel(){ return _level; }
    string _name; public string GetName(){ return _name; }
    string _attackDescription; public string GetAttackDescription(){ return _attackDescription; }
    int _baseHealth; public int GetBaseHealth(){ return _baseHealth; }
    int _health; public int GetHealth(){ return _health; }
    int _baseArmor; public int GetArmor(){ return _baseArmor; }
    int _baseStrength; public int GetStrength(){ return _baseStrength; }
    double _hitChance; // 0-1
    public Event _enemyTurn = new(() => {
        Console.WriteLine("The enemy dies");
        return true;
        });

    public Enemy(int level, string name, string attackDescription, int health, int armor, int strength, double hitChance)
    {
        _level = level;
        _name = name;
        _attackDescription = attackDescription;
        _baseHealth = health;
        _health = health;
        _baseArmor = armor;
        _baseStrength = strength;
        _hitChance = hitChance;
    }

    public void PrepareForBattle()
    {
        _health = _baseHealth;
    }

    public int GetXP()
    {
        return _level * (Random.Shared.Next(-5, 6) + 40);
    }

    public int GetDamage()
    {
        int variance = _baseStrength / 10;
        return _baseStrength + Random.Shared.Next(-variance, variance);
    }

    public bool GetsHit()
    {
        return _hitChance > Random.Shared.NextDouble();
    }

    public int Damage(int amount)
    {
        double armorMultiplier = 1 / (1 + Math.Exp(-4 + 0.11 * _baseArmor));
        int damageAmount = (int) Math.Max(armorMultiplier * amount, 0);
        _health -= damageAmount;
        // Console.WriteLine($"Enemy takes {amount} base, reduced to {damageAmount}");
        return damageAmount;
    }

    public bool IsDead()
    {
        return _health <= 0;
    }

    public void DisplayEnemyInfo()
    {
        Console.WriteLine($" {_name} Stats\nHealth: {_health}\nArmor: {_baseArmor}\nStrength: {_baseStrength}");
    }
}