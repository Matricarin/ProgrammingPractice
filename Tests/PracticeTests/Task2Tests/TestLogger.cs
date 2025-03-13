using Common.TasksLibrary.Extensions;
using Microsoft.Extensions.Logging;

namespace PracticeTests.Task2Tests;

public sealed class TestLogger : ILogger
{
    public List<string> LoggedMessages { get; } = new List<string>();

    public IDisposable BeginScope<TState>(TState state) where TState : notnull
    {
        return NullScope.Instance;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception, string> formatter)
    {
        if(!exception.IsNull())
        {
            LoggedMessages.Add(formatter(state, exception));
        }
    }

    public bool IsEnabled(LogLevel logLevel) => true;

    private class NullScope : IDisposable
    {
        public static NullScope Instance { get; } = new NullScope();
        public void Dispose() { }
    }
}