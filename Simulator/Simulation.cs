using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    private int index = 0;
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature
    {
        get => Creatures[index % Creatures.Count];
    }
    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get => DirectionParser.Parse(Moves[index % Moves.Length].ToString())[0].ToString().ToLower();
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
        {
            throw new ArgumentException("Lista stworów nie może być pusta", nameof(creatures));
        }

        if (creatures.Count != positions.Count)
        {
            throw new ArgumentException("Liczba stworów musi odpowiadac liczbie pozycji");
        }

        Map = map ?? throw new ArgumentNullException(nameof(map));
        Creatures = creatures;
        Positions = positions;
        Moves = moves ?? throw new ArgumentNullException(nameof(moves));
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Koniec symulacji");
        }


        char moveChar = Moves[index % Moves.Length];

        var parsedDirections = DirectionParser.Parse(moveChar.ToString());

        if (parsedDirections.Count == 0)
        {
            throw new InvalidOperationException($"Nieprawidłowy znak '{moveChar}'. Możliwe kierunki: 'U', 'D', 'L', 'R'.");
        }

        Creature currentCreature = CurrentCreature;
        Point currentPosition = Positions[index % Positions.Count];

        Direction moveDirection = parsedDirections[0];
        Point nextPosition = Map.Next(currentPosition, moveDirection);

        if (Map.Exist(nextPosition))
        {
            // Zaktualizuj mapę
            Map.Remove(currentCreature, currentPosition);
            Map.Add(currentCreature, nextPosition);

            // Zaktualizuj pozycję stworzenia
            Positions[index % Positions.Count] = nextPosition;
        }

        index++;

        if (index >= Moves.Length)
        {
            Finished = true;
        }
    }
}