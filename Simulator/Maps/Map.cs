namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    private readonly Rectangle bounds;
    public int SizeX { get; }
    public int SizeY { get; }

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5) throw new ArgumentOutOfRangeException(nameof(sizeX), "Za mały wymiar krawędzi X");
        if (sizeY < 5) throw new ArgumentOutOfRangeException(nameof(sizeY), "Za mały wymiar krawędzi Y");

        SizeX = sizeX;
        SizeY = sizeY;
        bounds = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }

    public bool Exist(Point p)
    {
        return bounds.Contains(p);
    }
    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}