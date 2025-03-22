using Tasks.Task3.GameLib.Cells;

namespace Tasks.Task3.GameLib.Handlers;

public sealed class CellsChecker
{
    public IEnumerable<Tuple<int, int>> GetAvailableCells(BaseCell cell, FieldInitialSettings fieldSettings)
    {
        var startX = cell.X - 1;
        var startY = cell.Y - 1;
        
        var endX = cell.X + 1;
        var endY = cell.Y + 1;

        for (int row = startY; row <= endY; row++)
        {
            for (int column = startX; column <= endX; column++)
            {
                if (row < fieldSettings.Rows && row >= 0 && column < fieldSettings.Columns && column >= 0)
                {
                    yield return new Tuple<int, int>(row, column);
                }
            }
        }
    }

    public void PutNumberInCell(BaseCell[][] cells, Tuple<int, int> cellPosition)
    {
        if (cells is null)
        {
            throw new ArgumentNullException(nameof(cells));
        }

        if (cellPosition is null)
        {
            throw new ArgumentNullException(nameof(cellPosition));
        }
        
        var x = cellPosition.Item1;
        var y = cellPosition.Item2;

        if (cells[x][y] is null)
        {
            cells[x][y] = new NumberCell(x, y, 1);
            return;
        }

        if (cells[x][y] is NumberCell numberCell)
        {
            var newNumber = numberCell.Number + 1;
            cells[x][y] = new NumberCell(x, y, newNumber);
        }
    }
}