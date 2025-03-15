using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Commands;
using Common.TasksLibrary.Task2.Handlers;
using Moq;

namespace PracticeTests.Task2Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class CommandsExecutionTests
{
    private const double FirstNumber = 10.1;
    private const double SecondNumber = 20.2;
    private const double AdditionResult = 30.3;
    private const double SubtractionResult = 10.1;
    private const double MultiplicationResult = 204.02;
    private const double DivisionResult = 2.0;
    private const double SqrtResult = 3.17804971641414;
    
    private MockContainer _container = new MockContainer();
    private Mock<IOutput> _port = new Mock<IOutput>();

    [Test]
    public void AddCommandExecution()
    {
        var context = new CalculatorExecutionContext(_port.Object, _container);
        context.Push(FirstNumber);
        context.Push(SecondNumber);

        var command = AddCommand.Create(string.Empty);
        command.Process(context);
        var result = context.Pop();

        Assert.That(Math.Abs(result - AdditionResult), Is.LessThan(DoublesConstants.Tolerance));
    }

    [Test]
    public void SubtractCommandExecution()
    {
        var context = new CalculatorExecutionContext(_port.Object, _container);
        context.Push(FirstNumber);
        context.Push(SecondNumber);

        var command = SubtractCommand.Create(string.Empty);
        command.Process(context);
        var result = context.Pop();

        Assert.That(Math.Abs(result - SubtractionResult), Is.LessThan(DoublesConstants.Tolerance));
    }

    [Test]
    public void MultiplyCommandExecution()
    {
        var context = new CalculatorExecutionContext(_port.Object, _container);
        context.Push(FirstNumber);
        context.Push(SecondNumber);

        var command = MultiplyCommand.Create(string.Empty);
        command.Process(context);
        var result = context.Pop();

        Assert.That(Math.Abs(result - MultiplicationResult), Is.LessThan(DoublesConstants.Tolerance));
    }

    [Test]
    public void DivideCommandExecution()
    {
        var context = new CalculatorExecutionContext(_port.Object, _container);
        context.Push(FirstNumber);
        context.Push(SecondNumber);

        var command = DivideCommand.Create(string.Empty);
        command.Process(context);
        var result = context.Pop();

        Assert.That(Math.Abs(result - DivisionResult), Is.LessThan(DoublesConstants.Tolerance));
    }

    [Test]
    public void SqrtCommandExecution()
    {
        var context = new CalculatorExecutionContext(_port.Object, _container);
        context.Push(FirstNumber);

        var command = SqrtCommand.Create(string.Empty);
        command.Process(context);
        var result = context.Pop();

        Assert.That(Math.Abs(result - SqrtResult), Is.LessThan(DoublesConstants.Tolerance));
    }
}