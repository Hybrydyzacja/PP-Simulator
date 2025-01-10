namespace Simulator.Maps;


public class SmallTorusMap : Map
{
    public readonly int Size;
    private readonly Rectangle bounds;

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Nieprawidłowy rozmiar, dopuszczalne wartości boku <5;20>");
        }
        Size = size;
        bounds = new Rectangle(0, 0, size - 1, size - 1);
    }
    public override bool Exist(Point p)
    {
        return bounds.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        int newX = (nextPoint.X + Size) % Size;
        int newY = (nextPoint.Y + Size) % Size;
        return new Point(newX, newY);
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextDiagonalPoint = p.NextDiagonal(d);
        int newX = (nextDiagonalPoint.X + Size) % Size;
        int newY = (nextDiagonalPoint.Y + Size) % Size;
        return new Point(newX, newY);
    }
}
