namespace Common.TasksLibrary.Task2.Base;

public interface ICalculatorCommand<T> where T : BaseExecutionContext
{
    public void Process(Calculator<T> calculator);
}