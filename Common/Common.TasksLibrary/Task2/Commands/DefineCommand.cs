using System.Runtime.CompilerServices;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Constants;

namespace Common.TasksLibrary.Task2.Commands;

public sealed class DefineCommand : CalculatorCommand
{
    private string _variableName;
    private double _variableValue;
    public DefineCommand(string parameters)
    {
        var values = parameters.Split(CharsConstants.WhiteSpace);
        if (values.Length != 2)
        {
            throw new Exception("Unexpected amount of parameters for command");
        }

        _variableName = values.First();
        if (!double.TryParse(values.Last(), out _variableValue))
        {
            throw new Exception("Unexpected value for command parameter");
        }
    }
    public override void Process(Calculator calculator)
    {
        if (!calculator.VariablesStorage.TryAdd(_variableName, _variableValue))
        {
            throw new Exception($"Variable \"{_variableName}\" was defined earlier");
        }
    }

    public override bool Equals(object? obj)
    {
        var other = (DefineCommand)obj;
        if (other == null)
        {
            return false;
        }
        return _variableName == other._variableName && _variableValue.Equals(other._variableValue);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_variableName, _variableValue);
    }
}