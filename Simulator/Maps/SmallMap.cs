

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    List<Creature>?[,] _fields;
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {

        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Za duży wymiar krawędzi X");
        }

        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Za duży wymiar krawędzi Y");
        }
        _fields = new List<Creature>?[sizeX, sizeY];
    }
    public override void Add(Creature c, Point p)
    {
        _fields[p.X, p.Y].Add(c);
        c.InitMapAndPosition(this, p);
    }
    public override List<Creature>? At(int x, int y) => _fields[x, y];
    public override List<Creature>? At(Point p) => _fields[p.X, p.Y];
    public override void Move(Creature c, Point start, Point destination)
    {
        Remove(c, start);
        Add(c, destination);
    }
    public override void Remove(Creature c, Point p)
    {
        _fields[p.X, p.Y].Remove(c);
        //TO CHECK
        c.InitMapAndPosition(this, default);
    }
}