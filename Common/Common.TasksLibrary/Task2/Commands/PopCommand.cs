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
            // todo implement more informative message
            throw new GenerateCommandException();
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
            // todo implement more informative message
            throw new ProcessCommandException();
        }
    }
}