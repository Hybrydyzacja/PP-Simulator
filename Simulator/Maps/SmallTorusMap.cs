namespace Simulator.Maps;


public class SmallTorusMap : SmallMap
{


    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }
    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        int newX = (nextPoint.X + SizeX) % SizeX;
        int newY = (nextPoint.Y + SizeY) % SizeY;
        return new Point(newX, newY);
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextDiagonalPoint = p.NextDiagonal(d);
        int newX = (nextDiagonalPoint.X + SizeX) % SizeX;
        int newY = (nextDiagonalPoint.Y + SizeY) % SizeY;
        return new Point(newX, newY);
    }
}
