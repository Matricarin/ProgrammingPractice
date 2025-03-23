using Tasks.Task3.GameLib.Cells;
using Tasks.Task3.GameLib.Exceptions;

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
        if (settings.MinesAmount == 0)
        {
            throw new GenerateMinesException("Mines amount cannot be 0.");
        }

        if (settings.MinesAmount > settings.Columns * settings.Rows * 0.5)
        {
            throw new GenerateMinesException("Mines amount cannot be greater than " + (settings.Columns * settings.Rows * 0.5) + ".");
        }
        
        var randomRows = new Random(_rowsSeed);
        var randomColumns = new Random(_columnsSeed);
        
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