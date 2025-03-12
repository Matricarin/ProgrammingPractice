using Common.TasksLibrary.Task2.Attributes;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;
using Common.TasksLibrary.Task2.Handlers;

namespace Common.TasksLibrary.Task2.Commands;

[CommandSignedAs("PRINT")]
public class PrintCommand : ICalculatorCommand
{
    public PrintCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            throw new GenerateCommandException(StringResources.Exception_CommandShouldntHaveParameters);
        }
    }

    public bool Process(CalculatorExecutionContext context)
    {
        try
        {
            var value = context.Peek();
            context.OutputPort.Post(value);
        }
        catch (ProcessCommandException pce)
        {
            throw new ProcessCommandException(pce.Message);
        }
        catch(ExecutionContextException ece)
        {
            throw new ProcessCommandException(ece.Message);
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
        return true;
    }

    public static ICalculatorCommand Create(string parameters)
    {
        return new PrintCommand(parameters);
    }
}