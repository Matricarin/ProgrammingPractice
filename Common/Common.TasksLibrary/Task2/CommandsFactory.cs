using System.Reflection;
using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Extensions;
using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2;

public sealed class CommandsFactory
{
    public ICalculatorCommand GenerateCommand(string executingCommand)
    {
        //todo remade command parsing

        var stringCommand = executingCommand.SubStringBeforeFirstOne(StringConstants.WhiteSpace).ParseCommand();
        var stringParameters = executingCommand.SubStringAfterFirstOne(StringConstants.WhiteSpace);

        var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.Contains(stringCommand));
        
        //todo when does CreateInstance been return null? 
        ArgumentNullException.ThrowIfNull(type);
        
        var instance = Activator.CreateInstance(type, stringParameters);
        
        ArgumentNullException.ThrowIfNull(instance);

        var command = instance as ICalculatorCommand;
        
        ArgumentNullException.ThrowIfNull(command);

        return command;
    }
}