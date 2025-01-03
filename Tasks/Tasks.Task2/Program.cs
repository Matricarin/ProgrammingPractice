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
        
        if (!IsProgramParametersEmpty(args))
        {
            
        }
        
    }

    private static void CreateConsoleLogger()
    {
        using ILoggerFactory factory = LoggerFactory.Create(f => f.AddConsole());
        _logger = factory.CreateLogger("Program");
        _logger.LogInformation("***  Calculator  ***");
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
        try
        {
            var commands = File.ReadAllLines(fileInfo.FullName);
            
            calculator.Execute(commands);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
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