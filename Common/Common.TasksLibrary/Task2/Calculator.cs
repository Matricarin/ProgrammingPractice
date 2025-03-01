using Common.TasksLibrary.Task2.Exceptions;
using Microsoft.Extensions.Logging;

namespace Common.TasksLibrary.Task2;

public sealed class Calculator
{
    private ILogger _calcLogger;
    private CommandsFactory _factory;
    private CalculatorExecutionContext _executionContext;
    public Calculator(ILogger logger, CommandsFactory factory, CalculatorExecutionContext context)
    {
        _calcLogger = logger;
        _factory = factory;
        _executionContext = context;
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
            var executingCommand = _factory.GenerateCommand(command);
            executingCommand.Process(_executionContext);
        }
        catch (GenerateCommandException gce)
        {
            _calcLogger.LogError(gce.Message);
        }
        catch (ProcessCommandException pce)
        {
            _calcLogger.LogError(pce.Message);
        }
        catch (ExecutionContextException ece)
        {
            _calcLogger.LogError(ece.Message);
        }
    }
}