using Common.TasksLibrary.Task2.Base;
using static System.Exception;

namespace Common.TasksLibrary.Task2.Commands;

public sealed class DefineCommand : CalculatorCommand
{
    public override void Process(Calculator calculator)
    {
        if (!calculator.VariablesStorage.TryAdd(base.Variable, base.Value))
        {
            throw new Exception($"Variable \"{base.Variable}\" was defined earlier");
        }
    }
}