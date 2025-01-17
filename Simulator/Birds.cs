
namespace Simulator;

public class Birds: Animals
{
    public bool CanFly { get; set; } = true;
    public override char Symbol => CanFly ? 'B' : 'b';


    public override string Info
    {
        get
        {
            string flyInfo = CanFly ? "fly+" : "fly-";
            return $"{Description} ({flyInfo}) <{Size}>";
        }
    }
    
    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

    
    protected override Point GetNewPosition(Direction direction) => CanFly
            ? Map.Next(Map.Next(Position, direction), direction)
            : Map.NextDiagonal(Position, direction);
}
    




