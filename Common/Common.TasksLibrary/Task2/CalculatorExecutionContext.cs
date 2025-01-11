using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2;

public sealed class CalculatorExecutionContext
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
        // todo implement method for getting top stack value
        return 0;
    }

    public double Pop()
    {
        // todo implement method for taking top stack value
        return 0;
    }

    public void Push(string variableName)
    {
        // todo implement method for putting value on a stack
    }

    public void AddVariable()
    {
        // todo implement method for defining a variable
    }
}