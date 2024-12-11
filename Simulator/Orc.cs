
namespace Simulator;

public class Orc : Creature
{
    private int rage = 1;
    private int counter = 0;
    public int Rage
    {
        get { return rage; }
        init
        {
            if (value < 0) value = 0;
            else if (value > 10) value = 10;
            rage = value;
        }
    }

    public void Hunt()
    {
        counter++;
        Console.WriteLine($"{Name}is hunting.");
        if (counter % 2 == 0)
        {
            if (rage < 10) rage++;
        }
    }

    public Orc()
    {
    }

    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public override int Power => 7 * Level + 3 * Rage;

    public override void SayHi() => Console.WriteLine(
        $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}."
        );
}
