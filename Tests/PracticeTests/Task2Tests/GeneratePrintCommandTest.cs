using Common.TasksLibrary.Task2;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Commands;
using Common.TasksLibrary.Task2.Output;

namespace PracticeTests.Task2Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class GeneratePrintCommandTest
{
    [TestCaseSource(typeof(CommandsTetsData), nameof(CommandsTetsData.GeneratePrintCommand))]
    public void Test_GeneratePrintCommand(string command)
    {
        var expected = 5.0;
        var commands = new string[]
        {
            "Define a 5",
            "Push a"
        };
        var calc = CommandsTetsData.GetCalculatorInstanceForCommandTest(commands);
        
        calc.Execute(command);
        var memory = (MemoryOutput)calc.OutputPort;
        var result = memory.Value;
        
        Assert.That(expected, Is.EqualTo(result));
    }
}
