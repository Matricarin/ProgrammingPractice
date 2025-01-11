using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Output;
using Microsoft.Extensions.Logging;

namespace Common.TasksLibrary.Task2;

public sealed class CalculatorBuilder
{
    private readonly ILogger _logger;
    private readonly CalculatorOutputOptions _outputOptions;

    public CalculatorBuilder(ILogger logger, CalculatorOutputOptions options)
    {
        _logger = logger;
        _outputOptions = options;
    }

    public Calculator Build()
    {
        return new Calculator
        {
            CalcLogger = _logger,
            Factory = ConfigureFactory(),
            ExecutionContext = ConfigureContext()
        };
    }

    private static CommandsFactory ConfigureFactory()
    {
        return new CommandsFactory();
    }

    private CalculatorExecutionContext ConfigureContext()
    {
        return _outputOptions switch
        {
            CalculatorOutputOptions.Console => new CalculatorExecutionContext(new ConsoleOutput()),
            _ => throw new ArgumentException()
        };
    }
}