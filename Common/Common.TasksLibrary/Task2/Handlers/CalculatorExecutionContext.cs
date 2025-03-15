using Common.TasksLibrary.Extensions;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;
using static Common.TasksLibrary.StringResources;

namespace Common.TasksLibrary.Task2.Handlers;

public sealed class CalculatorExecutionContext
{
    private readonly BaseContainer _container;
    private IOutput _port;
    public IOutput OutputPort
    {
        get => _port;
        set
        {
            if (value.IsNull())
            {
                throw new ExecutionContextException
                    (Exception_CantCreateExecutionContext + "| Cant define output port");
            }

            _port = value;
        }
    }

    public CalculatorExecutionContext(IOutput output, BaseContainer container)
    {
        if (output.IsNull())
        {
            throw new ExecutionContextException
                (Exception_CantCreateExecutionContext + "| Cant define output port");
        }

        if (container.IsNull())
        {
            throw new ExecutionContextException
                (Exception_CantCreateExecutionContext + "| Cant define container");
        }

        _container = container;
        _port = output;
    }

    public double Peek()
    {
        return _container.Stack.Peek();
    }

    public double Pop()
    {
        return _container.Stack.Pop();
    }

    public void Push(double number) => _container.Stack.Push(number);

    public void PushVariable(string variableName)
    {
        var value = _container.VariableStorage[variableName];
        _container.Stack.Push(value);
    }

    public void DefineVariable(string variableName, double value)
    {
        _container.VariableStorage.Add(variableName, value);
    }
}