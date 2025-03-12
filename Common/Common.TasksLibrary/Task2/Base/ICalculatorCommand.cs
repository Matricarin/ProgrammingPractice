using Common.TasksLibrary.Task2.Handlers;

namespace Common.TasksLibrary.Task2.Base;

public interface ICalculatorCommand
{
    public bool Process(CalculatorExecutionContext context);
    public static abstract ICalculatorCommand Create(string parameters);
}