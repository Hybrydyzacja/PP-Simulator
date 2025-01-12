using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;
using Simulator;
using System.Security.Cryptography;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;
    private readonly List<IMappable> _mappables;
    private readonly List<Point> _positions;

    public MapVisualizer(Map map, List<IMappable> mappables, List<Point> positions)
    {
        _map = map;
        _mappables = mappables;
        _positions = positions;
    }

    public void Draw()
    {

        int sizeX = _map.SizeX;
        int sizeY = _map.SizeY;

        var mappablePositions = new Dictionary<Point, List<IMappable>>();
        for (int i = 0; i < _mappables.Count; i++)
        {
            Point position = _positions[i];
            if (!mappablePositions.ContainsKey(position))
            {
                mappablePositions[position] = new List<IMappable>();
            }
            mappablePositions[position].Add(_mappables[i]);
        }

        Console.Write(Box.TopLeft);
        for (int x = 0; x < sizeX; x++)
        {
            Console.Write(new string(Box.Horizontal, 3));
            if (x < sizeX - 1)
                Console.Write(Box.TopMid);
        }
        Console.WriteLine(Box.TopRight);

        for (int y = 0; y < sizeY; y++)
        {
            for (int x = 0; x < sizeX; x++)
            {
                if (x == 0)
                    Console.Write(Box.Vertical);

                Point point = new Point(x, y);
                if (mappablePositions.ContainsKey(point))
                {
                    var mappableAtPoint = mappablePositions[point];
                    if (mappableAtPoint.Count > 1)
                        Console.Write(" X ");
                    else if (mappableAtPoint[0] is Orc)
                        Console.Write(" O ");
                    else if (mappableAtPoint[0] is Elf)
                        Console.Write(" E ");
                }
                else
                {
                    Console.Write("   ");
                }

                Console.Write(Box.Vertical);
            }
            Console.WriteLine();

            if (y < sizeY - 1)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < sizeX; x++)
                {
                    Console.Write(new string(Box.Horizontal, 3));
                    if (x < sizeX - 1)
                        Console.Write(Box.Cross);
                }
                Console.WriteLine(Box.MidRight);
            }
        }

        Console.Write(Box.BottomLeft);
        for (int x = 0; x < sizeX; x++)
        {
            Console.Write(new string(Box.Horizontal, 3));
            if (x < sizeX - 1)
                Console.Write(Box.BottomMid);
        }
        Console.WriteLine(Box.BottomRight);
    }

    public void LogMove(IMappable mappable, Point start, Point destination, Direction direction)
    {
        if (start.X != destination.X || start.Y != destination.Y)
        {
            if (mappable is Creature creature)

            {
                Console.WriteLine($"{mappable.GetType().Name.ToUpper()}: {mappable.Name} ({start.X}, {start.Y}) moves {direction.ToString().ToLower()} ({destination.X}, {destination.Y}):");
            }
        }
    }
}