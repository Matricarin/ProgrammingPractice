namespace TestsTutorials;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class TestCasesScenarios
{
    [Test]
    [TestCase(-1, -2, -3)]
    [TestCase(0, 1, 1)]
    [TestCase(1, 1, 2)]
    public void AddTwoPositiveNumbers(int a, int b, int expected)
    {
        var result = a + b;
        Assert.Multiple(() =>
        {
            Warn.If(a, Is.Negative);
            
            Warn.If(b, Is.Negative);
            
            Assert.That(result, Is.EqualTo(expected));
        });
    }
}