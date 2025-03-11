﻿using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Handlers;

namespace Common.TasksLibrary.Task2.Commands;

public class CommentCommand : ICalculatorCommand
{
    private string? _comment;
    
    public CommentCommand(string? parameters)
    {
        _comment = parameters;
    }

    public bool Process(CalculatorExecutionContext context) => true;
}