using Moq;
using TestsTutorials.Models.MockScenarios;

namespace TestsTutorials;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class SyntheticMockTests
{
    [Test]
    public void CorrectStringTest()
    {
        var foo = new Mock<IFoo>();
        foo.Setup(f => f.IsCorrectString("moq")).Returns(true);
        foo.Setup(f => f.IsCorrectString(It.IsIn("foo", "crap"))).Returns(false);
        
        Assert.Multiple(() =>
        {
            Assert.IsTrue(foo.Object.IsCorrectString("moq"));
            Assert.IsFalse(foo.Object.IsCorrectString("crap"));
        });
    }

    [Test]
    public void CorrectIntTest()
    {
        var foo =  new Mock<IFoo>();
        foo.Setup(f => f.IsCorrectInt(It.Is<int>(x => x  % 5 == 0))).Returns(true);
        
        Assert.IsTrue(foo.Object.IsCorrectInt(55));
    }
}