using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;

namespace Common.TasksLibrary.Task2.Commands;

public class PushCommand : CalculatorCommand
{
    private string _variableName;
    
    public PushCommand(string parameters)
    {
        if (string.IsNullOrWhiteSpace(parameters))
        {
            // todo implement more informative message
            throw new GenerateCommandException();
        }
        var values = parameters.Split(CharsConstants.WhiteSpace);
        if (values.Length > 1)
        {
            // todo implement more informative message
            throw new GenerateCommandException();
        }
        _variableName = parameters;
    }
    public override void Process(CalculatorExecutionContext context)
    {
        try
        {
            context.PushVariable(_variableName);
        }
        catch
        {
            // todo implement more informative message
            throw new ProcessCommandException();
        }
    }
}