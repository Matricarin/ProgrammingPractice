using System.Diagnostics.Contracts;
using System.Reflection;
using Common.TasksLibrary.Extensions;
using Common.TasksLibrary.Task2.Attributes;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Handlers;

namespace Common.TasksLibrary.Task2.Factories;

public sealed class CommandsFactory
{
    public ICalculatorCommand GenerateCommand(string executingCommand)
    {
        var commandParser = new CommandParser(executingCommand);

        var commandType = GetCommandType(commandParser);
        
        ArgumentNullException.ThrowIfNull(commandType);

        var instance = Activator.CreateInstance(commandType, commandParser.Arguments);
        
        ArgumentNullException.ThrowIfNull(instance);
        
        var command = (ICalculatorCommand)instance;
        
        ArgumentNullException.ThrowIfNull(command);
        
        return command;
    }

    [Pure]
    private Type? GetCommandType(CommandParser parser)
    {
        var definedTypes = Assembly.GetExecutingAssembly().DefinedTypes;
        
        foreach (var typeInfo in definedTypes)
        {
            var attribute = typeInfo.GetCustomAttribute<CommandSignedAsAttribute>();

            if (!attribute.IsNull())
            {
                if (attribute.Sign == parser.Command)
                {
                    return typeInfo.AsType();
                }
            }
        }
        
        return null;
    }
}