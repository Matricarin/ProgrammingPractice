using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2.Commands;

public class PrintCommand : CalculatorCommand
{

    public PrintCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            throw new Exception("Adding operation can't have command parameters");
        }
    }

    public PrintCommand()
    {
        
    }
    public override void Process(Calculator calculator)
    {
        try
        {
            var value = calculator.StackStorage.Peek();
            calculator.OutputPort.Post(value);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}