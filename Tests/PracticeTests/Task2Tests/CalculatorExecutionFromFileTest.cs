using System.Globalization;
using System.Text;
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
        var expectedString = File
            .ReadAllLines(Path.Combine(Environment.CurrentDirectory + Resources.Task2_TestingDataPath_Answer1),
                Encoding.Default).First();
        var expectedDouble = double.Parse(expectedString, CultureInfo.InvariantCulture);
        
        using var factory = LoggerFactory.Create(f => f.AddConsole());
        var logger = factory.CreateLogger(nameof(CalculatorExecutionFromFileTest));
        var container = new MockContainer();
        var calculator = CalculatorBuilder.Create().LogBy(logger).OutBy(CalculatorOutputOptions.Console)
            .StoreBy(container).Build();
        var commandListPath = Path.Combine(Environment.CurrentDirectory + Resources.Task2_TestingDataPath_Example1);
        calculator.ExecuteFromFile(new FileInfo(commandListPath));
        var result = container.Stack.Peek();

        Assert.That(Math.Abs(result - expectedDouble), Is.LessThan(DoublesConstants.Tolerance));
    }
}