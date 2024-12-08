using Common.TasksLibrary.Task2.Output;

namespace Common.TasksLibrary.Task2.Base;

public sealed class CalculatorBuilder
{
    public CalculatorOutputOptions OutputOptions { get; set; }
    public CommandsList Commands { get; set; }

    public Calculator Build()
    {
        return new Calculator
        {
            OutputPort = ConfigureOutput(),
            Factory = ConfigureFactory(),
            VariablesStorage = new Dictionary<string, double>(),
            StackStorage = new Stack<double>()
        };
    }

    private CommandsFactory ConfigureFactory()
    {
        return new CommandsFactory(Commands);
    }

    private IOutput ConfigureOutput()
    {
        return OutputOptions switch
        {
            CalculatorOutputOptions.Console => new ConsoleOutput(),
            CalculatorOutputOptions.Memory => new MemoryOutput(),
            _ => throw new ArgumentOutOfRangeException(nameof(OutputOptions), OutputOptions, null)
        };
    }
}