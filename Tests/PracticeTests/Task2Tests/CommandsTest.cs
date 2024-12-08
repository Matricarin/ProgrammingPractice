namespace PracticeTests.Task2Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class CommandsTest
{
    [Ignore("I am thinking about calculator incance creation")]
    public void Test_DefineCommand_Process()
    {
        Assert.That(false, Is.EqualTo(true));
    }
}