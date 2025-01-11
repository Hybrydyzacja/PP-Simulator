using System;

namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public readonly int Size;
    public SmallSquareMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        Size = Math.Min(sizeX, sizeY);
    }

    public SmallSquareMap(int size) : this(size, size)
    {
        Size = size;
    }
    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        return Exist(nextPoint) ? nextPoint : p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextDiagonalPoint = p.NextDiagonal(d);
        return Exist(nextDiagonalPoint) ? nextDiagonalPoint : p;
    }
}
