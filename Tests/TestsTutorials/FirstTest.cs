namespace TestsTutorials;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class FirstTest
{
    [Test]
    public void FirstTestReturnTrue()
    {
        Assert.True(true);
    }
}