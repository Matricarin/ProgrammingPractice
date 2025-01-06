using Common.TasksLibrary.Task2.Output;

namespace Common.TasksLibrary.Task2.Base;

public sealed class CalculatorBuilder
{
    public CalculatorOutputOptions OutputOptions { get; set; }

    public Calculator Build()
    {
        return new Calculator
        {
            OutputPort = ConfigureOutput(),
            Factory = ConfigureFactory(),
            ExecutionContext = ConfigureContext()
        };
    }

    private CommandsFactory ConfigureFactory()
    {
        return new CommandsFactory();
    }

    private IExecutionContext ConfigureContext()
    {
        return new CalculatorExecutionContext();
    }

    private IOutput ConfigureOutput()
    {
        return OutputOptions switch
        {
            CalculatorOutputOptions.Console => new ConsoleOutput(),
            _ => throw new ArgumentOutOfRangeException(nameof(OutputOptions), OutputOptions, null)
        };
    }
}