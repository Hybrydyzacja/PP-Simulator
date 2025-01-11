﻿

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private readonly List<Creature>?[,] _fields;
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

        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                _fields[x, y] = new List<Creature>();
            }
        }
    }
    public override void Add(Creature c, Point p)
    {
        if (p.X < 0 || p.X >= SizeX || p.Y < 0 || p.Y >= SizeY)
        {
            throw new ArgumentOutOfRangeException(nameof(p), "Pozycja jest poza mapą");
        }
        _fields[p.X, p.Y].Add(c);
        c.InitMapAndPosition(this, p);
    }
    public override List<Creature>? At(int x, int y) => _fields[x, y];
    public override List<Creature>? At(Point p) => _fields[p.X, p.Y];
    public override void Move(Creature c, Point start, Point destination)
    {
        if (start.X < 0 || start.X >= SizeX || start.Y < 0 || start.Y >= SizeY ||
            destination.X < 0 || destination.X >= SizeX || destination.Y < 0 || destination.Y >= SizeY)
        {
            throw new ArgumentOutOfRangeException("Start lub cel ruchu jest poza mapą");
        }

        Remove(c, start);
        Add(c, destination);
    }
    public override void Remove(Creature c, Point p)
    {
        if (p.X < 0 || p.X >= SizeX || p.Y < 0 || p.Y >= SizeY)
        {
            throw new ArgumentOutOfRangeException(nameof(p), "Pozycja jest poza mapą");
        }
        _fields[p.X, p.Y].Remove(c);
        c.InitMapAndPosition(this, default);
    }
}