using Common.TasksLibrary.Task2.Attributes;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Handlers;

namespace Common.TasksLibrary.Task2.Commands;

[CommandSignedAs("#")]
public class CommentCommand : ICalculatorCommand
{
    private string? _comment;
    
    private CommentCommand(string? parameters)
    {
        _comment = parameters;
    }
    
    public static ICalculatorCommand Create(string parameters)
    {
        return new CommentCommand(parameters);
    }

    public bool Process(CalculatorExecutionContext context) => true;
}