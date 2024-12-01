using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2;

public sealed class Calculator<T> where T : BaseExecutionContext
{
    private T _context;

    public Calculator(T executionContext)
    {
        _context = executionContext;
    }

    public void Execute(IEnumerable<string> commands)
    {
        
    }
}