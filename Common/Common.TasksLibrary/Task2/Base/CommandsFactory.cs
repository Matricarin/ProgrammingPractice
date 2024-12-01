using Common.TasksLibrary.Task2.Commands;

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
            var instance = Activator.CreateInstance(null, 
                _commandMapper[executingCommand]);
            var command = (DefineCommand)instance.Unwrap();
            return command;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}