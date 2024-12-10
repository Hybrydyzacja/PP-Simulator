namespace Simulator;

public class Simulator
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Creature c = new Creature("Shrek", 7);
        Creature b = new Creature("Fiona");
        Creature a = new Creature();

        c.SayHi();
        b.SayHi();
        a.SayHi();
        Console.WriteLine(c.Info);
        Console.WriteLine(b.Info);
        Console.WriteLine(a.Info);

        Animals dogs = new Animals
        {
            Description = "Dogs"
        };
        Console.WriteLine(dogs.Info);
        
    }
}
