using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        //SmallSquareMap map = new(5);
        //List<IMappable> mappables = new() { new Orc("Gorbag"), new Elf("Elandor") };
        //List<Point> points = [new(2, 2), new(3, 1)];
        //string moves = "dlrludl";


        SmallTorusMap map = new SmallTorusMap(8,6);
        List<IMappable> mappables =
            [new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Rabbits", Size = 10},
            new Birds { Description = "Eagles"},
            new Birds { Description = "Ostriches", CanFly = false}];
        List<Point> points = [new(2, 2), new(3, 1), new(2, 1), new(3, 2), new(2, 3)];
        string moves = "drllurdldlrludl";



        Simulation simulation = new Simulation(map, mappables, points, moves);
        MapVisualizer mapVisualizer = new MapVisualizer(map);


        Console.WriteLine("Starting positions:");
        

        while (!simulation.Finished)
        {
            mapVisualizer.Draw();
            Console.WriteLine("Naciśnij dowolny klawisz, aby wykonać kolejny ruch...");
            Console.ReadKey(true);

            //var currentMappable = simulation.CurrentMappable;
            //var currentPosition = simulation.Positions[simulation.Mappables.IndexOf(currentMappable)];
            //var moveChar = simulation.CurrentMoveName;
            //var direction = DirectionParser.Parse(moveChar.ToUpper())[0];
            //var nextPosition = simulation.Map.Next(currentPosition, direction);

            //if (currentMappable is Creature creature)
            //{
            //    mapVisualizer.LogMove(creature, currentPosition, nextPosition, direction);
            //}
            //if (currentMappable is Animals animal)
            //{
            //    mapVisualizer.LogMove(animal, currentPosition, nextPosition, direction);
            //}

            simulation.Turn();
            
           
            Console.WriteLine();
        }
        
        Console.WriteLine("Symulacja zakończona. Naciśnij dowolny klawisz, aby wyjść...");
        Console.ReadKey();
    }
   }
        


