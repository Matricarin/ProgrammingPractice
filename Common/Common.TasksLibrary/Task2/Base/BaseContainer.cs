namespace Common.TasksLibrary.Task2.Base;

public abstract class BaseContainer
{
    public abstract Dictionary<string, double> VariableStorage { get; set; }
    public abstract Stack<double> Stack { get; set; }
}