using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2.Commands;

public class ExitCommand : CalculatorCommand
{
    public ExitCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            // todo implement more informative message
            throw new GenerateCommandException();
        }
    }
    
    public override void Process(CalculatorExecutionContext context)
    {
        Environment.Exit(Environment.ExitCode);
    }
}