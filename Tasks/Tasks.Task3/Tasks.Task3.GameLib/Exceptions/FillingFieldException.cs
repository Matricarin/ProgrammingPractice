namespace Tasks.Task3.GameLib.Exceptions;

sealed class FillingFieldException : Exception
{
    public FillingFieldException()
    {
    }

    public FillingFieldException(string message)
        : base(message)
    {
    }

    public FillingFieldException(string message, Exception inner)
        : base(message, inner)
    {
    }
}