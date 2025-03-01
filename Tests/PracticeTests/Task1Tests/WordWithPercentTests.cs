using Common.TasksLibrary.Task1;

namespace PracticeTests.Task1Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class WordWithPercentTests
{
    [Test]
    public void EqualsShouldReturnTrue()
    {
        var firstWord = new WordWithPercent("first", 0.03);
        var otherFirstWord = new WordWithPercent("first", 0.03);
        
        Assert.That(firstWord, Is.EqualTo(otherFirstWord));
    }
    
    [Test]
    public void EqualsShouldReturnFalse_FrequencyVaries()
    {
        var firstWord = new WordWithPercent("first", 0.03);
        var otherFirstWord = new WordWithPercent("first", 0.04);
        
        Assert.That(firstWord, Is.Not.EqualTo(otherFirstWord));
    }
    
    [Test]
    public void EqualsShouldReturnFalse_WordVaries()
    {
        var firstWord = new WordWithPercent("first", 0.03);
        var secondWord = new WordWithPercent("second", 0.03);
        
        Assert.That(firstWord, Is.Not.EqualTo(secondWord));
    }
    
    [Test]
    public void EqualsShouldReturnFalse_ObjectVaries()
    {
        var firstWord = new WordWithPercent("first", 0.03);
        var str = "first";
        
        Assert.False(firstWord.Equals(str));
    }
}