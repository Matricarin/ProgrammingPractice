namespace Common.TasksLibrary.Task2.Handlers;

public sealed class CommandParser
{
    public string Command { get; }
    public string Arguments { get; }

    public CommandParser(string command)
    {
        if (string.IsNullOrWhiteSpace(command))
        {
            throw new ArgumentException("Command cannot be empty.", nameof(command));
        }

        var spannedCommand = command.AsSpan();
        var whiteSpaceIndex = spannedCommand.IndexOf(' ');

        if (whiteSpaceIndex == -1)
        {
            Command = GetLineWithFirstUpperCharacter(spannedCommand);
            Arguments = string.Empty;
        }
        else
        {
            Command = GetLineWithFirstUpperCharacter(spannedCommand.Slice(0, whiteSpaceIndex));
            Arguments = spannedCommand.Slice(whiteSpaceIndex + 1).ToString();
        }
    }

    private string GetLineWithFirstUpperCharacter(ReadOnlySpan<char> input)
    {
        if (input.Length > 1)
        {
            return input.Slice(0, 1).ToString()
                   + input.Slice(1, input.Length - 1).ToString().ToLower();
        }

        return input.ToString();
    }
}