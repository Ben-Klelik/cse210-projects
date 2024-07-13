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

    public Item GetRandomItemInLevelWithType(int level, Item.TYPE type)
    {
        if(_itemPools.ContainsKey(level))
            return null;

        List<Item> possibilities = [];

        foreach(Item item in _itemPools[level])
        {
            if(item.GetItemType() == type)
                possibilities.Add(item);
        }

        return possibilities[Random.Shared.Next(possibilities.Count)];
    }
}