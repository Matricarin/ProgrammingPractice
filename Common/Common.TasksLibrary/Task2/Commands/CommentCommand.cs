using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2.Commands;

public class CommentCommand : CalculatorCommand
{
    private string? _comment;
    
    public CommentCommand(string? parameters)
    {
        _comment = parameters;
    }

    public override void Process(CalculatorExecutionContext context) { }
}