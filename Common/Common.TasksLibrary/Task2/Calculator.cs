using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2;

public sealed class Calculator
{
    private readonly CommandsFactory _factory;
    internal Dictionary<string, double> VariablesStorage = new Dictionary<string, double>();
    internal Stack<double> StackStorage = new Stack<double>();
    internal IOutput OutputPort { get;}
    public Calculator(CommandsFactory factory, IOutput outputPort)
    {
        _factory = factory;
        OutputPort = outputPort;
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