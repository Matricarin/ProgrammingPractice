﻿using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2.Commands;

public class MultiplyCommand : CalculatorCommand
{
    public MultiplyCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            // todo implement more informative message
            throw new GenerateCommandException();
        }
    }
    public override void Process(CalculatorExecutionContext context)
    {
        try
        {
            var first = context.Pop();
            var second = context.Pop();
            var result = first * second;
            context.Push(result);
        }
        catch 
        {
            // todo implement more informative message
            throw new ProcessCommandException();
        }
    }
}