

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
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
    }
}