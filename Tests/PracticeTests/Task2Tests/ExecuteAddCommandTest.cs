namespace PracticeTests.Task2Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class ExecuteAddCommandTest
{
    [TestCaseSource(typeof(CommandsTetsData), nameof(CommandsTetsData.AddCommandTestInput))]
    public void Test_ExecuteAddCommandTest(string[] commands, string command, double expected)
    {
        
    }
}