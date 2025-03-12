using Common.TasksLibrary.Task2.Commands;
using Common.TasksLibrary.Task2.Factories;

namespace PracticeTests.Task2Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class CommandsFactoryTests
{
    private CommandsFactory? Factory { get; set; }

    [Test]
    public void GenerateAddCommand()
    {
        Factory = new CommandsFactory();
        var command = Factory.GenerateCommand("+");
        Assert.IsInstanceOf<AddCommand>(command);
    }

    [Test]
    public void GenerateDefineCommand()
    {
        Factory = new CommandsFactory();
        var command = Factory.GenerateCommand("DEFINE a 6");
        Assert.IsInstanceOf<DefineCommand>(command);
    }


    [Test]
    public void CheckDefineCommandArguments()
    {
        var expected = DefineCommand.Create("a 6") as DefineCommand;
        Factory = new CommandsFactory();
        var command = Factory.GenerateCommand("DEFINE a 6") as DefineCommand;
        Assert.Multiple(() =>
        {
            Assert.That(expected, Is.Not.Null);
            Assert.That(command, Is.Not.Null);
            Assert.That(command, Is.EqualTo(expected));
        });
    }
}