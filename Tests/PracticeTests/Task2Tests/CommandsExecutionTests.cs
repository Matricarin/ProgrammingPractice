﻿using Common.TasksLibrary.Constants;
using Common.TasksLibrary.Task2;
using Common.TasksLibrary.Task2.Commands;
using Common.TasksLibrary.Task2.Output;

namespace PracticeTests.Task2Tests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class CommandsExecutionTests
{
    private MockContainer _container;
    private CalculatorExecutionContext _context;
    private const double FirstNumber = 10.1;
    private const double SecondNumber = 20.2;
    private const double AdditionResult = 30.3;
    private const double SubtractionResult = 10.1;
    private const double MultiplicationResult = 204.02;
    private const double DivisionResult = 2.0;
    private const double SqrtResult = 3.17804971641414;

    [Test]
    public void Test_AddCommandExecution()
    {
        _container = new MockContainer();
        _context = new CalculatorExecutionContext(new ConsoleOutput(), _container);
        _context.Push(FirstNumber);
        _context.Push(SecondNumber);

        var command = new AddCommand(string.Empty);
        command.Process(_context);
        var result = _context.Pop();

        Assert.That(Math.Abs(result - AdditionResult), Is.LessThan(DoublesConstants.Tolerance));
    }

    [Test]
    public void Test_SubtractCommandExecution()
    {
        _container = new MockContainer();
        _context = new CalculatorExecutionContext(new ConsoleOutput(), _container);
        _context.Push(FirstNumber);
        _context.Push(SecondNumber);

        var command = new SubtractCommand(string.Empty);
        command.Process(_context);
        var result = _context.Pop();

        Assert.That(Math.Abs(result - SubtractionResult), Is.LessThan(DoublesConstants.Tolerance));
    }

    [Test]
    public void Test_MultiplyCommandExecution()
    {
        _container = new MockContainer();
        _context = new CalculatorExecutionContext(new ConsoleOutput(), _container);
        _context.Push(FirstNumber);
        _context.Push(SecondNumber);

        var command = new MultiplyCommand(string.Empty);
        command.Process(_context);
        var result = _context.Pop();

        Assert.That(Math.Abs(result - MultiplicationResult), Is.LessThan(DoublesConstants.Tolerance));
    }
    
    [Test]
    public void Test_DivideCommandExecution()
    {
        _container = new MockContainer();
        _context = new CalculatorExecutionContext(new ConsoleOutput(), _container);
        _context.Push(FirstNumber);
        _context.Push(SecondNumber);

        var command = new DivideCommand(string.Empty);
        command.Process(_context);
        var result = _context.Pop();

        Assert.That(Math.Abs(result - DivisionResult), Is.LessThan(DoublesConstants.Tolerance));
    }
    
    [Test]
    public void Test_SqrtCommandExecution()
    {
        _container = new MockContainer();
        _context = new CalculatorExecutionContext(new ConsoleOutput(), _container);
        _context.Push(FirstNumber);

        var command = new SqrtCommand(string.Empty);
        command.Process(_context);
        var result = _context.Pop();

        Assert.That(Math.Abs(result - SqrtResult), Is.LessThan(DoublesConstants.Tolerance));
    }
}