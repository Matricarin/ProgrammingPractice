using Tasks.Task3.GameLib.Cells;

namespace Tasks.Task3.GameLib.Services;

public interface ICellsGenerateService<T>
{
    IEnumerable<T> GenerateMines(Field<T> field, int minesAmount);
    void GenerateNumbers(Field<T> field);
    void GenerateEmptyCells(Field<T> field);
}