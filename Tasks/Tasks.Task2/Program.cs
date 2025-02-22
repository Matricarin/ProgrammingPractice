using Common.TasksLibrary;
using Common.TasksLibrary.Task2;
using Common.TasksLibrary.Task2.Output;
using Microsoft.Extensions.Logging;

namespace Tasks.Task2;

internal static class Program
{
    private static ILogger _logger;

    private static void Main(string[] args)
    {
        CreateConsoleLogger();

        var calculator = CalculatorBuilder.Create().LogBy(_logger).OutBy(CalculatorOutputOptions.Console)
            .StoreBy(new CalculatorContainer()).Build();

        try
        {
            if (!IsProgramParametersEmpty(args))
            {
                var fileInfo = new FileInfo(args.First());
                calculator.ExecuteFromFile(fileInfo);
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, StringResources.Exception_ExecutionWasInterrupted);
        }
        finally
        {
            ExecuteCommandsFromConsoleInput(calculator);
        }
        
    }

    private static void CreateConsoleLogger()
    {
        using ILoggerFactory factory = LoggerFactory.Create(f => f.AddConsole());
        _logger = factory.CreateLogger(nameof(Program));
        _logger.LogInformation(DateTime.Now.ToShortDateString());
    }
    
    private static bool IsProgramParametersEmpty(string[] args)
    {
        if (args.Length == 0)
        {
            _logger.LogWarning(StringResources.Warning_FilePathWasNotSpecified);
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