namespace TestsTutorials.Models.NUnitScenarios;

public sealed class ConsoleLog : ILog
{
    public bool Log(string message)
    {
        Console.WriteLine(message);
        return true;
    }
}