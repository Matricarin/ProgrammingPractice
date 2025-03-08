using TestsTutorials.Models;

namespace TestsTutorials;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class BankAccountTests
{

    [Test]
    public void DepositIntegrationTest()
    {
        var bankAccount = new BankAccount(new ConsoleLog())
        {
            Balance = 100
        };
        
        bankAccount.Deposit(100);
        
        Assert.That(bankAccount.Balance, Is.EqualTo(200));
    }

    [Test]
    public void DepositFakeIntegrationTest()
    {
        var log = new NullLog();
        var bankAccount = new BankAccount(log)
        {
            Balance = 100
        };
        bankAccount.Deposit(100);
        Assert.That(bankAccount.Balance, Is.EqualTo(200));
    }
}