using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2;

public sealed class CalculatorExecutionContext : IExecutionContext
{
    private Dictionary<string, double> _variableStorage;
    private Stack<double> _stack;

    public CalculatorExecutionContext()
    {
        _variableStorage = new Dictionary<string, double>();
        _stack = new Stack<double>();
    }
    public double Peek()
    {
        return 0;
    }

    public double Pop()
    {
        return 0;
    }

    public void Push(string variableName) { }

    public void AddVariable() { }
}