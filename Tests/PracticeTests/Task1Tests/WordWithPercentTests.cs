using Common.TasksLibrary.Task1;

namespace PracticeTests.Task1Tests;

[TestFixture, FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class WordWithPercentTests
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
    public void EqualsShouldReturnTrue_DoubleCheck()
    {
        const double firstFrequency = 0.03;
        const double secondFrequency = 0.03 * 0.01 / 0.01;
        var firstWord = new WordWithPercent("first", firstFrequency);
        var firstWordWithAlmostSameFrequency = new WordWithPercent("first", secondFrequency);
        
        Assert.That(firstWord, Is.EqualTo(firstWordWithAlmostSameFrequency));
    }

    [Test]
    public void CheckHashCodesForWordsWithPercent()
    {
        var firstWord = new WordWithPercent("first", 0.03);
        var almostFirstWord = new WordWithPercent("first", 0.03);
        
        var firstHash = firstWord.GetHashCode();
        var almostFirstHash = almostFirstWord.GetHashCode();
        Assert.That(firstHash, Is.EqualTo(almostFirstHash));
    }
}