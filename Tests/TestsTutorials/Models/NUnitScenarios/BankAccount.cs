namespace TestsTutorials.Models.NUnitScenarios;

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
        if (_log.Log($"Depositing {amount}"))
        {
            Balance += amount;
        }
    }
}