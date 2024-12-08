using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2.Output;

public class ConsoleOutput : IOutput
{
    public ConsoleOutput()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
    }
    
    public void Post(double data)
    {
        Console.Out.WriteLine($"Top stack item is {data}");
    }
}