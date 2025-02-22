namespace Common.TasksLibrary.Task2.Exceptions;

public class ExecutionContextException : Exception
{
    public ExecutionContextException()
    {
    }

    public ExecutionContextException(string message)
        : base(message)
    {
    }

    public ExecutionContextException(string message, Exception inner)
        : base(message, inner)
    {
    }
}