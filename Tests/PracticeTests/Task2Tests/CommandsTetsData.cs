using Common.TasksLibrary.Task2;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Commands;
using Common.TasksLibrary.Task2.Output;

namespace PracticeTests.Task2Tests;

public static class CommandsTetsData
{
    public static Calculator GetCalculatorInstanceForCommandTest(string[] commands)
    {
        var calc = new CalculatorBuilder()
        {
            OutputOptions = CalculatorOutputOptions.Memory
        }.Build();
        calc.Execute(commands);
        return calc;
    }
    public static double GetTopStackValue(Calculator calc)
    {
        var memory = (MemoryOutput)calc.OutputPort;
        return memory.Value;
    }
    public static object[] PrintCommandTestInput = new object[]
    {
        new object[]
        {
            new[] { "Define a 5", "Push a" }, "Print", 5.0
        }
    };
    public static object[] AddCommandTestInput = new object[]
    {
        new object[]
        {
            new [] {"Define a 5", "Define b 6", "Push a", "Push b"}, "+", 11.0 
        }
    };
}
