using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2.Commands;

public class DivideCommand : CalculatorCommand
{
    public DivideCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            throw new Exception("Subtract operation can't have command parameters");
        }
    }

    public DivideCommand()
    {
        
    }
    public override void Process(Calculator calculator)
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