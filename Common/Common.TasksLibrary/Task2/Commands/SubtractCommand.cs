using Common.TasksLibrary.Task2.Attributes;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;
using Common.TasksLibrary.Task2.Handlers;

namespace Common.TasksLibrary.Task2.Commands;

[CommandSignedAs("-")]
public class SubtractCommand : ICalculatorCommand
{
    public SubtractCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            throw new GenerateCommandException(StringResources.Exception_CommandShouldntHaveParameters);
        }
    }
    public bool Process(CalculatorExecutionContext context)
    {
        try
        {
            var first = context.Pop();
            var second = context.Pop();
            var result = first - second;
            context.Push(result);
        }
        catch (Exception e)
        {
            throw new ProcessCommandException(e.Message);
        }

        return true;
    }
}