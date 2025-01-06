using Common.TasksLibrary.Task2.Output;

namespace PracticeTests.Task2Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class ExecuteAddCommandTest
{
    [TestCaseSource(typeof(CommandsTetsData), nameof(CommandsTetsData.AddCommandTestInput))]
    public void Test_ExecuteAddCommandTest(string[] setUpCommands, string addCommand, double expected)
    {
        var calc = CommandsTetsData.GetCalculatorInstanceForCommandTest(setUpCommands);
        calc.Execute(addCommand);
        var result = CommandsTetsData.GetTopStackValue(calc);
        Assert.That(result, Is.EqualTo(expected));
    }
}