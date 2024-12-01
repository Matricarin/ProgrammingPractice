using Common.TasksLibrary.Task2.Base;
using static System.Exception;

namespace Common.TasksLibrary.Task2.Commands;

public sealed class DefineCommand : CalculatorCommand
{
    private string _variableName;
    private double _variableValue;
    public DefineCommand(string name, string value)
    {
        _variableName = name;
        if (!double.TryParse(value, out _variableValue))
        {
            throw new Exception("Variable value was not a number.");
        }
    }
    public override void Process(Calculator calculator)
    {
        if (!calculator.VariablesStorage.TryAdd(_variableName, _variableValue))
        {
            throw new Exception($"Variable \"{_variableName}\" was defined earlier");
        }
    }
}