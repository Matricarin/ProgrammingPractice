namespace Common.TasksLibrary.Task2.Base;

public abstract class CalculatorCommand
{
    protected string Variable { get; init; } 
    protected double Value { get; init; }
    public abstract void Process(Calculator calculator);
}