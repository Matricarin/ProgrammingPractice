using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;
using Common.TasksLibrary.Task2.Handlers;

namespace Common.TasksLibrary.Task2.Commands;

public class PopCommand : ICalculatorCommand
{
    public PopCommand(string parameters)
    {
        if (!string.IsNullOrWhiteSpace(parameters))
        {
            throw new GenerateCommandException(StringResources.Exception_CommandShouldntHaveParameters);
        }
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