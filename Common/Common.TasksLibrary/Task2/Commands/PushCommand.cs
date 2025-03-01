﻿using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;

namespace Common.TasksLibrary.Task2.Commands;

public class PushCommand : CalculatorCommand
{
    private readonly string _variableName;
    
    public PushCommand(string parameters)
    {
        if (string.IsNullOrWhiteSpace(parameters))
        {
            throw new GenerateCommandException(StringResources.Exception_CommandShouldHaveParameter);
        }
        var values = parameters.Split(CharsConstants.WhiteSpace);
        if (values.Length > 1)
        {
            throw new GenerateCommandException(StringResources.Exception_CommandPushOnStackOnlyOne);
        }
        _variableName = parameters;
    }
    public override void Process(CalculatorExecutionContext context)
    {
        try
        {
            context.PushVariable(_variableName);
        }
        catch (Exception e)
        {
            throw new ProcessCommandException(e.Message);
        }
    }
}