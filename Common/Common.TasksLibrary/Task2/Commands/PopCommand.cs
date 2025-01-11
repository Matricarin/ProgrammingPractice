using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2.Commands;

public class PopCommand : CalculatorCommand
{
    private string _variableName;

    public PopCommand(string parameters)
    {
        if (string.IsNullOrWhiteSpace(parameters))
        {
            throw new Exception("Unexpected parameter value.");
        }
        var values = parameters.Split(CharsConstants.WhiteSpace);
        if (values.Length > 1)
        {
            throw new Exception("Unexpected amount of parameters for command.");
        }
        _variableName = parameters;
    }
    public override void Process(CalculatorExecutionContext context)
    {
        try
        {
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}