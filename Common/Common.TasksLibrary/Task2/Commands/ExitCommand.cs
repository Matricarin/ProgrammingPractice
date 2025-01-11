using System.Reflection;
using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2.Commands;

public class ExitCommand : CalculatorCommand
{
    public ExitCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            throw new Exception("Exit operation can't have command parameters");
        }
    }

    public ExitCommand()
    {
        
    }
    public override void Process(CalculatorExecutionContext context)
    {
        Environment.Exit(Environment.ExitCode);
    }
}