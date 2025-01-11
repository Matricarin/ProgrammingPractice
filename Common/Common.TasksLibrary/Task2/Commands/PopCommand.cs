﻿using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2.Commands;

public class PopCommand : CalculatorCommand
{
    private string _variableName;

    public PopCommand(string parameters)
    {
        if (string.IsNullOrWhiteSpace(parameters))
        {
            // todo implement more informative message
            throw new GenerateCommandException();
        }
        var values = parameters.Split(CharsConstants.WhiteSpace);
        if (values.Length > 1)
        {
            // todo implement more informative message
            throw new GenerateCommandException();
        }
        _variableName = parameters;
    }
    public override void Process(CalculatorExecutionContext context)
    {
        try
        {
            
        }
        catch
        {
            // todo implement more informative message
            throw new ProcessCommandException();
        }
    }
}