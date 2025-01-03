using System.Reflection;
using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Extensions;
using Common.TasksLibrary.Task2.Commands;

namespace Common.TasksLibrary.Task2.Base;

public sealed class CommandsFactory
{
    public CalculatorCommand GenerateCommand(string executingCommand)
    {
        try
        {
            var stringCommand = executingCommand.SubStringBeforeFirstOne(StringConstants.WhiteSpace);
            var stringParameters = executingCommand.SubStringAfterFirstOne(StringConstants.WhiteSpace);
            
            var instance = Activator.CreateInstance(Type.GetType(stringCommand), stringParameters);
            
            var command = (CalculatorCommand)instance;
            return command;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}