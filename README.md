# Customer register

[![CI](https://github.com/Almeida96/ConsoleApp1/actions/workflows/ci.yml/badge.svg)](https://github.com/Almeida96/ConsoleApp1/actions/workflows/ci.yml)

A C# command-line exercise with explicit create, read, update and delete operations backed by SQLite. Customer records use the original Portuguese field names in JSON output.

## Run

Install the .NET 8 SDK. From the checkout:

```sh
dotnet run --project ConsoleApp1 -- add 1 "Alice Example" 2
dotnet run --project ConsoleApp1 -- get 1
dotnet run --project ConsoleApp1 -- update 1 "Alice Updated"
dotnet run --project ConsoleApp1 -- list
dotnet run --project ConsoleApp1 -- delete 1
```

The database is `customers.db` in the working directory. Choose another file with `--db PATH` before the command:

```sh
dotnet run --project ConsoleApp1 -- --db ./demo.db add 1 "Sample Customer"
```

IDs are positive integers. Names contain 2–200 characters after trimming. The optional type is a positive integer; omitting it on update clears the type. Registration time is recorded in UTC and preserved on updates. Lists return the first 1,000 records ordered by ID. No operation saves implicitly when an object is disposed.

Exit code 0 means success, 1 invalid input or a storage failure, and 2 a missing customer. Read commands emit JSON.

## Development

```sh
dotnet test ConsoleApp1.Tests/ConsoleApp1.Tests.csproj
```

Tests use temporary databases and cover persistence, repeated reads/disposal, duplicates, update/delete behavior, validation and SQL-looking names. SQL values use parameters.

## Changes from the original exercise

The unfinished menu and SQL Server LocalDB dependency were replaced with an explicit CLI and local SQLite storage. Previously, disposing a customer inserted a row, including after reads or an earlier save. Search and deletion now perform their advertised operations.

Existing SQL Server `Loja.Cliente` data is not imported or modified. Export it before moving to this version if you need those records. The old contact model remains a data type; contact persistence is outside the current schema.

This is a single-user local register without authentication or encryption. Use demonstration records when sharing a database. No personal data or database files belong in commits.

For contributions, include a regression test for storage behavior and run the suite. Do not make disposal or reads write records.
