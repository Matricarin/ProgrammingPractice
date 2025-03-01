using System.Diagnostics.CodeAnalysis;
using Common.TasksLibrary.Extensions;

namespace PracticeTests.ExtensionsTests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class JsonExtensionsTest
{
    [TestCaseSource(typeof(JsonTestData), nameof(JsonTestData.FromStringTestData))]
    public void FromJsonString(string jsonText, UserTest expected)
    {
        var obj = jsonText.FromJsonString<UserTest>();
        Assert.That(obj, Is.EqualTo(expected));
    }

    [TestCaseSource(typeof(JsonTestData), nameof(JsonTestData.ToJsonData))]
    public void ToJson(UserTest obj, string expected)
    {
        var result = obj.ToJson();
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void FromJsonFile()
    {
        var info = new FileInfo(Path.Combine(Environment.CurrentDirectory, "TestingData",
            "JsonExtensionTest_UserTest.json"));
        var result = info.FromJsonFile<UserTest>();
        var expected = new UserTest() { Name = "Alex", Age = 40 };
        Assert.That(result, Is.EqualTo(expected));
    }
}

public static class JsonTestData
{
    public static object[] FromStringTestData = new object[]
    {
        new object[]{"{\"Name\":\"Ivan\", \"Age\":28}", new UserTest(){Name = "Ivan", Age = 28}}
    };

    public static object[] ToJsonData = new object[]
    {
        new object[]{new UserTest(){Name = "Dima", Age = 45}, "{\"Name\":\"Dima\",\"Age\":45}"}
    };
}

public sealed class UserTest
{
    public required string Name { get; init; }
    public int Age { get; init; }
    
    public override bool Equals(object? obj)
    {
        var other = obj as UserTest;
        
        if (other.IsNull())
        {
            return false;
        }
        
        return this.Name == other.Name && this.Age == other.Age;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Age);
    }
}