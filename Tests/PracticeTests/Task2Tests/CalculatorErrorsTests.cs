using Common.TasksLibrary.Task2;
using Common.TasksLibrary.Task2.Output;

namespace PracticeTests.Task2Tests;

[TestFixture]
public class CalculatorErrorsTests
{
    [Test]
    public void Test_ExecutingCommandWithEmptyStackLogsProcessError()
    {
        var logger = new TestLogger();
        var container = new CalculatorContainer();
        var calculator = CalculatorBuilder.Create()
            .LogBy(logger)
            .OutBy(CalculatorOutputOptions.Console)
            .StoreBy(container)
            .Build();

        calculator.Execute("Add");

        Assert.IsTrue(logger.LoggedMessages.Count > 0);
        StringAssert.Contains("Stack is empty", logger.LoggedMessages[0]);
    }
}