using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Extensions;

namespace Common.TasksLibrary.Task2.Base;

public sealed class CommandsFactory
{
    private static Dictionary<string, string> _commandMapper;

    public CommandsFactory(Dictionary<string, string> commands)
    {
        _commandMapper = commands;
    }

    public CalculatorCommand GenerateCommand(string executingCommand)
    {
        try
        {
            var stringCommand = executingCommand.SubStringBeforeFirstOne(StringConstants.WhiteSpace);
            var stringParameters = executingCommand.SubStringAfterFirstOne(StringConstants.WhiteSpace);
            var instance = Activator.CreateInstance(Type.GetType(_commandMapper[stringCommand]), stringParameters);
            var command = (CalculatorCommand)instance;
            return command;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}