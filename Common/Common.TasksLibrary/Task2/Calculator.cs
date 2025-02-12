using Common.TasksLibrary.Task2.Exceptions;
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
            calcLogger.LogError(gce.Message);
        }
        catch (ProcessCommandException pce)
        {
            calcLogger.LogError($"process {pce.Message} exception");
        }
        catch (ExecutionContextException ece)
        {
            calcLogger.LogError(ece.Message);
        }
    }
}