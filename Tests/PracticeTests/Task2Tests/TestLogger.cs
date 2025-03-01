using Microsoft.Extensions.Logging;

namespace PracticeTests.Task2Tests;

public sealed class TestLogger : ILogger
{
    public List<string> LoggedMessages { get; } = new List<string>();

    public IDisposable BeginScope<TState>(TState state) => NullScope.Instance;

    public bool IsEnabled(LogLevel logLevel) => true;

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        LoggedMessages.Add(formatter(state, exception));
    }

    private class NullScope : IDisposable
    {
        public static NullScope Instance { get; } = new NullScope();
        public void Dispose() { }
    }
}