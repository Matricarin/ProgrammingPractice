using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace Common.TasksLibrary.Extensions;

public static class JsonExtensions
{
    public static T? FromJsonString<T>(this string jsonString)
    {
        return JsonSerializer.Deserialize<T>(jsonString);
    }

    public static string ToJson<T>(this T item)
    {
        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin,
                UnicodeRanges.Cyrillic, UnicodeRanges.LetterlikeSymbols)
        };
        return JsonSerializer.Serialize<T>(item, options);
    }

    public static T? FromJsonFile<T>(this FileInfo file)
    {
        var jsonString = File.ReadAllText(file.FullName);
        return jsonString.FromJsonString<T>();
    }
}