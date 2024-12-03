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
        return source.Substring(Zero, index);
    }

    public static string SubStringAfterFirstOne(this string source, string separator)
    {
        if (string.IsNullOrEmpty(separator))
        {
            return string.Empty;
        }
        var index = source.IndexOf(separator, StringComparison.Ordinal);
        return source.Substring(index + separator.Length);
    }
}