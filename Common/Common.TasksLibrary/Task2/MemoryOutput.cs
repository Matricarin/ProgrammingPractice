using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2;

public class MemoryOutput : IOutput
{
    private List<double> _valuesStorage;

    public MemoryOutput()
    {
        _valuesStorage = new List<double>();
    }

    public double Value => _valuesStorage.Last();

    public void Post(double data)
    {
        _valuesStorage.Add(data);
    }
}