using Common.TasksLibrary.Task2.Output;

namespace PracticeTests.Task2Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class ExecutePrintCommandTest
{
    // [TestCaseSource(typeof(CommandsTetsData), nameof(CommandsTetsData.PrintCommandTestInput))]
    // public void Test_ExecutePrintCommand(string[] setUpCommands, string printCommand, double expected)
    // {
    //     var calc = CommandsTetsData.GetCalculatorInstanceForCommandTest(setUpCommands);
    //     calc.Execute(printCommand);
    //     var result = CommandsTetsData.GetTopStackValue(calc);
    //     Assert.That(expected, Is.EqualTo(result));
    // }
}
