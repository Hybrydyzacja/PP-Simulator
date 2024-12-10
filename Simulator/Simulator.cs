namespace Simulator;

public class Simulator
{
    static void Main(string[] args)
    {
        //{
        //    Console.WriteLine("Starting Simulator!\n");

        //    Creature c = new Creature("Shrek", 7);
        //    Creature b = new Creature("Fiona");
        //    Creature a = new Creature();

        //    c.SayHi();
        //    b.SayHi();
        //    a.SayHi();
        //    Console.WriteLine(c.Info);
        //    Console.WriteLine(b.Info);
        //    Console.WriteLine(a.Info);

        //    Animals dogs = new Animals
        //    {
        //        Description = "Dogs"
        //    };
        //    Console.WriteLine(dogs.Info);

        //}

        {
            Lab3a();
        }
        static void Lab3a()
        {
            Creature c = new() { Name = "   Shrek    ", Level = 20 };
            c.SayHi();
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new("  ", -5);
            c.SayHi();
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new("  donkey ") { Level = 7 };
            c.SayHi();
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new("Puss in Boots – a clever and brave cat.");
            c.SayHi();
            c.Upgrade();
            Console.WriteLine(c.Info);

            c = new("a                            troll name", 5);
            c.SayHi();
            c.Upgrade();
            Console.WriteLine(c.Info);

            var a = new Animals() { Description = "   Cats " };
            Console.WriteLine(a.Info);

            a = new() { Description = "Mice           are great", Size = 40 };
            Console.WriteLine(a.Info);
        }
    }
}
