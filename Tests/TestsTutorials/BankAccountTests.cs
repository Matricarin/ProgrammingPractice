using TestsTutorials.Models.NUnitScenarios;

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

    [Test]
    public void DepositStubIntegrationTest()
    {
        var log = new NullLogWithResult(true);
        var bankAccount = new BankAccount(log)
        {
            Balance = 100
        };
        bankAccount.Deposit(100);
        Assert.That(bankAccount.Balance, Is.EqualTo(200));
    }

    [Test]
    public void DepositCustomMockIntegrationTest()
    {
        var log = new LogMock(true);
        var bankAccount = new BankAccount(log)
        {
            Balance = 100
        };
        bankAccount.Deposit(100);
        Assert.Multiple(() =>
        {
            Assert.That(bankAccount.Balance, Is.EqualTo(200));
            Assert.That(log.MethodCallCounts[nameof(LogMock.Log)], Is.EqualTo(1));
        });
    }
}