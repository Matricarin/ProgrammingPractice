namespace TestsTutorials.Models.MockScenarios;

public class LogProvider : ILogProvider
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}