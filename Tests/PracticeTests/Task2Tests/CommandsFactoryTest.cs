using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Commands;

namespace PracticeTests.Task2Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class CommandsFactoryTest
{
    private CommandsList _commands = new CommandsList()
    {
        DEFINE = "Common.TasksLibrary.Task2.Commands.DefineCommand",
    };
    
    [TestCaseSource(typeof(CommandsFactoryTestData), nameof(CommandsFactoryTestData.GenerateDefineCommand))]
    public void Test_GenerateDefineCommand(string stringCommand, DefineCommand expected)
    {
        var factory = new CommandsFactory(_commands);
        var result = factory.GenerateCommand(stringCommand);
        Assert.That(result, Is.EqualTo(expected));
    }
}

public static class CommandsFactoryTestData
{
    public static object[] GenerateDefineCommand = new object[]
    {
        new object[] {"DEFINE a 5", new DefineCommand("a 5")},
    };
}