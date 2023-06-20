using System.Collections;

public class MyList<Name> : IEnumerable<Name>
{
    private Name[] _array;
    private int _count;

    public MyList()
    {
        _array = new Name[4];
        _count = 0;
    }

    public void Add(Name item)
    {
        if (_count == _array.Length)
        {
            Array.Resize(ref _array, _array.Length * 2);
        }

        _array[_count++] = item;
    }

    public void AddRange(IEnumerable<Name> collection)
    {
        foreach (var item in collection)
        {
            Add(item);
        }
    }

    public bool Remove(Name item)
    {
        int index = Array.IndexOf(_array, item, 0, _count);
        if (index >= 0)
        {
            RemoveAt(index);
            return true;
        }

        return false;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Array.Copy(_array, index + 1, _array, index, _count - index - 1);
        _array[--_count] = default(Name);
    }

    public void Sort()
    {
        Array.Sort(_array, 0, _count);
    }

    public IEnumerator<Name> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _array[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}