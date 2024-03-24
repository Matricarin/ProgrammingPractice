namespace Common.TasksLibrary.Task1
{
    interface IAnalyzer<T>
    {
        IEnumerable<T> GetAnalyzeSourceTextResults(string text);
    }
}