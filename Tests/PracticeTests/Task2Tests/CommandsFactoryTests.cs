namespace PracticeTests.Task2Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class CommandsFactoryTests
{
    [Test]
    public void GenerateAddCommandTest()
    {
        Assert.IsTrue(true);
    }
}