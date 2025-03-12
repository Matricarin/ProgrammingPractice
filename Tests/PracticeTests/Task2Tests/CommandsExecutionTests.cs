// using Common.TasksLibrary.Constants;
// using Common.TasksLibrary.Task2;
// using Common.TasksLibrary.Task2.Commands;
// using Common.TasksLibrary.Task2.Handlers;
// using Common.TasksLibrary.Task2.Output;
//
// namespace PracticeTests.Task2Tests;
//
// [TestFixture]
// [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
// public sealed class CommandsExecutionTests
// {
//     private const double FirstNumber = 10.1;
//     private const double SecondNumber = 20.2;
//     private const double AdditionResult = 30.3;
//     private const double SubtractionResult = 10.1;
//     private const double MultiplicationResult = 204.02;
//     private const double DivisionResult = 2.0;
//     private const double SqrtResult = 3.17804971641414;
//
//     [Test]
//     public void AddCommandExecution()
//     {
//         var container = new MockContainer();
//         var context = new CalculatorExecutionContext(new ConsoleOutput(), container);
//         context.Push(FirstNumber);
//         context.Push(SecondNumber);
//
//         var command = new AddCommand(string.Empty);
//         command.Process(context);
//         var result = context.Pop();
//
//         Assert.That(Math.Abs(result - AdditionResult), Is.LessThan(DoublesConstants.Tolerance));
//     }
//
//     [Test]
//     public void SubtractCommandExecution()
//     {
//         var container = new MockContainer();
//         var context = new CalculatorExecutionContext(new ConsoleOutput(), container);
//         context.Push(FirstNumber);
//         context.Push(SecondNumber);
//
//         var command = new SubtractCommand(string.Empty);
//         command.Process(context);
//         var result = context.Pop();
//
//         Assert.That(Math.Abs(result - SubtractionResult), Is.LessThan(DoublesConstants.Tolerance));
//     }
//
//     [Test]
//     public void MultiplyCommandExecution()
//     {
//         var container = new MockContainer();
//         var context = new CalculatorExecutionContext(new ConsoleOutput(), container);
//         context.Push(FirstNumber);
//         context.Push(SecondNumber);
//
//         var command = new MultiplyCommand(string.Empty);
//         command.Process(context);
//         var result = context.Pop();
//
//         Assert.That(Math.Abs(result - MultiplicationResult), Is.LessThan(DoublesConstants.Tolerance));
//     }
//
//     [Test]
//     public void DivideCommandExecution()
//     {
//         var container = new MockContainer();
//         var context = new CalculatorExecutionContext(new ConsoleOutput(), container);
//         context.Push(FirstNumber);
//         context.Push(SecondNumber);
//
//         var command = new DivideCommand(string.Empty);
//         command.Process(context);
//         var result = context.Pop();
//
//         Assert.That(Math.Abs(result - DivisionResult), Is.LessThan(DoublesConstants.Tolerance));
//     }
//
//     [Test]
//     public void SqrtCommandExecution()
//     {
//         var container = new MockContainer();
//         var context = new CalculatorExecutionContext(new ConsoleOutput(), container);
//         context.Push(FirstNumber);
//
//         var command = new SqrtCommand(string.Empty);
//         command.Process(context);
//         var result = context.Pop();
//
//         Assert.That(Math.Abs(result - SqrtResult), Is.LessThan(DoublesConstants.Tolerance));
//     }
// }