using Common.TasksLibrary.Task2.Output;

namespace PracticeTests.Task2Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class ExecutePrintCommandTest
{
    [TestCaseSource(typeof(CommandsTetsData), nameof(CommandsTetsData.PrintCommandTestInput))]
    public void Test_ExecutePrintCommand(string[] commands, string command, double expected)
    {
        var calc = CommandsTetsData.GetCalculatorInstanceForCommandTest(commands);
        
        calc.Execute(command);
        
        var memory = (MemoryOutput)calc.OutputPort;
        
        var result = memory.Value;
        
        Assert.That(expected, Is.EqualTo(result));
    }
}
