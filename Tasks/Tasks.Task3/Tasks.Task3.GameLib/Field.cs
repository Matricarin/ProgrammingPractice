using Tasks.Task3.GameLib.Cells;
using Tasks.Task3.GameLib.Services;

namespace Tasks.Task3.GameLib;

public sealed class Field
{
    private readonly CellsGenerateService _generator;
    private BaseCell[][] _cells;
    
    public BaseCell[][] Cells => _cells;

    public Field(FieldInitialSettings fieldInitialSettings)
    {
        _generator = new CellsGenerateService();
        
        _cells = new BaseCell[fieldInitialSettings.Rows][];
        
        for (var i = 0; i < _cells.Length; i++)
        {
            _cells[i] = new BaseCell[fieldInitialSettings.Columns];
        }
        
        var mines = _generator
            .GenerateMines(_cells, fieldInitialSettings)
            .ToArray();
        
        _generator.GenerateNumbers(_cells, mines, fieldInitialSettings);
        
        _generator.GenerateEmptyCells(_cells);
    }
}