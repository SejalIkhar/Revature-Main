public class InMemoryRepository<T> : IRepository<T>
{
    private int _count = 0;

    public void Add(T item)
    {
        _count++;
    }

    public int Count()
    {
        return _count;
    }
}
