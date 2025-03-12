using Common.TasksLibrary.Task2.Attributes;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;
using Common.TasksLibrary.Task2.Handlers;

namespace Common.TasksLibrary.Task2.Commands;

[CommandSignedAs("POP")]
public class PopCommand : ICalculatorCommand
{
    private PopCommand(string parameters)
    {
        if (!string.IsNullOrWhiteSpace(parameters))
        {
            throw new GenerateCommandException(StringResources.Exception_CommandShouldntHaveParameters);
        }
    }

    public static ICalculatorCommand Create(string parameters)
    {
        return new PopCommand(parameters);
    }

    public bool Process(CalculatorExecutionContext context)
    {
        try
        {
            context.Pop();
        }
        catch(Exception e)
        {
            throw new ProcessCommandException(e.Message);
        }
        return true;
    }
}