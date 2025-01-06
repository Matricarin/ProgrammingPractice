using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2.Commands;

public class AddCommand : CalculatorCommand
{
    public AddCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            throw new Exception("Adding operation can't have command parameters");
        }
    }

    public AddCommand()
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