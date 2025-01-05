﻿using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2.Commands;

public class SubtractCommand : CalculatorCommand
{
    public SubtractCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            throw new Exception("Subtract operation can't have command parameters");
        }
    }

    public SubtractCommand()
    {
        
    }
    public override void Process(Calculator calculator)
    {
        try
        {
            var first = calculator.StackStorage.Pop();
            var second = calculator.StackStorage.Pop();
            var result = first - second;
            calculator.StackStorage.Push(result);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}