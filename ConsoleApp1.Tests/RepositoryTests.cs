using ConsoleApp1;
using ConsoleApp1.Classes;
using Microsoft.Data.Sqlite;
using Xunit;

public sealed class RepositoryTests : IDisposable
{
    private readonly string path = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".db");
    [Fact]
    public void PersistsAcrossReopenAndReadDisposeNeverInserts()
    {
        using (var repository = new CustomerRepository(path)) repository.Add(new Cliente(1, "Alice", null, DateTimeOffset.UtcNow));
        using (var repository = new CustomerRepository(path)) Assert.Single(repository.List());
        using (var repository = new CustomerRepository(path)) Assert.Single(repository.List());
    }
    [Fact]
    public void UpdatesAndDeletesWithoutChangingRegistrationDate()
    {
        var created = DateTimeOffset.UtcNow.AddDays(-2);
        using var repository = new CustomerRepository(path);
        repository.Add(new Cliente(1, "Alice", 2, created));
        Assert.True(repository.Update(1, "Alice Updated", null));
        var item = Assert.Single(repository.List(1));
        Assert.Equal(created, item.DataCadastro);
        Assert.Null(item.Tipo);
        Assert.Equal("Alice Updated", item.Nome);
        Assert.True(repository.Delete(1));
        Assert.False(repository.Delete(1));
        Assert.False(repository.Update(2, "Missing", null));
        Assert.Empty(repository.List());
    }
    [Fact]
    public void RejectsDuplicatesAndInvalidNamesWithoutPartialWrites()
    {
        using var repository = new CustomerRepository(path);
        repository.Add(new Cliente(1, "Alice", null, DateTimeOffset.UtcNow));
        Assert.Throws<ArgumentException>(() => repository.Add(new Cliente(1, "Other", null, DateTimeOffset.UtcNow)));
        Assert.Throws<ArgumentException>(() => repository.Add(new Cliente(2, " ", null, DateTimeOffset.UtcNow)));
        Assert.Throws<ArgumentException>(() => repository.Add(new Cliente(-1, "Other", null, DateTimeOffset.UtcNow)));
        Assert.Single(repository.List());
    }
    [Fact]
    public void TreatsSqlCharactersAsNameData()
    {
        using var repository = new CustomerRepository(path);
        var name = "O'Brien'); DROP TABLE customers; --";
        repository.Add(new Cliente(1, name, null, DateTimeOffset.UtcNow));
        Assert.Equal(name, Assert.Single(repository.List()).Nome);
    }
    public void Dispose() { SqliteConnection.ClearAllPools(); File.Delete(path); }
}
