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
        var parametrizedCommand = executingCommand.Split(' ');
        try
        {
            var instance = Activator.CreateInstance(Type.GetType(_commandMapper[parametrizedCommand.First()]));
            var command = (CalculatorCommand)instance;
            return command;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}