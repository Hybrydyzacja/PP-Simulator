
using Simulator.Maps;
namespace Simulator;

public class Animals : IMappable
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    private string description = "Unknown";
    public required string Description
    {
        get => description;
        init
        {
            description = Validator.Shortener(value, 3, 15, '#');
        }
    }


    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

    public virtual char Symbol => 'A';
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

   

    public virtual void Go(Direction direction)
    {
        if (Map == null)
        {
            throw new InvalidOperationException($"Error: Animal is not assigned to any map.");
        }

        var nextPosition = GetNewPosition(direction);

        Map.Remove(this, Position);
        Map.Add(this, nextPosition);
        Position = nextPosition;

    }

    public virtual void InitMapAndPosition(Map map, Point point)
    {
        if (map == null) throw new ArgumentNullException(nameof(map));
        if (Map != null) throw new InvalidOperationException("This animal is already on a map.");
        if (!map.Exist(point)) throw new ArgumentException("Non-existing position for this map.");
        Map = map;
        Position = point;
        map.Add(this, point);
    }
    protected virtual Point GetNewPosition(Direction direction)
    {
        return Map.Next(Position, direction);
    }
}
