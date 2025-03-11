namespace Common.TasksLibrary.Task2.Handlers;

sealed class CommandParser
{
    public string Command { get; }
    public string Arguments { get; }

    public CommandParser(string command)
    {
        if (!string.IsNullOrWhiteSpace(command))
        {
            throw new ArgumentException("Command cannot be empty.", nameof(command));
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
            spannedCommand.Slice(0, whiteSpaceIndex);
            Command = spannedCommand.ToString();

            spannedCommand.Slice(whiteSpaceIndex + 1);
            Arguments = spannedCommand.ToString();
        }
        
    }
}