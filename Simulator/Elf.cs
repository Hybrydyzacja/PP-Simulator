
namespace Simulator;

public class Elf : Creature
{
    private int agility = 1;
    private int counter = 0;
    public int Agility
    {
        get { return agility; }
        init
        {
            if (value < 0) value = 0;
            else if (value > 10) value = 10;
            agility = value;
        }
    }

    public void Sing()
    {
        counter++;
        Console.WriteLine($"{Name} is singing.");
        if (counter % 3 == 0)
        {
            if (agility < 10) agility++;
        }
    }

    public Elf()
    { 
    }

    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public override int Power => 8 * Level + 2 * Agility;

    public override void SayHi() => Console.WriteLine(
        $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."
        );
}