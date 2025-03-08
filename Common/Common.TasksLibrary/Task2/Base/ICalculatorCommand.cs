namespace Common.TasksLibrary.Task2.Base;

public interface ICalculatorCommand
{
    public void Process(CalculatorExecutionContext context);
}