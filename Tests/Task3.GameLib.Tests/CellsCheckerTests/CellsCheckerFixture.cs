using Tasks.Task3.GameLib;
using Tasks.Task3.GameLib.Cells;
using Tasks.Task3.GameLib.Handlers;

namespace Task3.GameLib.Tests.CellsCheckerTests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class CellsCheckerFixture
{
    [TestCaseSource(typeof(CellsCheckerTestData), nameof(CellsCheckerTestData.AvailableCellsData))]
    public void GetAvailableCellsTest(BaseCell cell, FieldInitialSettings setting, List<Tuple<int, int>> expectedCells)
    {
        var checker = new CellsChecker();
        var actualCells = checker.GetAvailableCells(cell, setting).ToList();
        CollectionAssert.AreEqual(expectedCells, actualCells);
    }
}