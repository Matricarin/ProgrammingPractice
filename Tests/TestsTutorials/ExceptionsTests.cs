namespace TestsTutorials;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class ExceptionsTests
{
    [Test]
    public void IndexWasOutsideOfArray()
    {
        var array = new bool[4];
        
        var ex = Assert.Throws<IndexOutOfRangeException>(() => array[10] = true);
        StringAssert.StartsWith("Index", ex.Message);
    }
}