using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2.Commands;

public class MultiplyCommand : CalculatorCommand
{
    public MultiplyCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            throw new Exception("Subtract operation can't have command parameters");
        }
    }

    public MultiplyCommand()
    {
        
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