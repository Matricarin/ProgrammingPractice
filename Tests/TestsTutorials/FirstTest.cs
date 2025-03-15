namespace TestsTutorials;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class FirstTest
{
    [Test]
    public void FirstTestReturnTrue()
    {
        Assert.True(true);
    }
}