namespace Common.TasksLibrary.Task2.Exceptions;

public class GenerateCommandException : Exception
{
    public GenerateCommandException()
    {
    }

    public GenerateCommandException(string message)
        : base(message)
    {
    }

    public GenerateCommandException(string message, Exception inner)
        : base(message, inner)
    {
    }
}