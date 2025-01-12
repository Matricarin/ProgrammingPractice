using Common.TasksLibrary.Task2.Output;

namespace Common.TasksLibrary.Task2.Base;

public interface ISpecifyOutput
{
    public ISpecifyStorage OutBy(CalculatorOutputOptions options);
}