using Tasks.Task3.GameLib.Cells;

namespace Tasks.Task3.GameLib.Services;

public sealed class CellsGenerateService : ICellsGenerateService<BaseCell>
{
    public IEnumerable<BaseCell> GenerateMines(Field<BaseCell> field, int minesAmount)
    {
        var cells = new List<BaseCell>();
        
        for (int i = 0; i < minesAmount; i++)
        {
            
        }
        
        return cells;
    }

    public void GenerateNumbers(Field<BaseCell> field)
    {
        throw new NotImplementedException();
    }

    public void GenerateEmptyCells(Field<BaseCell> field)
    {
        throw new NotImplementedException();
    }
}