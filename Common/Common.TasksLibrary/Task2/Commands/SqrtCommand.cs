using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;

namespace Common.TasksLibrary.Task2.Commands;

public class SqrtCommand : CalculatorCommand
{
    public SqrtCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            // todo implement more informative message
            throw new GenerateCommandException();
        }
    }
    public override void Process(CalculatorExecutionContext context)
    {
        try
        {
            var data = context.Pop();
            context.Push(Math.Sqrt(data));
        }
        catch
        {
            // todo implement more informative message
            throw new ProcessCommandException();
        }
    }
}