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
        _generator = new CellsGenerateService(fieldInitialSettings);
        _cells = new BaseCell[fieldInitialSettings.Rows][];
        
        var mines = _generator
            .GenerateMines(_cells)
            .ToArray();
        
        _generator.GenerateNumbers(_cells, mines);
        
        _generator.GenerateEmptyCells(_cells);
    }
}