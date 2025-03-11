using System.Reflection;
using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Extensions;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Handlers;

namespace Common.TasksLibrary.Task2.Factories;

public sealed class CommandsFactory
{
    public ICalculatorCommand GenerateCommand(string executingCommand)
    {
        var commandParser = new CommandParser(executingCommand);
        
        var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.Contains(commandParser.Command));
        
        //todo when does CreateInstance been return null? 
        ArgumentNullException.ThrowIfNull(type);
        
        var instance = Activator.CreateInstance(type, commandParser.Arguments);
        
        ArgumentNullException.ThrowIfNull(instance);

        var command = instance as ICalculatorCommand;
        
        ArgumentNullException.ThrowIfNull(command);

        return command;
    }
}