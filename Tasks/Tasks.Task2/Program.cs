using Common.TasksLibrary.Task2;
using Common.TasksLibrary.Task2.Base;

namespace Tasks.Task2;

internal static class Program
{
    private static void Main(string[] args)
    {
        var calculator = new CalculatorBuilder
            {
                OutputOptions = CalculatorOutputOptions.Console
            }
            .Build();
        if (args.Length > 0 && !string.IsNullOrEmpty(args.First()))
        {
            var fileInfo = new FileInfo(args.First());
            ExecuteCommandsFromFile(fileInfo, calculator);
        }
        ExecuteCommandsFromConsoleInput(calculator);
    }

    private static void ExecuteCommandsFromFile(FileInfo fileInfo, Calculator calculator)
    {
        var commands = File.ReadAllLines(fileInfo.FullName);
        if (commands.Length > 0)
        {
            calculator.Execute(commands);
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