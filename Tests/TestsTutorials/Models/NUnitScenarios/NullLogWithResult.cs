namespace TestsTutorials.Models.NUnitScenarios;

/// <summary>
/// Stub object for tests
/// </summary>
public sealed class NullLogWithResult : ILog
{
    private bool _expectedResult;

    public NullLogWithResult(bool expectedResult)
    {
        _expectedResult = expectedResult;
    }

    public bool Log(string message)
    {
        return _expectedResult;
    }
}