using Common.TasksLibrary.Task2.Attributes;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;
using Common.TasksLibrary.Task2.Handlers;

namespace Common.TasksLibrary.Task2.Commands;

[CommandSignedAs("SQRT")]
public class SqrtCommand : ICalculatorCommand
{
    public SqrtCommand(string parameters)
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
            var data = context.Pop();
            context.Push(Math.Sqrt(data));
        }
        catch(Exception e)
        {
            throw new ProcessCommandException(e.Message);
        }
        return true;
    }

    public static ICalculatorCommand Create(string parameters)
    {
        return new SqrtCommand(parameters);
    }
}