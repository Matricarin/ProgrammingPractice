using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;

namespace Common.TasksLibrary.Task2.Commands;

public class ExitCommand : ICalculatorCommand
{
    public ExitCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            throw new GenerateCommandException(StringResources.Exception_CommandShouldntHaveParameters);
        }
    }
    
    public bool Process(CalculatorExecutionContext context)
    {
        Environment.Exit(Environment.ExitCode);
    }
}