using Common.TasksLibrary.Task2.Handlers;

namespace PracticeTests.Task2Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class CommandParserTests
{
    private CommandParser? Parser { get; set; }
    
    [TestCase("+", "+", "")]
    [TestCase("-", "-", "")]
    [TestCase("*", "*", "")]
    [TestCase("/", "/", "")]
    [TestCase("DEFINE a 5", "Define", "a 5")]
    [TestCase("PRINT", "Print", "")]
    public void ParseCommandTest(string input, string command, string arguments)
    {
        Parser = new CommandParser(input);
        
        Assert.Multiple(() =>
        {
            Assert.That(Parser.Command, Is.EqualTo(command));
            Assert.That(Parser.Arguments, Is.EqualTo(arguments));
        });
    }
}