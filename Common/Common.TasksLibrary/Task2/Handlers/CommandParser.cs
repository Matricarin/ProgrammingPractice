namespace Common.TasksLibrary.Task2.Handlers;

public sealed class CommandParser
{
    public string Command { get; }
    public string Arguments { get; }

    public CommandParser(string command)
    {
        if (string.IsNullOrWhiteSpace(command))
        {
            throw new ArgumentException(StringResources.Exception_Command_cannot_be_empty, nameof(command));
        }

        var spannedCommand = command.AsSpan();
        var whiteSpaceIndex = spannedCommand.IndexOf(' ');

        if (whiteSpaceIndex == -1)
        {
            Command = spannedCommand.ToString();
            Arguments = string.Empty;
        }
        else
        {
            Command = spannedCommand.Slice(0, whiteSpaceIndex).ToString();
            Arguments = spannedCommand.Slice(whiteSpaceIndex + 1).ToString();
        }
    }
}