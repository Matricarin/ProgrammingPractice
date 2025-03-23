namespace Tasks.Task3.GameLib.Exceptions;

public sealed class GenerateMinesException : Exception
{
    public GenerateMinesException()
    {
    }

    public GenerateMinesException(string message)
        : base(message)
    {
    }

    public GenerateMinesException(string message, Exception inner)
        : base(message, inner)
    {
    }
}