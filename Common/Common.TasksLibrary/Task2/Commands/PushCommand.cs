﻿using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2.Commands;

public class PushCommand : CalculatorCommand
{
    private string _variableName;
    
    public PushCommand(string parameters)
    {
        if (string.IsNullOrWhiteSpace(parameters))
        {
            throw new Exception("Unexpected parameter value.");
        }
        var values = parameters.Split(CharsConstants.WhiteSpace);
        if (values.Length > 1)
        {
            throw new Exception("Unexpected amount of parameters for command.");
        }
        _variableName = parameters;
    }
    public override void Process(Calculator calculator)
    {
        try
        {
            var isGotValue = calculator.VariablesStorage.TryGetValue(_variableName, out var value);
            if (isGotValue)
            {
                calculator.StackStorage.Push(value);
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}