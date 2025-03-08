namespace TestsTutorials;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class SimpleTests
{
    [Test]
    public void TwoPlusTwoEqualsFour()
    {
        var twoPlusTwo = 2 + 2;
        Assert.That(twoPlusTwo, Is.EqualTo(4));
    }

    [Test]
    public void IsFailedTest()
    {
        Assert.Fail("Should be failed");
    }
}