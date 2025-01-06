using System.Globalization;

namespace Common.TasksLibrary.Task2.Base;

public interface IExecutionContext
{
    double Peek();
    double Pop();
    void Push(string variableName);
    void AddVariable();
}