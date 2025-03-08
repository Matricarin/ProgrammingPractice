namespace Common.TasksLibrary.Task2.Base;

public interface ICalculatorCommand
{
    public bool Process(CalculatorExecutionContext context);
}