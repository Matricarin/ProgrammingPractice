using Common.TasksLibrary.Task2.Base;

namespace PracticeTests.Task2Tests;

public class MockContainer : BaseContainer
{
    public MockContainer()
    {
        VariableStorage = new Dictionary<string, double>();
        Stack = new Stack<double>();
    }

    public override Dictionary<string, double> VariableStorage { get; set; }
    public override Stack<double> Stack { get; set; }
}