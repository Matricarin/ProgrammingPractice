using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Task2.Attributes;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;
using Common.TasksLibrary.Task2.Handlers;

namespace Common.TasksLibrary.Task2.Commands;

[CommandSignedAs("PUSH")]
public class PushCommand : ICalculatorCommand
{
    private readonly string _variableName;
    
    private PushCommand(string parameters)
    {
        if (string.IsNullOrWhiteSpace(parameters))
        {
            throw new GenerateCommandException(StringResources.Exception_CommandShouldHaveParameter);
        }
        var values = parameters.Split(CharsConstants.WhiteSpace);
        if (values.Length > 1)
        {
            throw new GenerateCommandException(StringResources.Exception_CommandPushOnStackOnlyOne);
        }
        _variableName = parameters;
    }
    public bool Process(CalculatorExecutionContext context)
    {
        try
        {
            context.PushVariable(_variableName);
        }
        catch (Exception e)
        {
            throw new ProcessCommandException(e.Message);
        }
        return true;
    }

    public static ICalculatorCommand Create(string parameters)
    {
        return new PushCommand(parameters);
    }
}