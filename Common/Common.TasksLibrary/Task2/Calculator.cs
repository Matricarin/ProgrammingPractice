using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2;

public sealed class Calculator
{
    internal CommandsFactory Factory { get; init; }
    internal Dictionary<string, double> VariablesStorage { get; init; }
    internal Stack<double> StackStorage { get; init; }
    public IOutput OutputPort { get; init; }
    public static CalculatorBuilder CreateCalculatorBuilder()
    {
        return new CalculatorBuilder();
    }
    public void Execute(IEnumerable<string> commands)
    {
        foreach (var command in commands)
        {
            Execute(command);
        }
    }
    public void Execute(string command)
    {
        var executingCommand = Factory.GenerateCommand(command);
        executingCommand.Process(this);
    }
}