﻿using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;

namespace Common.TasksLibrary.Task2.Commands;

public class PrintCommand : CalculatorCommand
{
    public PrintCommand(string parameters)
    {
        if (!string.IsNullOrEmpty(parameters))
        {
            throw new Exception("Print operation can't have command parameters");
        }
    }

    public override void Process(CalculatorExecutionContext context)
    {
        try
        {
            context.Print();
        }
        catch
        {
            throw new ProcessCommandException();
        }
    }
}