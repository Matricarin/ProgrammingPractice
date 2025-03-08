namespace TestsTutorials;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class MultipleAssertTest
{
    [Test]
    public void IsMultipleAssertTest()
    {
        var number = -50;
        
        Assert.Multiple(() =>
        {
            Assert.That(number, Is.EqualTo(-50));
            
            Assert.That(number, Is.LessThan(50));
        });
    }
}