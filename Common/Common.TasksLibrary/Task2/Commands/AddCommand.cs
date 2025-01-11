using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2.Commands;

public class AddCommand : CalculatorCommand
{
    public AddCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            // todo implement more informative message
            throw new GenerateCommandException("Adding operation can't have command parameters");
        }
    }
    public override void Process(CalculatorExecutionContext context)
    {
        try
        {
            
        }
        catch (Exception e)
        {
            throw new ProcessCommandException();
        }
    }
}