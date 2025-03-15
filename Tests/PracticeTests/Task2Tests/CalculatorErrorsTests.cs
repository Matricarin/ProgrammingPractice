using Common.TasksLibrary.Task2;
using Common.TasksLibrary.Task2.Exceptions;
using Common.TasksLibrary.Task2.Factories;
using Common.TasksLibrary.Task2.Handlers;
using Common.TasksLibrary.Task2.Providers;
using Microsoft.Extensions.Logging;
using Moq;

namespace PracticeTests.Task2Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class CalculatorErrorsTests
{
    [Test]
    public void Test_ExecutingCommandWithEmptyStackLogsProcessError()
    {
        var mock = new Mock<ILogger>();
        var counter = 0;
        
        mock.Setup(x => x.Log<string>(
                LogLevel.Error,
                It.IsAny<EventId>(),
                It.IsAny<string>(),
                It.IsAny<ProcessCommandException>(),
                It.Is<Func<string, Exception?, string>>((state, exception) => true)))
            .Callback(() => counter++);
        
        var container = new CalculatorContainer();
        
        var calculator = new Calculator(mock.Object, new CommandsFactory(), 
            new CalculatorExecutionContext(new ConsoleOutput(), container));

        calculator.Execute("+");
        
        Assert.That(counter, Is.EqualTo(1));
    }
}
