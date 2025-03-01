﻿using static Common.TasksLibrary.Constants.IntegersConstants;

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
        return index == -1 ? source : source.Substring(0, index);
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
        var str = source.ToLower();
        return char.ToUpper(str[0]) + str.Substring(1);
    }
}