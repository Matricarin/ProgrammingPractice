using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace Common.TasksLibrary.Extensions;

public static class ObjectExtensions
{
    [Pure]
    public static bool IsNull([NotNullWhen(false)] this object? obj) => obj is null;
}