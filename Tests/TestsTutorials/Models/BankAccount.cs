namespace TestsTutorials.Models;

public interface ILog
{
    void Log(string message);
}

public sealed class ConsoleLog : ILog
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

/// <summary>
/// Fake object for tests
/// </summary>
public sealed class NullLog : ILog
{
    public void Log(string message)
    {
        
    }
}

public sealed class BankAccount
{
    private readonly ILog _log;
    public decimal Balance { get; set; }

    public BankAccount(ILog log)
    {
        _log = log;
    }

    public void Deposit(decimal amount)
    {
        _log.Log($"Depositing {amount}");
        Balance += amount;
    }
}