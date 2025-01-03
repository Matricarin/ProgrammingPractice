using Common.TasksLibrary.Task2;
using Common.TasksLibrary.Task2.Base;

namespace Tasks.Task2;

internal static class Program
{
    private static void Main(string[] args)
    {
        var fileInfo = new FileInfo(args.First());

        var calculator = new CalculatorBuilder
            {
                OutputOptions = CalculatorOutputOptions.Console
            }
            .Build();
        
        ExecuteCommandsFromFile(fileInfo, calculator);
        
        ExecuteCommandsFromConsoleInput(calculator);
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