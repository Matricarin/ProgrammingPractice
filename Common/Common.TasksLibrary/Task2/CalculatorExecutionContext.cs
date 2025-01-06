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
        throw new NotImplementedException();
    }

    public double Pop()
    {
        throw new NotImplementedException();
    }

    public double Push(string variableName)
    {
        throw new NotImplementedException();
    }

    public void AddVariable()
    {
        throw new NotImplementedException();
    }
}