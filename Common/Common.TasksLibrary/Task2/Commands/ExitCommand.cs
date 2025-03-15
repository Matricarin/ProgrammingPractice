using Common.TasksLibrary.Task2.Attributes;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;
using Common.TasksLibrary.Task2.Handlers;

namespace Common.TasksLibrary.Task2.Commands;

[CommandSignedAs("EXIT")]
public class ExitCommand : ICalculatorCommand
{
    private ExitCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            throw new GenerateCommandException(StringResources.Exception_CommandShouldntHaveParameters);
        }
    }
    
    public bool Process(CalculatorExecutionContext context) => false;
    public static ICalculatorCommand Create(string parameters)
    {
        return new ExitCommand(parameters);
    }
}