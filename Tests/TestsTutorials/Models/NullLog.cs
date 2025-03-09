namespace TestsTutorials.Models;

/// <summary>
/// Fake object for tests
/// </summary>
public sealed class NullLog : ILog
{
    public bool Log(string message)
    {
        return true;
    }
}