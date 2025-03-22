namespace Tasks.Task3.GameLib.Cells;

public sealed class NumberCell : BaseCell
{
    public int Number { get;}

    public NumberCell(int x, int y) : base(x, y)
    {
    }

    public NumberCell(int x, int y, int number) : base(x, y)
    {
        Number = number;
    }
}