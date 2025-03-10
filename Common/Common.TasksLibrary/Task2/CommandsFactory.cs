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
        
        if (type.IsNull())
        {
            //todo when does CreateInstance been return null? 
            throw new NullReferenceException();
        }

        var instance = Activator.CreateInstance(type, stringParameters);
        
        var command = instance as ICalculatorCommand;
        
        if (command.IsNull())
        {
            throw new NullReferenceException();
        }

        return command;
    }
}