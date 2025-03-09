namespace TestsTutorials.Models;

public sealed class ConsoleLog : ILog
{
    public bool Log(string message)
    {
        Console.WriteLine(message);
        return true;
    }
}