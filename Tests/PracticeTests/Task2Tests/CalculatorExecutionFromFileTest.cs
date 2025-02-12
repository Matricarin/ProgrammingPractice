using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Task2;
using Common.TasksLibrary.Task2.Output;
using Microsoft.Extensions.Logging;
using PracticeTests.Properties;

namespace PracticeTests.Task2Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class CalculatorExecutionFromFileTest
{
    [Test]
    public void Test_ExecuteCorrectCommands()
    {
        var expected = File
            .ReadAllLines(Path.Combine(Environment.CurrentDirectory + Resources.Task2_TestingDataPath_Answer1)).First();
        using var factory = LoggerFactory.Create(f => f.AddConsole());
        var logger = factory.CreateLogger(nameof(CalculatorExecutionFromFileTest));
        var container = new MockContainer();
        var calculator = CalculatorBuilder.Create().LogBy(logger).OutBy(CalculatorOutputOptions.Console)
            .StoreBy(container).Build();

        calculator.ExecuteFromFile(
            new FileInfo(Path.Combine(Environment.CurrentDirectory + Resources.Task2_TestingDataPath_Answer1)));
        var result = container.Stack.Peek();
        
        Assert.That(Math.Abs(result - double.Parse(expected)), Is.LessThan(DoublesConstants.Tolerance));
    }
    
}