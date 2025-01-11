using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5);
        List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new MapVisualizer(simulation.Map, simulation.Creatures, simulation.Positions);


        Console.WriteLine("Starting positions:");
        

        while (!simulation.Finished)
        {
            mapVisualizer.Draw();
            Console.WriteLine("Naciśnij dowolny klawisz, aby wykonać kolejny ruch...");
            Console.ReadKey(true);

            var currentCreature = simulation.CurrentCreature;
            var currentPosition = simulation.Positions[simulation.Creatures.IndexOf(currentCreature)];
            var moveChar = simulation.CurrentMoveName;
            var direction = DirectionParser.Parse(moveChar.ToUpper())[0];
            var nextPosition = simulation.Map.Next(currentPosition, direction);
            mapVisualizer.LogMove(currentCreature, currentPosition, nextPosition, direction);

            simulation.Turn();
            
           
            Console.WriteLine();
        }
        
        Console.WriteLine("Symulacja zakończona. Naciśnij dowolny klawisz, aby wyjść...");
        Console.ReadKey();
    }
   }
        


