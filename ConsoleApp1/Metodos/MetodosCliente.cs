using ConsoleApp1.Classes;
using Microsoft.Data.Sqlite;
using System.Globalization;

namespace ConsoleApp1;

public sealed class CustomerRepository : IDisposable
{
    private readonly SqliteConnection connection;
    public CustomerRepository(string path)
    {
        connection = new SqliteConnection(new SqliteConnectionStringBuilder { DataSource = Path.GetFullPath(path) }.ToString());
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = """
            CREATE TABLE IF NOT EXISTS customers (
                id INTEGER PRIMARY KEY CHECK(id > 0),
                name TEXT NOT NULL CHECK(length(trim(name)) BETWEEN 2 AND 200),
                type INTEGER CHECK(type >= 0),
                created_at TEXT NOT NULL
            )
            """;
        command.ExecuteNonQuery();
    }
    public void Add(Cliente customer)
    {
        customer.Validate();
        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO customers(id, name, type, created_at) VALUES($id, $name, $type, $created)";
        Bind(command, customer);
        command.Parameters.AddWithValue("$created", customer.DataCadastro.ToUniversalTime().ToString("O", CultureInfo.InvariantCulture));
        try { command.ExecuteNonQuery(); }
        catch (SqliteException error) when (error.SqliteErrorCode == 19) { throw new ArgumentException("Customer ID already exists or data violates a constraint.", error); }
    }
    public bool Update(int id, string name, int? type)
    {
        var customer = new Cliente(id, name, type, DateTimeOffset.UtcNow);
        customer.Validate();
        using var command = connection.CreateCommand();
        command.CommandText = "UPDATE customers SET name=$name, type=$type WHERE id=$id";
        Bind(command, customer);
        return command.ExecuteNonQuery() == 1;
    }
    private static void Bind(SqliteCommand command, Cliente customer)
    {
        command.Parameters.AddWithValue("$id", customer.Codigo);
        command.Parameters.AddWithValue("$name", customer.Nome.Trim());
        command.Parameters.AddWithValue("$type", (object?)customer.Tipo ?? DBNull.Value);
    }
    public IReadOnlyList<Cliente> List(int? id = null)
    {
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT id, name, type, created_at FROM customers WHERE $id IS NULL OR id=$id ORDER BY id LIMIT 1000";
        command.Parameters.AddWithValue("$id", (object?)id ?? DBNull.Value);
        using var reader = command.ExecuteReader();
        var result = new List<Cliente>();
        while (reader.Read()) result.Add(new(reader.GetInt32(0), reader.GetString(1),
            reader.IsDBNull(2) ? null : reader.GetInt32(2), DateTimeOffset.Parse(reader.GetString(3), CultureInfo.InvariantCulture)));
        return result;
    }
    public bool Delete(int id)
    {
        if (id <= 0) throw new ArgumentException("Customer ID must be positive.");
        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM customers WHERE id=$id";
        command.Parameters.AddWithValue("$id", id);
        return command.ExecuteNonQuery() == 1;
    }
    public void Dispose() => connection.Dispose();
}
