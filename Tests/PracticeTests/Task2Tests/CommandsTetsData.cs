using Common.TasksLibrary.Task2;
using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Commands;

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

    public static object[] PrintCommandTestInput = new object[]
    {
        new object[]
        {
            new[]
            {
                "Define a 5",
                "Push a"
            },
            "Print", 
            5.0
        }
    };
    
    
}