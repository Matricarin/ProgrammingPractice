namespace Tasks.Task3.GameLib;

public sealed class FieldInitialSettings
{
    public FieldInitialSettings(int rows, int columns, int minesAmount)
    {
        Rows = rows;
        Columns = columns;
        MinesAmount = minesAmount;
    }

    public int Rows { get; }
    public int Columns { get; }
    public int MinesAmount { get; }
}