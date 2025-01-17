
using Simulator.Maps;
namespace Simulator;

public class Elf : Creature, IMappable
{
    private int agility = 1;
    private int counter = 0;
    public int Agility
    {
        get => agility;
        init
        {
            agility = Validator.Limiter(value, 0, 10);
        }
    }

    public void Sing()
    {
        counter++;
        if (counter % 3 == 0)
        {
            if (agility < 10) agility++;
        }
    }

    public Elf()
    { 
    }
    public override char Symbol => 'E';


    public Elf(string name, int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public override int Power => 8 * Level + 2 * Agility;

    public override string Greeting()
    {
        return $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";
    }

    public override string Info
    {
        get 
        { 
            return $"{Name} [{Level}][{Agility}]"; 
        }
    }
}