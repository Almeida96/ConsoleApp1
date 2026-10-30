namespace ConsoleApp1.Classes;

public sealed record Cliente(int Codigo, string Nome, int? Tipo, DateTimeOffset DataCadastro)
{
    public void Validate()
    {
        if (Codigo <= 0) throw new ArgumentException("Customer ID must be positive.");
        if (string.IsNullOrWhiteSpace(Nome) || Nome.Trim().Length is < 2 or > 200) throw new ArgumentException("Name must contain 2 to 200 characters.");
        if (Tipo is < 0) throw new ArgumentException("Customer type cannot be negative.");
    }
}
