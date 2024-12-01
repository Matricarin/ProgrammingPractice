using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2;

public sealed class Calculator
{
    private CommandsFactory _factory;
    internal Dictionary<string, double> VariablesStorage = new Dictionary<string, double>();
    internal Stack<double> StackStorage = new Stack<double>();
    public Calculator(CommandsFactory factory)
    {
        _factory = factory;
    }
    public void Execute(IEnumerable<string> commands)
    {
        foreach (var command in commands)
        {
            var executingCommand = _factory.GenerateCommand(command);
            executingCommand.Process(this);
        }
    }
}