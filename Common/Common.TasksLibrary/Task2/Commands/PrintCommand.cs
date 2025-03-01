﻿using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;

namespace Common.TasksLibrary.Task2.Commands;

public class PrintCommand : CalculatorCommand
{
    public PrintCommand(string parameters)
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
            var value = context.Peek();
            context.OutputPort.Post(value);
        }
        catch (ProcessCommandException pce)
        {
            throw new ProcessCommandException(pce.Message);
        }
        catch(ExecutionContextException ece)
        {
            throw new ProcessCommandException(ece.Message);
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}