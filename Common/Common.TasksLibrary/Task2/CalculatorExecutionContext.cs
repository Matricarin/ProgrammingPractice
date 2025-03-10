using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;

namespace Common.TasksLibrary.Task2;

public sealed class CalculatorExecutionContext
{
    private BaseContainer Container { get; }
    public IOutput OutputPort { get; set; }

    public CalculatorExecutionContext(IOutput output, BaseContainer container)
    {
        Container = container ?? throw new ExecutionContextException
            (StringResources.Exception_CantCreateExecutionContext + "| Cant define container");
        OutputPort = output ?? throw new ExecutionContextException
            (StringResources.Exception_CantCreateExecutionContext + "| Cant define output port");
    }

    public double Peek()
    {
        return Container.Stack.Peek();
    }

    public double Pop()
    {
        return Container.Stack.Pop();
    }

    public void Push(double number) => Container.Stack.Push(number);

    public void PushVariable(string variableName)
    {
        var value = Container.VariableStorage[variableName];
        Container.Stack.Push(value);
    }

    public void DefineVariable(string variableName, double value)
    {
        Container.VariableStorage.Add(variableName, value);
    }
}