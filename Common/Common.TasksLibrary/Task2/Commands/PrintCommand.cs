using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;

namespace Common.TasksLibrary.Task2.Commands;

public class PrintCommand : CalculatorCommand
{
    public PrintCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            // todo implement more informative message
            throw new GenerateCommandException("Print operation can't have command parameters");
        }
    }

    public override void Process(CalculatorExecutionContext context)
    {
        try
        {
            var value = context.Peek();
            context.OutputPort.Post(value);
        }
        catch
        {
            // todo implement more informative message
            throw new ProcessCommandException();
        }
    }
}