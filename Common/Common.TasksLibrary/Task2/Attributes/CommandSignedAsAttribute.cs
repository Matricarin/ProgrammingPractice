namespace Common.TasksLibrary.Task2.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class CommandSignedAsAttribute : Attribute
{
    public string Sign { get; }
    public CommandSignedAsAttribute(string sign) => Sign = sign;
}