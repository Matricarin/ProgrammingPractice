// using Common.TasksLibrary.Task2;
// using Common.TasksLibrary.Task2.Output;
//
// namespace PracticeTests.Task2Tests;
//
// [TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
// public sealed class CalculatorErrorsTests
// {
//     [Test]
//     public void Test_ExecutingCommandWithEmptyStackLogsProcessError()
//     {
//         var logger = new TestLogger();
//         var container = new CalculatorContainer();
//         var calculator = new Calculator(logger, new CommandsFactory(), 
//             new CalculatorExecutionContext(new ConsoleOutput(), container));
//
//         calculator.Execute("Add");
//
//         Assert.IsTrue(logger.LoggedMessages.Count > 0);
//         StringAssert.Contains("Stack is empty", logger.LoggedMessages[0]);
//     }
// }