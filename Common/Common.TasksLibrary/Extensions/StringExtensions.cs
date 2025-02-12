using static Common.TasksLibrary.Constants.IntegersConstants;

namespace Common.TasksLibrary.Extensions;

public static class StringExtensions
{
    public static string SubStringBeforeFirstOne(this string source, string separator)
    {
        if (string.IsNullOrEmpty(separator))
        {
            return string.Empty;
        }
        var index = source.IndexOf(separator, StringComparison.Ordinal);
        return index == -1 ? source : source.Substring(Zero, index);
    }

    public static string SubStringAfterFirstOne(this string source, string separator)
    {
        if (string.IsNullOrEmpty(separator))
        {
            return string.Empty;
        }
        var index = source.IndexOf(separator, StringComparison.Ordinal);
        return index == -1 ? string.Empty : source.Substring(index + separator.Length);
    }

    public static string ParseCommand(this string source)
    {
        var command = source.LineWithFirstUpperCharacter();
        return command switch
        {
            "#" => "Comment",
            "+" => "Add",
            "-" => "Subtract",
            "*" => "Multiply",
            "/" => "Divide",
            _ => command
        };
    }
    
    public static string LineWithFirstUpperCharacter(this string source)
    {
        if (string.IsNullOrEmpty(source))
        {
            return string.Empty;
        }
        return char.ToUpper(source[Zero]) + source.Substring(1);
    }
}