﻿using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;

namespace Common.TasksLibrary.Task2.Commands;

public class AddCommand : CalculatorCommand
{
    public AddCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            throw new GenerateCommandException(StringResources.Exception_CommandShouldntHaveParameters);
        }
    }
    public override void Process(CalculatorExecutionContext context)
    {
        try
        {
            var first = context.Pop();
            var second = context.Pop();
            var result = first + second;
            context.Push(result);
        }
        catch(Exception e)
        {
            throw new ProcessCommandException(e.Message);
        }
    }
}