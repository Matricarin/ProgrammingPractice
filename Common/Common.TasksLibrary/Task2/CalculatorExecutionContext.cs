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
        try
        {
            return Container.Stack.Peek();
        }
        catch 
        {
            throw new ExecutionContextException(StringResources.Exception_StackIsEmpty);
        }
    }

    public double Pop()
    {
        try
        {
            return Container.Stack.Pop();
        }
        catch 
        { 
            throw new ExecutionContextException(StringResources.Exception_StackIsEmpty);
        }
    }

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
            throw new ExecutionContextException(e.Message);
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
            throw new ExecutionContextException(e.Message);
        }
    }
}