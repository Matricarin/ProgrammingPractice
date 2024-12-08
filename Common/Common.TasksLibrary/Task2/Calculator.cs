using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2;

public sealed class Calculator
{
    internal CommandsFactory Factory { get; init; }
    internal Dictionary<string, double> VariablesStorage { get; init; }
    internal Stack<double> StackStorage { get; init; }
    internal IOutput OutputPort { get; init; }

    public static CalculatorBuilder CreateCalculatorBuilder()
    {
        return new CalculatorBuilder();
    }
    public void Execute(IEnumerable<string> commands)
    {
        foreach (var command in commands)
        {
            var executingCommand = Factory.GenerateCommand(command);
            executingCommand.Process(this);
        }
    }
}