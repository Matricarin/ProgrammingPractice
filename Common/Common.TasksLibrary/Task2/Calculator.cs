using Common.TasksLibrary.Task2.Exceptions;
using Microsoft.Extensions.Logging;

namespace Common.TasksLibrary.Task2;

public sealed class Calculator
{
    private readonly ILogger _calcLogger;
    private readonly CommandsFactory _factory;
    private readonly CalculatorExecutionContext _executionContext;
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

    private void Execute(IEnumerable<string> commands)
    {
        foreach (var command in commands)
        {
            Execute(command);
        }
    }
    public bool Execute(string command)
    {
        var isContinueExecution = true;
        
        try
        {
            var executingCommand = _factory.GenerateCommand(command);
            
            if (executingCommand != null)
            {
                isContinueExecution = executingCommand.Process(_executionContext);
            }
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
        
        return isContinueExecution;
    }
}