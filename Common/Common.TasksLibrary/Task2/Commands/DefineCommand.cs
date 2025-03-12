using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Extensions;
using Common.TasksLibrary.Task2.Attributes;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;
using Common.TasksLibrary.Task2.Handlers;

namespace Common.TasksLibrary.Task2.Commands;

[CommandSignedAs("DEFINE")]
public sealed class DefineCommand : ICalculatorCommand
{
    private readonly string _variableName;
    private readonly double _variableValue;
    private DefineCommand(string parameters)
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
    public static ICalculatorCommand Create(string parameters)
    {
        return new DefineCommand(parameters);
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

        if (other.IsNull())
        {
            return false;
        }
        
        return _variableName == other._variableName 
               && _variableValue.Equals(other._variableValue); 
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_variableName, _variableValue);
    }
}