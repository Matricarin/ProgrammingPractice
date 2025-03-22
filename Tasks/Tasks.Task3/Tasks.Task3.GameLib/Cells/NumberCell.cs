namespace Tasks.Task3.GameLib.Cells;

public sealed class NumberCell : BaseCell
{
    public int Number { get; set; }

    public NumberCell(int x, int y) : base(x, y)
    {
    }
}