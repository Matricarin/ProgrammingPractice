using Common.TasksLibrary.Task1;

namespace Tasks.Task2;

internal static class Program
{
    private static void Main(string[] args)
    {
        var fileInfo = new FileInfo(args.First());
        ExecuteCommandsFromFile(fileInfo);
        ExecuteCommandsFromConsoleInput();
    }

    private static void ExecuteCommandsFromFile(FileInfo fileInfo)
    {
        try
        {
            var commands = FileHandler.OpenAndReadFile(fileInfo);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static void ExecuteCommandsFromConsoleInput()
    {
        var exitCode = -1;
        while (exitCode != 0)
        {
            var command = Console.ReadLine();
            
        }
        Environment.Exit(exitCode);
    }
}