using ConsoleApp1;
using ConsoleApp1.Classes;
using Microsoft.Data.Sqlite;
using System.Globalization;
using System.Text.Json;

try
{
    var arguments = args.ToList();
    var database = "customers.db";
    if (arguments.Count >= 2 && arguments[0] == "--db")
    {
        database = arguments[1];
        arguments.RemoveRange(0, 2);
    }
    if (arguments.Count == 0 || arguments[0] is "--help" or "help")
    {
        Console.WriteLine("""
            Customer register
            Usage: dotnet run --project ConsoleApp1 -- [--db PATH] COMMAND
              add ID "NAME" [TYPE]     Insert a customer
              update ID "NAME" [TYPE]  Change name/type; retain registration date
              get ID                  Print one customer as JSON
              list                    Print up to 1000 customers, ordered by ID
              delete ID               Remove a customer
            Exit codes: 0 success, 1 invalid input/storage error, 2 customer not found.
            """);
        return 0;
    }
    var operation = arguments[0];
    var count = arguments.Count;
    if ((operation is "add" or "update") ? count is < 3 or > 4 :
        (operation is "get" or "delete") ? count != 2 :
        operation != "list" || count != 1) throw new ArgumentException("Invalid command. Run --help.");
    int Number(string value) => int.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out var result) && result > 0
        ? result : throw new ArgumentException("IDs and supplied types must be positive integers.");
    using var repository = new CustomerRepository(database);
    switch (operation)
    {
        case "add":
        case "update":
            var id = Number(arguments[1]);
            int? type = count == 4 ? Number(arguments[3]) : null;
            if (operation == "add") repository.Add(new Cliente(id, arguments[2], type, DateTimeOffset.UtcNow));
            else if (!repository.Update(id, arguments[2], type)) return 2;
            Console.WriteLine(JsonSerializer.Serialize(repository.List(id)[0]));
            break;
        case "get":
            var customers = repository.List(Number(arguments[1]));
            if (customers.Count == 0) return 2;
            Console.WriteLine(JsonSerializer.Serialize(customers[0]));
            break;
        case "list":
            Console.WriteLine(JsonSerializer.Serialize(repository.List()));
            break;
        case "delete":
            if (!repository.Delete(Number(arguments[1]))) return 2;
            Console.WriteLine("Customer deleted.");
            break;
    }
    return 0;
}
catch (Exception error) when (error is ArgumentException or SqliteException or IOException or UnauthorizedAccessException)
{
    Console.Error.WriteLine(error.Message);
    return 1;
}
