using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;
using Common.TasksLibrary.Task2.Output;
using Microsoft.Extensions.Logging;

namespace Common.TasksLibrary.Task2;

public sealed class Calculator
{
    internal ILogger CalcLogger;
    internal CommandsFactory Factory { get; init; }
    internal CalculatorExecutionContext ExecutionContext { get; init; }
    public static CalculatorBuilder CreateCalculatorBuilder(ILogger logger, CalculatorOutputOptions options)
    {
        return new CalculatorBuilder(logger, options);
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
        try
        {
            var executingCommand = Factory.GenerateCommand(command);
            executingCommand.Process(ExecutionContext);
        }
        catch (GenerateCommandException gce)
        {
            // todo implement more informative message 
            CalcLogger.LogError("generate command exception");
        }
        catch (ProcessCommandException pce)
        {
            // todo implement more informative message
            CalcLogger.LogError("process command exception");
        }
        catch (ExecutionContextException ece)
        {
            // todo implement more informative message
            CalcLogger.LogError("execution context exception");
        }
    }
}