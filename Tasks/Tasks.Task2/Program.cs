using Common.TasksLibrary;
using Common.TasksLibrary.Task2;
using Common.TasksLibrary.Task2.Output;
using Microsoft.Extensions.Logging;

namespace Tasks.Task2;

internal static class Program
{
    private static void Main(string[] args)
    {
        using ILoggerFactory factory = LoggerFactory.Create(f => f.AddConsole());
        
        var logger = factory.CreateLogger(nameof(Program));
        
        logger.LogInformation(DateTime.Now.ToShortDateString());

        var calculator = new Calculator(logger, 
            new CommandsFactory(), 
            new CalculatorExecutionContext(new ConsoleOutput(), new CalculatorContainer()));

        try
        {
            if (!IsProgramParametersEmpty(args, logger))
            {
                var fileInfo = new FileInfo(args.First());
                calculator.ExecuteFromFile(fileInfo);
            }
        }
        catch (Exception e)
        {
            logger.LogError(e, StringResources.Exception_ExecutionWasInterrupted);
        }
        finally
        {
            ExecuteCommandsFromConsoleInput(calculator);
        }
        
    }
    
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
        while (true)
        {
            var command = Console.ReadLine();
            
            calculator.Execute(command);
        }
    }
}