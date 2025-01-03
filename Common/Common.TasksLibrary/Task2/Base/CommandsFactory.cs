using System.Reflection;
using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Extensions;

namespace Common.TasksLibrary.Task2.Base;

public sealed class CommandsFactory
{
    public CalculatorCommand GenerateCommand(string executingCommand)
    {
        try
        {
            var stringCommand = executingCommand.SubStringBeforeFirstOne(StringConstants.WhiteSpace);
            var stringParameters = executingCommand.SubStringAfterFirstOne(StringConstants.WhiteSpace);
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.Contains(stringCommand));
            var instance = Activator.CreateInstance(type, stringParameters);
            var command = (CalculatorCommand)instance;
            return command;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}