using Tasks.Task3.GameLib.Cells;
using Tasks.Task3.GameLib.Exceptions;
using Tasks.Task3.GameLib.Handlers;

namespace Tasks.Task3.GameLib.Services;

public sealed class CellsGenerateService 
{
    private readonly MinesRandomizer _randomizer;
    private readonly CellsChecker _cellsChecker;

    public CellsGenerateService()
    {
        _randomizer = new MinesRandomizer(45, 180);
        _cellsChecker = new CellsChecker();
    }

    public IEnumerable<BaseCell> GenerateMines(BaseCell[][] cells, FieldInitialSettings settings)
    {
        if (!CanGenerate(cells, settings))
        {
            throw new FillingFieldException("Field parameters are not valid.");
        }
        
        var mines = _randomizer.GenerateRandomMines(settings);

        for (var i = 0; i < cells.Length; i++)
        {
            for (var j = 0; j < cells[i].Length; j++)
            {
                var mine = mines.FirstOrDefault(m => m.X == i && m.Y == j);
                
                if (mine is not null)
                {
                    cells[i][j] = mine;
                }
            }
        }
        
        return mines;
    }

    public void GenerateNumbers(BaseCell[][] cells, BaseCell[] mines, FieldInitialSettings settings)
    {
        if (!CanGenerate(cells, settings))
        {
            throw new FillingFieldException("Field parameters are not valid.");
        }
        
        foreach (var mine in mines)
        {
            var availableCells = _cellsChecker
                .GetAvailableCells(mine, settings.Rows, settings.Columns)
                .ToArray();

            foreach (var cell in availableCells)
            {
                _cellsChecker.PutNumberInCell(cells, cell);
            }
        }
    }

    public void GenerateEmptyCells(BaseCell[][] cells)
    {
        for (int i = 0; i < cells.Length; i++)
        {
            for (var j = 0; j < cells[i].Length; j++)
            {
                if (cells[i][j] is null)
                {
                    cells[i][j] = new EmptyCell(i, j);
                }
            }
        }
    }

    private bool CanGenerate(BaseCell[][] cells, FieldInitialSettings settings)
    {
        var flag = cells.Length == settings.Rows;

        foreach (var col in cells)
        {
            if (col.Length != settings.Columns)
            {
                flag = false;
            }
        }
        
        return flag;
    }
}