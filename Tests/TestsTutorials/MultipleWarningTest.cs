namespace TestsTutorials;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class MultipleWarningTest
{
    [Test]
    public void IsMultipleWarningTest()
    {
        Warn.If(4 != 5);
        Warn.If(4, Is.Not.EqualTo(5));
        Warn.If(() => 3 + 1, Is.Not.EqualTo(5).After(1000));
        
        Warn.Unless(4 == 5);
        Warn.Unless(4, Is.EqualTo(5));
        Warn.Unless(() => 3 + 1, Is.EqualTo(5).After(1000));
        
        Assert.Warn("I am warning you 7 times.");
    }
}