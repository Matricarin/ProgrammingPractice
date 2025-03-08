using TestsTutorials.Models;

namespace TestsTutorials;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class BankAccountTests
{
    private BankAccount bankAccount = new BankAccount(new ConsoleLog())
    {
        Balance = 100
    };

    [Test]
    public void DepositIntergrationTest()
    {
        bankAccount.Deposit(100);
        
        Assert.That(bankAccount.Balance, Is.EqualTo(200));
    }
}