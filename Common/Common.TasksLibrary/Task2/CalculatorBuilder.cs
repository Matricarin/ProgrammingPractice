using Common.TasksLibrary.Task2.Base;
using Common.TasksLibrary.Task2.Output;
using Microsoft.Extensions.Logging;

namespace Common.TasksLibrary.Task2;

public abstract class CalculatorBuilder
{
    public static ISpecifyLogger Create()
    {
        return new BuildHandler();
    }
    private class BuildHandler : ISpecifyOutput, ISpecifyLogger, ISpecifyStorage, IBuildCalculator
    {
        private Calculator calc = new Calculator();
        private IOutput _output;
        private BaseContainer _container;
        public ISpecifyStorage OutBy(CalculatorOutputOptions options)
        {
            _output = options switch
            {
                CalculatorOutputOptions.Console => new ConsoleOutput(),
                _ => throw new ArgumentException()
            };
            return this;
        }

        public ISpecifyOutput LogBy(ILogger logger)
        {
            calc.calcLogger = logger;
            return this;
        }

        public IBuildCalculator StoreBy(BaseContainer container)
        {
            _container = container;
            return this;
        }

        public Calculator Build()
        {
            calc.factory = new CommandsFactory();
            calc.executionContext = new CalculatorExecutionContext(_output, _container);
            return calc;
        }
    }
}