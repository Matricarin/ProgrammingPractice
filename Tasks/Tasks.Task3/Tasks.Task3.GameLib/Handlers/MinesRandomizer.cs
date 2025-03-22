using Tasks.Task3.GameLib.Cells;

namespace Tasks.Task3.GameLib.Handlers;

public sealed class MinesRandomizer
{
    private readonly int _rowsSeed;
    private readonly int _columnsSeed;

    public MinesRandomizer(int rowsSeed, int columnsSeed)
    {
        _rowsSeed = rowsSeed;
        _columnsSeed = columnsSeed;
    }
    
    public HashSet<BaseCell> GenerateRandomMines(FieldInitialSettings settings)
    {
        var randomRows = new Random(45);
        var randomColumns = new Random(180);
        var cellsHash = new HashSet<BaseCell>();
        cellsHash.Clear();
        while (cellsHash.Count < settings.MinesAmount)
        {
            var row = randomRows.Next(0, settings.Rows - 1);
            var column = randomColumns.Next(0, settings.Columns - 1);
            
            cellsHash.Add(new MineCell(row, column));
        }
        return cellsHash;
    }
}