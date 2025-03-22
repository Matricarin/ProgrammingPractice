using Tasks.Task3.GameLib;
using Tasks.Task3.GameLib.Cells;
using Tasks.Task3.GameLib.Handlers;

namespace Task3.GameLib.Tests.CellsCheckerTests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class CellsCheckerFixture
{
    private readonly CellsChecker _cellsChecker;

    public CellsCheckerFixture()
    {
        _cellsChecker = new CellsChecker();
    }
    
    [TestCaseSource(typeof(CellsCheckerTestData), nameof(CellsCheckerTestData.AvailableCellsData))]
    public void GetAvailableCellsTest(BaseCell cell, FieldInitialSettings setting, List<Tuple<int, int>> expectedCells)
    {
        var actualCells = _cellsChecker.GetAvailableCells(cell, setting).ToList();
        CollectionAssert.AreEqual(expectedCells, actualCells);
    }
    [Test]
    public void PutNumberInNullCellTest()
    {
        var cells = new BaseCell[1][];
        cells[0] = new BaseCell[1];
        
        var position = new Tuple<int, int>(0, 0);
        
        _cellsChecker.PutNumberInCell(cells, position);
        
        Assert.Multiple(() =>
        {
            Assert.IsInstanceOf<NumberCell>(cells[0][0]);
            var numberCell = (NumberCell)cells[0][0];
            Assert.That(numberCell.Number, Is.EqualTo(1));
        });
    }
    [Test]
    public void PutNumberInMineCellTest()
    {
        var cells = new BaseCell[1][];
        cells[0] = new BaseCell[1];
        cells[0][0] = new MineCell(0, 0);
        
        var position = new Tuple<int, int>(0, 0);
        
        _cellsChecker.PutNumberInCell(cells, position);
        
        Assert.IsInstanceOf<MineCell>(cells[0][0]);
    }
    [Test]
    public void PutNumberInNumberCellTest()
    {
        var cells = new BaseCell[1][];
        cells[0] = new BaseCell[1];
        cells[0][0] = new NumberCell(0, 0, 3);
        var position = new Tuple<int, int>(0, 0);
        
        _cellsChecker.PutNumberInCell(cells, position);
        
        Assert.Multiple(() =>
        {
            Assert.IsInstanceOf<NumberCell>(cells[0][0]);
            var numberCell = (NumberCell)cells[0][0];
            Assert.That(numberCell.Number, Is.EqualTo(4));
        });
    }
    [Test]
    public void PutNumberInEmptyCellTest()
    {
        var cells = new BaseCell[1][];
        cells[0] = new BaseCell[1];
        cells[0][0] = new EmptyCell(0, 0);
        
        var position = new Tuple<int, int>(0, 0);
        
        _cellsChecker.PutNumberInCell(cells, position);
        
        Assert.IsInstanceOf<EmptyCell>(cells[0][0]);
    }
}