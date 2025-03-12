using Common.TasksLibrary.Task2.Handlers;
using Common.TasksLibrary.Task2.Output;

namespace PracticeTests.Task2Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.SingleInstance)]
public sealed class CalculatorExecutionContextTests
{
    private CalculatorExecutionContext _context;
    private MockContainer _container;
    private const string VariableName = "a";
    private const double ValueOfVariable = 128;
    private const double Number = 256;

    [OneTimeSetUp]
    public void Setup()
    {
        _container = new MockContainer();
        _context = new CalculatorExecutionContext(new ConsoleOutput(), _container);
    }

    [Test]
    [Order(1)]
    public void InvokeDefineVariable()
    {
        _context.DefineVariable(VariableName, ValueOfVariable);
        Assert.That(_container.VariableStorage,
            Does.Contain(new KeyValuePair<string, double>(VariableName, ValueOfVariable)));
    }

    [Test]
    [Order(2)]
    public void InvokePushVariable()
    {
        _context.PushVariable(VariableName);
        Assert.That(_container.Stack, Does.Contain(ValueOfVariable));
    }

    [Test]
    [Order(3)]
    public void InvokePush()
    {
        _context.Push(Number);
        Assert.That(_container.Stack, Does.Contain(Number));
    }

    [Test]
    [Order(4)]
    public void InvokePeek()
    {
        var top = _context.Peek();
        Assert.That(top, Is.EqualTo(Number));
    }

    [Test]
    [Order(5)]
    public void InvokePop()
    {
        var top = _context.Pop();
        Assert.Multiple(() =>
        {
            Assert.That(top, Is.EqualTo(Number));
            Assert.That(_container.Stack.Peek(), Is.EqualTo(ValueOfVariable));
        });
    }
}