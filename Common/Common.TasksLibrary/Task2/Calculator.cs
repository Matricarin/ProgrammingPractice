using Common.TasksLibrary.Task2.Exceptions;
using Microsoft.Extensions.Logging;

namespace Common.TasksLibrary.Task2;

public sealed class Calculator
{
    private ILogger calcLogger;
    private CommandsFactory factory;
    private CalculatorExecutionContext executionContext;
    public Calculator(ILogger logger, CommandsFactory factory, CalculatorExecutionContext context)
    {
        calcLogger = logger;
    }
    
    public void ExecuteFromFile(FileInfo info)
    {
        var commands = File.ReadAllLines(info.FullName);
        Execute(commands);
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
            var executingCommand = factory.GenerateCommand(command);
            executingCommand.Process(executionContext);
        }
        catch (GenerateCommandException gce)
        {
            calcLogger.LogError(gce.Message);
        }
        catch (ProcessCommandException pce)
        {
            calcLogger.LogError(pce.Message);
        }
        catch (ExecutionContextException ece)
        {
            calcLogger.LogError(ece.Message);
        }
    }
}