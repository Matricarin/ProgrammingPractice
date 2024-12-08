using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Extensions;

namespace Common.TasksLibrary.Task2.Base;

public sealed class CommandsFactory
{
    private static CommandsList _commandsList;

    public CommandsFactory(CommandsList commands)
    {
        _commandsList = commands;
    }

    public CalculatorCommand GenerateCommand(string executingCommand)
    {
        try
        {
            var stringCommand = executingCommand.SubStringBeforeFirstOne(StringConstants.WhiteSpace);
            var stringParameters = executingCommand.SubStringAfterFirstOne(StringConstants.WhiteSpace);
            var instance = Activator.CreateInstance(
                Type.GetType(_commandsList.GetType().GetProperties().First(s => s.Name == stringCommand)
                    .GetValue(_commandsList).ToString()), stringParameters);
            var command = (CalculatorCommand)instance;
            return command;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}