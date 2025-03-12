using System.Diagnostics.Contracts;
using System.Reflection;
using Common.TasksLibrary.Extensions;
using Common.TasksLibrary.Task2.Attributes;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Commands;
using Common.TasksLibrary.Task2.Handlers;

namespace Common.TasksLibrary.Task2.Factories;

public sealed class CommandsFactory
{
    public ICalculatorCommand GenerateCommand(string executingCommand)
    {
        var commandParser = new CommandParser(executingCommand);

        var commandType = GetCommandType(commandParser);
        
        ArgumentNullException.ThrowIfNull(commandType);
        
        
            
            
            // .Select(t =>
            // t.CustomAttributes.Where(ca => ca.AttributeType.Name == nameof(CommandSignedAsAttribute)));
        // var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.Contains(commandParser.Command));
        //
        // //todo when does CreateInstance been return null? 
        // ArgumentNullException.ThrowIfNull(type);
        //
        // var instance = Activator.CreateInstance(type, commandParser.Arguments);
        //
        // ArgumentNullException.ThrowIfNull(instance);
        //
        // var command = instance as ICalculatorCommand;
        //
        // ArgumentNullException.ThrowIfNull(command);
        //
        // return command;
        return new AddCommand("");
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