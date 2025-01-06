using Common.TasksLibrary.Task2;
using Common.TasksLibrary.Task2.Base;
using Microsoft.Extensions.Logging;

namespace Tasks.Task2;

internal static class Program
{
    private static ILogger? _logger;
    private static void Main(string[] args)
    {
        CreateConsoleLogger();

        var calculator = CreateCalculatorInstance(CalculatorOutputOptions.Console);

        try
        {
            if (!IsProgramParametersEmpty(args))
            {
                var fileInfo = new FileInfo(args.First());
                ExecuteCommandsFromFile(fileInfo, calculator);
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Execution from file was interrupted.");
        }
        finally
        {
            ExecuteCommandsFromConsoleInput(calculator);
        }
        
    }

    private static void CreateConsoleLogger()
    {
        using ILoggerFactory factory = LoggerFactory.Create(f => f.AddConsole());
        _logger = factory.CreateLogger("Program");
        _logger.LogInformation(DateTime.Now.ToShortDateString());
    }

    private static Calculator CreateCalculatorInstance(CalculatorOutputOptions options)
    {
        return new CalculatorBuilder()
        {
            OutputOptions = options
        }.Build();
    }

    private static bool IsProgramParametersEmpty(string[] args)
    {
        if (args.Length == 0)
        {
            _logger.LogWarning("Input parameters were empty");
            return true;
        }

        return false;
    }

    private static void ExecuteCommandsFromFile(FileInfo fileInfo, Calculator calculator)
    {
        var commands = File.ReadAllLines(fileInfo.FullName);
        
        calculator.Execute(commands);
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