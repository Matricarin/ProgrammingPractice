using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;
using Common.TasksLibrary.Task2.Handlers;

namespace Common.TasksLibrary.Task2.Commands;

public sealed class DefineCommand : ICalculatorCommand
{
    private readonly string _variableName;
    private readonly double _variableValue;
    public DefineCommand(string parameters)
    {
        var values = parameters.Split(CharsConstants.WhiteSpace);
        if (values.Length != 2)
        {
            throw new GenerateCommandException(StringResources.Exception_IncorrectAmountForDefineCommand);
        }

        _variableName = values.First();
        if (!double.TryParse(values.Last(), out _variableValue))
        {
            throw new GenerateCommandException(StringResources.Exception_DefineCantParseValue);
        }
    }
    public bool Process(CalculatorExecutionContext context)
    {
        try
        {
            context.DefineVariable(_variableName, _variableValue);
        }
        catch (Exception e)
        {
            throw new ProcessCommandException(e.Message);
        }
        return true;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }
        
        var other = (DefineCommand)obj;
        
        return _variableName == other._variableName && _variableValue.Equals(other._variableValue); //todo implement correct comparison
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_variableName, _variableValue);
    }
}