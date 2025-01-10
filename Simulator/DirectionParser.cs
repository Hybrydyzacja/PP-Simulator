
namespace Simulator;

public class DirectionParser
{
    public static List<Direction> Parse(string directions)
    {
        //if (string.IsNullOrWhiteSpace(directions))    //czy potrzebne takie zabezpieczenie?
        //{
        //    return Array.Empty<Direction>();
        //}

        var directionsParsed = new List<Direction>();
        foreach (var character in directions.ToUpper())
        {
            switch (character)
            {
                case 'U':
                    directionsParsed.Add(Direction.Up);
                    break;
                case 'R':
                    directionsParsed.Add(Direction.Right);
                    break;
                case 'D':
                    directionsParsed.Add(Direction.Down);
                    break;
                case 'L':
                    directionsParsed.Add(Direction.Left);
                    break;
            }
        }

        return directionsParsed;
    }
}