using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Task2;
using Common.TasksLibrary.Task2.Commands;
using Common.TasksLibrary.Task2.Output;

namespace PracticeTests.Task2Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class CommandsExecutionTests
{
    private CalculatorExecutionContext _context;
    private MockContainer _container;
    private const double FirstNumber = 10.1;
    private const double SecondNumber = 20.2;
    private const double Result = 30.3;
    
    [SetUp]
    public void Setup()
    {
        _container = new MockContainer();
        _context = new CalculatorExecutionContext(new ConsoleOutput(), _container);
        _context.Push(FirstNumber);
        _context.Push(SecondNumber);
    }

    [Test]
    public void Test_AddCommandExecution()
    {
        var command = new AddCommand(string.Empty);
        command.Process(_context);
        var result = _context.Pop();
        Assert.True(Math.Abs(result - Result) < DoublesConstants.Tolerance);
    }
}