using System.Diagnostics.CodeAnalysis;

namespace Common.TasksLibrary.Extensions;

public static class ObjectExtensions
{
    public static bool IsNull([NotNullWhen(false)] this object? obj) => obj is null;
}