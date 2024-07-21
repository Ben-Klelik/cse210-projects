using System.Collections;

sealed class ItemManager
{
    Dictionary<int, List<Item>> _itemPools = [];
    public static ItemManager Instance { get; } = new ItemManager();
    // public static ItemManager Instance { get; } = new ItemManager();
    
    
    // static ItemManager()
    // {

    // }

    ItemManager() {}

    public void AddItemToLevelRange(Item item, int lower, int upper)
    {
        for(int i = lower; i <= upper; i++)
        {
            if (!_itemPools.ContainsKey(i))
                _itemPools[i] = [];
            _itemPools[i].Add(item);
        }
    }

    private void ViewPools(int i)
    {
        Console.WriteLine($"{i}th item pool");
        foreach (Item item in _itemPools[i])
        {
            Console.WriteLine($":Name:  {item.GetName()}");
            Console.WriteLine($"Amount:  {item.GetAmount()}");
            Console.WriteLine($"AddType: {(item.GetAddType() == Item.ADDTYPE.Flat ? "constant" : "multiplier")}");
            Console.WriteLine($"Stat:    {(item.GetStat() == Character.STAT.Health ? "health" : item.GetStat() == Character.STAT.Defense ? "defense" : "strength")}"); 
        }
    }

    public Item GetRandomItemInLevelWithType(int level, Item.TYPE type)
    {
        List<Item> pool;
        bool gotValue = _itemPools.TryGetValue(level, out pool);
        if (!gotValue)
        {
            ViewPools(level);
            throw new Exception("Did not get value");
        }
        List<Item> possibilities = [];

        foreach(Item item in pool)
        {
            if(item.GetItemType() == type)
                possibilities.Add(item);
        }

        return possibilities[Random.Shared.Next(possibilities.Count)];
    }
}