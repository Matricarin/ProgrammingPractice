using System.Diagnostics;
using System.Reflection;
using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Extensions;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Exceptions;

namespace Common.TasksLibrary.Task2;

public sealed class CommandsFactory
{
    public ICalculatorCommand? GenerateCommand(string executingCommand)
    {
        try
        {
            var stringCommand = executingCommand.SubStringBeforeFirstOne(StringConstants.WhiteSpace).ParseCommand();
            var stringParameters = executingCommand.SubStringAfterFirstOne(StringConstants.WhiteSpace);
            var type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name.Contains(stringCommand));
            var instance = Activator.CreateInstance(type ?? throw new GenerateCommandException("Cant find a command"),
                stringParameters);
            var command = (ICalculatorCommand)instance!;
            return command;
        }
        catch (GenerateCommandException gce)
        {
            throw new GenerateCommandException(gce.Message);
        }
    }
}