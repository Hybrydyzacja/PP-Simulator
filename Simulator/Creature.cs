
using Simulator.Maps;
namespace Simulator;

public abstract class Creature : IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    private string name = "Unknown";
    public string Name
    {
        get => name;
        init
        {
            name = Validator.Shortener(value, 3, 25, '#');
        }
    }


    private int level = 1;
    public int Level
    {
        get => level;
        init
        {
            level = Validator.Limiter(value, 1, 10);
        }
    }
    public Creature(string name, int level = 1)
    {
        Name = name;  
        Level = level;
    }

    public Creature()
    {
    }

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }

    public void InitMapAndPosition(Map map, Point p)
    {
        Map = map;
        Position = p;
    }



    public string Go(Direction direction)
    {
        try
        {
            if (Map == null)
            {
                throw new InvalidOperationException("Creature is not assigned to any map.");
            }

            Map.Move(this, Position, Map.Next(Position, direction));
            Position = Map.Next(Position, direction);
        }
        catch (NullReferenceException)
        { Console.WriteLine($"Creature ({this.name}) out of map"); }
        return $"{direction.ToString().ToLower()}";
    }

    public string[] Go(string directions)
    {
        List<Direction> directionsParsed = DirectionParser.Parse(directions);
        return Go(directionsParsed);
    }

    public string[] Go(List<Direction> directionsParsed)
    {
        List<string> results = new();

        foreach (Direction direction in directionsParsed)
        {
            results.Add(Go(direction)); // Wywołanie pojedynczego ruchu
        }

        return results.ToArray();
    }

    public abstract int Power { get; }
    public abstract string Greeting();
    public abstract string Info { get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }


}
