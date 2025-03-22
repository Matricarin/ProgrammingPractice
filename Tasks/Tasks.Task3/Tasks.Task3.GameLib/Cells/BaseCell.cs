namespace Tasks.Task3.GameLib.Cells;

public class BaseCell
{
    public BaseCell(int x, int y)
    {
        X = x;
        Y = y;
        Marked = false;
        IsHidden = true;
    }

    public int X { get; }
    public int Y { get; }
    public bool Marked { get; set; }
    public bool IsHidden { get; set; }
}