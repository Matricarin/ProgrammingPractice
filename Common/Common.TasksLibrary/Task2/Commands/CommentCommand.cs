using Common.TasksLibrary.Task2.Base;

namespace Common.TasksLibrary.Task2.Commands;

public class CommentCommand : CalculatorCommand
{
    private string _comment;
    public CommentCommand(string parameters)
    {
        var values = parameters.Split(CharsConstants.WhiteSpace);
        if (values.Length != 2)
        {
            throw new Exception("Unexpected amount of parameters for command");
        }

        _variableName = values.First();
        if (!double.TryParse(values.Last(), out _variableValue))
        {
            throw new Exception("Unexpected value for command parameter");
        }
    }
    public override void Process(Calculator calculator)
    {
        throw new NotImplementedException();
    }
}