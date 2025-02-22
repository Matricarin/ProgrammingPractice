using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2.Output;

public class CalculatorContainer : BaseContainer
{
    public CalculatorContainer()
    {
        VariableStorage = new Dictionary<string, double>();
        Stack = new Stack<double>();
    }

    public override Dictionary<string, double> VariableStorage { get; set; }
    public override Stack<double> Stack { get; set; }
}