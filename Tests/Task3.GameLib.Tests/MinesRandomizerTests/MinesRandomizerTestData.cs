using Tasks.Task3.GameLib;

namespace Task3.GameLib.Tests.MinesRandomizerTests;

sealed class MinesRandomizerTestData
{
    public static object[] FieldSettings =
        new object[]
        {
            new FieldInitialSettings(6, 6, 4),
            new FieldInitialSettings(2, 2, 1),
        };
    
    public static object[] FieldExceptions =
        new object[]
        {
            new FieldInitialSettings(6, 6, 0),
            new FieldInitialSettings(6, 6, 36),
        };
}