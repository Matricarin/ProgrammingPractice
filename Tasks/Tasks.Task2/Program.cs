using System.Diagnostics.Contracts;
using Common.TasksLibrary;
using Common.TasksLibrary.Extensions;
using Common.TasksLibrary.Task2;
using Common.TasksLibrary.Task2.Factories;
using Common.TasksLibrary.Task2.Handlers;
using Common.TasksLibrary.Task2.Providers;
using Microsoft.Extensions.Logging;

namespace Tasks.Task2;

internal static class Program
{
    private static void Main(string[] args)
    {
        using var factory = LoggerFactory.Create(f => f.AddConsole());
        
        var logger = factory.CreateLogger(nameof(Program));
        
        logger.LogInformation(DateTime.Now.ToShortDateString());

        var calculator = new Calculator(logger, 
            new CommandsFactory(), 
            new CalculatorExecutionContext(new ConsoleOutput(), new CalculatorContainer()));

        var isContinueAfterCommandsListExecution = true;

        try
        {
            if (!IsProgramParametersEmpty(args, logger))
            {
                var fileInfo = new FileInfo(args.First());
                isContinueAfterCommandsListExecution = calculator.ExecuteFromFile(fileInfo);
            }
        }
        catch (Exception e)
        {
            logger.LogError(e, StringResources.Exception_ExecutionWasInterrupted);
        }
        finally
        {
            if (isContinueAfterCommandsListExecution)
            {
                ExecuteCommandsFromConsoleInput(calculator);
            }
        }
        
    }
    
    [Pure]
    private static bool IsProgramParametersEmpty(string[] args, ILogger logger)
    {
        if (args.Length == 0)
        {
            logger.LogWarning(StringResources.Warning_FilePathWasNotSpecified);
            return true;
        }
    
        return false;
    }
    
    private static void ExecuteCommandsFromConsoleInput(Calculator calculator)
    {
        var isExecuting = true;
        while (isExecuting)
        {
            var command = Console.ReadLine();
            if (!command.IsNull())
            {
                isExecuting = calculator.Execute(command);
            }
        }
    }
}