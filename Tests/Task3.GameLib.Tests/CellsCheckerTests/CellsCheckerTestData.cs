using Tasks.Task3.GameLib;
using Tasks.Task3.GameLib.Cells;

namespace Task3.GameLib.Tests.CellsCheckerTests;

internal sealed class CellsCheckerTestData
{
    public static object[] AvailableCellsData =
    {
        new object[]
        {
            new MineCell(4, 5),
            new FieldInitialSettings(5, 6, 1),
            new List<Tuple<int, int>>
            {
                new(4, 4),
                new(3, 4),
                new(3, 5)
            }
        },
        new object[]
        {
            new MineCell(3, 3),
            new FieldInitialSettings(5, 6, 1),
            new List<Tuple<int, int>>
            {
                new(2, 2),
                new(2, 3),
                new(2, 4),
                new(3, 2),
                new(3, 4),
                new(4, 2),
                new(4, 3),
                new(4, 4)
            }
        },
        new object[]
        {
            new MineCell(0, 0),
            new FieldInitialSettings(5, 6, 1),
            new List<Tuple<int, int>>
            {
                new(0, 1),
                new(1, 0),
                new(1, 1)
            }
        }
    };
}