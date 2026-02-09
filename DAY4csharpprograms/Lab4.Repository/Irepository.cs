public interface IRepository<T>
{
    void Add(T item);
    int Count();
}
