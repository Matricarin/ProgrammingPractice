﻿using Common.TasksLibrary.Task2.Exceptions;
using Common.TasksLibrary.Task2.Factories;
using Common.TasksLibrary.Task2.Handlers;
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

    public bool ExecuteFromFile(FileInfo info)
    {
        var commands = File.ReadAllLines(info.FullName);

        foreach (var isExecuting in Execute(commands))
        {
            if (!isExecuting)
            {
                return false;
            }
        }

        return true;
    }

    private IEnumerable<bool> Execute(IEnumerable<string> commands)
    {
        return commands.Select(command => Execute(command));
    }

    public bool Execute(string command)
    {
        var isContinueExecution = true;

        try
        {
            var executingCommand = _factory.GenerateCommand(command);

            ArgumentNullException.ThrowIfNull(executingCommand);

            isContinueExecution = executingCommand.Process(_executionContext);
        }
        catch (GenerateCommandException gce)
        {
            _calcLogger.Log(LogLevel.Error, new EventId(1, nameof(Execute)), gce.Message, gce,
                (state, exception) => state);
        }
        catch (ProcessCommandException pce)
        {
            _calcLogger.Log(LogLevel.Error, new EventId(1, nameof(Execute)), pce.Message, pce,
                (state, exception) => state);
        }
        catch (ExecutionContextException ece)
        {
            _calcLogger.Log(LogLevel.Error, new EventId(1, nameof(Execute)), ece.Message, ece,
                (state, exception) => state);
        }
        catch (ArgumentNullException ane)
        {
            _calcLogger.Log(LogLevel.Error, new EventId(1, nameof(Execute)), ane.Message, ane,
                (state, exception) => state);
        }
        catch (Exception ex)
        {
            _calcLogger.Log(LogLevel.Error, new EventId(1, nameof(Execute)), ex.Message, ex,
                (state, exception) => state);
        }
        

        return isContinueExecution;
    }
}