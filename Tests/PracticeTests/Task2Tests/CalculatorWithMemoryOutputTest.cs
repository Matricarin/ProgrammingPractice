using Common.TasksLibrary.Task2;
using Common.TasksLibrary.Task2.Base;

namespace PracticeTests.Task2Tests;

[TestFixture]
public class CalculatorWithMemoryOutputTest
{
    private const double Expected = 31;
    private FileInfo _executingFile;
    private CommandsFactory _factory;
    private MemoryOutput _output;
    private Calculator _calculator;
    private Dictionary<string, string> _commands;
    
    [SetUp]
    protected void Setup()
    {
        _executingFile = new FileInfo(Path.Combine(Environment.CurrentDirectory, 
            "TestingData","Task2_CalculatorTest_Example_1.txt"));
        _output = new MemoryOutput();
        _commands = new Dictionary<string, string>();
        _factory = new CommandsFactory(_commands);
        _calculator = new Calculator(_factory, _output);
    }

    [Test]
    public void Test_Execute()
    {
        var executionList = File.ReadAllLines(_executingFile.FullName);
        _calculator.Execute(executionList);
        Assert.That(_output.Value, Is.EqualTo(Expected));
    }
}