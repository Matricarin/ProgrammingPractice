using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Output;
using Microsoft.Extensions.Logging;

namespace Common.TasksLibrary.Task2;

public sealed class CalculatorBuilder
{
    private ILogger _logger;

    public CalculatorBuilder(ILogger logger)
    {
        _logger = logger;
    }
    public CalculatorOutputOptions OutputOptions { get; set; }

    public Calculator Build()
    {
        return new Calculator
        {
            CalcLogger = _logger,
            OutputPort = ConfigureOutput(),
            Factory = ConfigureFactory(),
            ExecutionContext = ConfigureContext()
        };
    }

    private CommandsFactory ConfigureFactory()
    {
        return new CommandsFactory();
    }

    private CalculatorExecutionContext ConfigureContext()
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