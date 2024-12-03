using Common.TasksLibrary.Extensions;

namespace PracticeTests.ExtensionsTests;

[TestFixture]
public class StringExtensionsTest
{
    [TestCase("SubStringBeforeTo", "Before", "SubString")]
    [TestCase("SubStringBeforeToBeforeTo", "Before", "SubString")]
    [TestCase("SubStringBeforeTo", "Sub", "")]
    [TestCase("SubStringBeforeTo", "", "")]
    public void Test_SubStringBeforeTo(string source, string separator, string expected)
    {
        Assert.That(source.SubStringBeforeFirstOne(separator), Is.EqualTo(expected));
    }
    [TestCase("SubStringAfterThat", "After", "That")]
    [TestCase("SubStringAfterThatAfterThat", "After", "ThatAfterThat")]
    [TestCase("SubStringAfterThat", "That", "")]
    [TestCase("SubStringAfterThat", "", "")]
    public void Test_SubStringAfterThat(string source, string separator, string expected)
    {
        Assert.That(source.SubStringAfterFirstOne(separator), Is.EqualTo(expected));
    }
}