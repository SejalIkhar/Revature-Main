public class RepositoryTests
{
    [Fact]
    public void Add_Increases_Count()
    {
        IRepository<int> repo = new InMemoryRepository<int>();

        repo.Add(10);

        Assert.Equal(1, repo.Count());
    }
}
