using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;
using Common.TasksLibrary.Task2.Output;
using Microsoft.Extensions.Logging;

namespace Common.TasksLibrary.Task2;

public sealed class Calculator
{
    internal ILogger calcLogger;
    internal CommandsFactory factory;
    internal CalculatorExecutionContext executionContext;
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
            var executingCommand = factory.GenerateCommand(command);
            executingCommand.Process(executionContext);
        }
        catch (GenerateCommandException gce)
        {
            // todo implement more informative message 
            calcLogger.LogError("generate command exception");
        }
        catch (ProcessCommandException pce)
        {
            calcLogger.LogError($"process {pce.Message} exception");
        }
        catch (ExecutionContextException ece)
        {
            // todo implement more informative message
            calcLogger.LogError("execution context exception");
        }
    }
}