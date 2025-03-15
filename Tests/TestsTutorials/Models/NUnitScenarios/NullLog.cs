namespace TestsTutorials.Models.NUnitScenarios;

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