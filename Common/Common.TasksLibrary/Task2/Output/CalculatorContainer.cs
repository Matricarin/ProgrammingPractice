using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2.Output;

public sealed class CalculatorContainer : BaseContainer
{
    public override Dictionary<string, double> VariableStorage { get; set; } = new();
    public override Stack<double> Stack { get; set; } = new();
}