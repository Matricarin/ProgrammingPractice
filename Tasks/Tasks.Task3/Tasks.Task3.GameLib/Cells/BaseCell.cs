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

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }
        
        var other = obj as BaseCell;
        
        if (other == null)
        {
            return false;
        }
        return X == other.X && Y == other.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}