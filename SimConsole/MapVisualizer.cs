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
    private readonly List<Creature> _creatures;
    private readonly List<Point> _positions;

    public MapVisualizer(Map map, List<Creature> creatures, List<Point> positions)
    {
        _map = map;
        _creatures = creatures;
        _positions = positions;
    }

    public void Draw()
    {

        int sizeX = _map.SizeX;
        int sizeY = _map.SizeY;

        var creaturePositions = new Dictionary<Point, List<Creature>>();
        for (int i = 0; i < _creatures.Count; i++)
        {
            Point position = _positions[i];
            if (!creaturePositions.ContainsKey(position))
            {
                creaturePositions[position] = new List<Creature>();
            }
            creaturePositions[position].Add(_creatures[i]);
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
                if (creaturePositions.ContainsKey(point))
                {
                    var creaturesAtPoint = creaturePositions[point];
                    if (creaturesAtPoint.Count > 1)
                        Console.Write(" X ");
                    else if (creaturesAtPoint[0] is Orc)
                        Console.Write(" O ");
                    else if (creaturesAtPoint[0] is Elf)
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

    public void LogMove(Creature creature, Point start, Point destination, Direction direction)
    {
        if (start.X != destination.X || start.Y != destination.Y)

            {
                Console.WriteLine($"{creature.GetType().Name.ToUpper()}: {creature.Name} ({start.X}, {start.Y}) moves {direction.ToString().ToLower()} ({destination.X}, {destination.Y}):");
        }
    }
}