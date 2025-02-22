namespace Common.TasksLibrary.Task2.Exceptions;

public class ProcessCommandException : Exception
{
    public ProcessCommandException()
    {
    }

    public ProcessCommandException(string message)
        : base(message)
    {
    }

    public ProcessCommandException(string message, Exception inner)
        : base(message, inner)
    {
    }
}