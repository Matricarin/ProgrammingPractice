using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;

namespace Common.TasksLibrary.Task2.Commands;

public class SubtractCommand : CalculatorCommand
{
    public SubtractCommand(string parameters)
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
            var first = context.Pop();
            var second = context.Pop();
            var result = first - second;
            context.Push(result);
        }
        catch 
        {
            // todo implement more informative message
            throw new ProcessCommandException();
        }
    }
}