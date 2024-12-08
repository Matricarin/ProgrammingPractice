using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Commands;

namespace PracticeTests.Task2Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class CommandsFactoryTest
{
    [TestCaseSource(typeof(CommandFactoryCommands), nameof(CommandFactoryCommands.Commands))]
    public void Test_GenerateCommand(string stringCommand, string place)
    {
        var commandDict = new Dictionary<string, string>()
        {
            { stringCommand, place }
        };
        var defineCommand = new DefineCommand("b 5");
        var factory = new CommandsFactory(commandDict);
        var command = factory.GenerateCommand("DEFINE b 5");
        Assert.That(command, Is.EqualTo(defineCommand));
    }
}

public class CommandFactoryCommands
{
    public static object[] Commands =
    {
        new object[] { "DEFINE", "Common.TasksLibrary.Task2.Commands.DefineCommand" }
    };
}