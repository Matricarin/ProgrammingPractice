using Common.TasksLibrary.Extensions;

namespace PracticeTests.ExtensionsTests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class ObjectExtensionsTests
{
    [Test]
    public void IsNullShouldReturnTrue()
    {
        object? obj = null;
        Assert.True(obj.IsNull());
    }
    [Test]
    public void IsNullShouldReturnFalse()
    {
        var obj = new object();
        Assert.False(obj.IsNull());
    }
}