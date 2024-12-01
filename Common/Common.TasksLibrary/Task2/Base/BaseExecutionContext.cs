namespace Common.TasksLibrary.Task2.Base;

public abstract class BaseExecutionContext
{
    private Dictionary<string, string> _commandMapper;

    public BaseExecutionContext(Dictionary<string, string> commands)
    {
        _commandMapper = commands;
    }
    public virtual ICalculatorCommand<BaseExecutionContext> GenerateCommand(string textCommand)
    {
        
    }
}