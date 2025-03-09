using Moq;
using TestsTutorials.Models.MockScenarios;

namespace TestsTutorials;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class QuadraticTests
{
    [Test]
    public void Quadratic_Test()
    {
        var log = new Mock<ILogProvider>();
        var quadratic = new Quadratic(log.Object);
        var result = quadratic.Calculate(1, 4, 4);
        Assert.Multiple(() =>
        {
            Assert.That(result.Item1, Is.EqualTo(-2));
            Assert.That(result.Item2, Is.EqualTo(-2));
        });
    }
}