
namespace Simulator;

public abstract class Creature
{
    private string name = "Unknown";
    public string Name
    {
        get => name;
        init
        {
            //if (string.IsNullOrWhiteSpace(value))    // czy przy null ma byc ### czy Unknown?
            //{
            //    value = name;
            //}

            value = value.Trim();
            if (value.Length > 25)
            {
                value = value.Substring(0, 25).TrimEnd();
            }
            if (value.Length < 3)
            {
                value = value.PadRight(3, '#');
            }
            if (value.Length > 0 && char.IsLower(value[0]))
            {
                value = char.ToUpper(value[0]) + value.Substring(1);
            }
            name = value;
        }
    }


    private int level = 1;
    public int Level
    {
        get => level;
        init
        {
            if (value < 1)
                level = 1;
            else if (value > 10)
                level = 10;
            else
                level = value;
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

    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string directions)
    {
        Direction[] directionsParsed = DirectionParser.Parse(directions);
        Go(directionsParsed);
    }



    public abstract void SayHi();
    public string Info => $"{Name} [{Level}]";

    public abstract int Power { get; }
}
