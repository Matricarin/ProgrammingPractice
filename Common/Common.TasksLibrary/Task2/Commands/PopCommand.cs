using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;

namespace Common.TasksLibrary.Task2.Commands;

public class PopCommand : CalculatorCommand
{
    public PopCommand(string parameters)
    {
        if (!string.IsNullOrWhiteSpace(parameters))
        {
            throw new GenerateCommandException(StringResources.Exception_CommandShouldntHaveParameters);
        }
    }
    public override void Process(CalculatorExecutionContext context)
    {
        try
        {
            context.Pop();
        }
        catch
        {
            throw new ProcessCommandException(nameof(PopCommand));
        }
    }
}