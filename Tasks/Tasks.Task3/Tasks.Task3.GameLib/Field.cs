using Tasks.Task3.GameLib.Cells;

namespace Tasks.Task3.GameLib;

public sealed class Field<T>
{
    private T[][] _cells;
    public T[][] Cells => _cells;

    public Field(FieldInitialSettings fieldInitialSettings)
    {
        _cells = new T[fieldInitialSettings.Rows][];
    }
}