using Common.TasksLibrary.Task2.Attributes;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;
using Common.TasksLibrary.Task2.Handlers;

namespace Common.TasksLibrary.Task2.Commands;

[CommandSignedAs("+")]
public class AddCommand : ICalculatorCommand
{
    private AddCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            throw new GenerateCommandException(StringResources.Exception_CommandShouldntHaveParameters);
        }
    }
    
    public static ICalculatorCommand Create(string parameters)
    {
        return new AddCommand(parameters);
    }
    
    public bool Process(CalculatorExecutionContext context)
    {
        try
        {
            var first = context.Pop();
            var second = context.Pop();
            var result = first + second;
            context.Push(result);
        }
        catch(Exception e)
        {
            throw new ProcessCommandException(e.Message);
        }
        return true;
    }
}