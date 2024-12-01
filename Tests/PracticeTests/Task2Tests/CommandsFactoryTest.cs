using Common.TasksLibrary.Task2.Base;

namespace PracticeTests.Task2Tests;

[TestFixtureSource(typeof(CommandFactoryCommands), nameof(CommandFactoryCommands.Commands))]
public class CommandsFactoryTest
{
    private Dictionary<string, string> _commandsDict;

    public CommandsFactoryTest(string command, string instance)
    {
        
        _commandsDict = new Dictionary<string, string>();
        _commandsDict.Add(command, instance);
    }

    [Test]
    public void Test_GenerateCommand()
    {
        var factory = new CommandsFactory(_commandsDict);
        var command = factory.GenerateCommand("DEFINE b 5");
    }
}

public class CommandFactoryCommands
{
    public static object[] Commands =
    {
        new object[] { "DEFINE", "Common.TasksLibrary.Task2.Commands.DefineCommand" }
    };
}