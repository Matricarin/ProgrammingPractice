using Microsoft.Extensions.Logging;

namespace Common.TasksLibrary.Task2.Base;

public interface ISpecifyLogger
{
    public ISpecifyOutput LogBy(ILogger logger);
}