using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;

namespace Common.TasksLibrary.Task2;

public sealed class CalculatorExecutionContext
{
    private BaseContainer Container { get; }
    public IOutput OutputPort { get; set; }

    public CalculatorExecutionContext(IOutput output, BaseContainer container)
    {
        Container = container;
        OutputPort = output;
    }

    public double Peek() => Container.Stack.Peek();

    public double Pop() => Container.Stack.Pop();

    public void Push(double number) => Container.Stack.Push(number);

    public void PushVariable(string variableName)
    {
        try
        {
            var value = Container.VariableStorage[variableName];
            Container.Stack.Push(value);
        }
        catch (Exception e)
        {
            throw new ExecutionContextException();
        }
    }

    public void DefineVariable(string variableName, double value)
    {
        try
        {
            Container.VariableStorage.Add(variableName, value);
        }
        catch (Exception e)
        {
            throw new ExecutionContextException();
        }
    }
}