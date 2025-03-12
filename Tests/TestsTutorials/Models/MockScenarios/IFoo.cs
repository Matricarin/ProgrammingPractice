namespace TestsTutorials.Models.MockScenarios;

public interface IFoo
{
    bool IsCorrectString(string str);
    bool IsCorrectInt(int i);
    bool TryParseInt(string str, out int i);
    bool Submit(ref Goo goo);
}