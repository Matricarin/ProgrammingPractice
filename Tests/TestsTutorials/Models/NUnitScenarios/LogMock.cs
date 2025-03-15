namespace TestsTutorials.Models.NUnitScenarios;

public sealed class LogMock :ILog
{
    private bool _expectedResult;
    public Dictionary<string, int> MethodCallCounts;

    public LogMock(bool expectedResult)
    {
        _expectedResult = expectedResult;
        MethodCallCounts = new Dictionary<string, int>();
    }
    public bool Log(string message)
    {
        if (!MethodCallCounts.TryAdd(nameof(Log), 1))
        {
            MethodCallCounts[nameof(Log)]++;
        }
        return _expectedResult;
    }
}