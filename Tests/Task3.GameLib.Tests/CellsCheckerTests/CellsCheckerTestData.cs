using Tasks.Task3.GameLib;
using Tasks.Task3.GameLib.Cells;

namespace Task3.GameLib.Tests.CellsCheckerTests;

sealed class CellsCheckerTestData
{
    public static object[] AvailableCellsData = new[]
    {
        new object[]
        {
            new MineCell(4,5), 
            new FieldInitialSettings(5, 6, 1), 
            new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(4,4),
                new Tuple<int, int>(3,4),
                new Tuple<int, int>(3,5),
            }
        },
            new object[]
            {
            new MineCell(3,3), 
            new FieldInitialSettings(5, 6, 1), 
            new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(2,2),
                new Tuple<int, int>(2,3),
                new Tuple<int, int>(2,4),
                new Tuple<int, int>(3,2),
                new Tuple<int, int>(3,4),
                new Tuple<int, int>(4,2),
                new Tuple<int, int>(4,3),
                new Tuple<int, int>(4,4),
            }
        },
        new object[]
        {
            new MineCell(0,0), 
            new FieldInitialSettings(5, 6, 1), 
            new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(0,1),
                new Tuple<int, int>(1,0),
                new Tuple<int, int>(1,1),
            }
        }
    };
}