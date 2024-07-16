using System.Reflection.Metadata.Ecma335;

class RandomBag<T>
{
    List<T> _bag;
    List<T> _baseBag;

    public RandomBag(List<T> baseBag)
    {
        _baseBag = baseBag;
        _bag = Enumerable.ToList(_baseBag);
    }

    public T TakeOut()
    {
        int rand = Random.Shared.Next(_bag.Count);
        Console.WriteLine(rand);
        T r = _bag[rand];
        _bag.RemoveAt(rand);
        if (_bag.Count == 0)
            _bag = Enumerable.ToList(_baseBag);
        return r;
    }

    public T Peek()
    {
        return _bag[Random.Shared.Next(_bag.Count)];
    }

    public void Add(T thing)
    {
        _baseBag.Add(thing);
        _bag.Add(thing);
    }
}