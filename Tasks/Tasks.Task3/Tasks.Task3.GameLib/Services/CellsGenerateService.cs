using Tasks.Task3.GameLib.Cells;
using Tasks.Task3.GameLib.Handlers;

namespace Tasks.Task3.GameLib.Services;

public sealed class CellsGenerateService 
{
    private readonly MinesRandomizer _randomizer;
    private readonly CellsChecker _cellsChecker;
    private readonly FieldInitialSettings _fieldSettings;

    public CellsGenerateService(FieldInitialSettings fieldSettings)
    {
        _randomizer = new MinesRandomizer(45, 180);
        _cellsChecker = new CellsChecker();
        _fieldSettings = fieldSettings;
    }

    public IEnumerable<BaseCell> GenerateMines(BaseCell[][] cells)
    {
        var mines = _randomizer.GenerateRandomMines(_fieldSettings);

        for (var i = 0; i < _fieldSettings.Rows; i++)
        {
            for (var j = 0; j < _fieldSettings.Columns; j++)
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

    public void GenerateNumbers(BaseCell[][] cells, BaseCell[] mines)
    {
        foreach (var mine in mines)
        {
            var availableCells = _cellsChecker
                .GetAvailableCells(mine, _fieldSettings)
                .ToArray();

            foreach (var cell in availableCells)
            {
                _cellsChecker.PutNumberInCell(cells, cell);
            }
        }
    }

    public void GenerateEmptyCells(BaseCell[][] cells)
    {
        for (int i = 0; i < _fieldSettings.Rows; i++)
        {
            for (var j = 0; j < _fieldSettings.Columns; j++)
            {
                if (cells[i][j] is null)
                {
                    cells[i][j] = new EmptyCell(i, j);
                }
            }
        }
    }
}