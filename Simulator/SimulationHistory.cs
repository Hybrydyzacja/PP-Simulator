using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace Simulator;
public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0
    public string ResultMessage { get; private set; } = "";
    public Point TreasureLocation { get; }
    public IMappable? TreasureFinder { get; private set; }

    public SimulationHistory(Simulation simulation)
    {
        Console.WriteLine("SimulationHistory initialized!");
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        TreasureLocation = _simulation.TreasureLocation;
        Run();
    }


    private void Run()
    {
        // Zapisz początkowy stan mapy jako turę 0
        var initialSymbols = new Dictionary<Point, char>();
        

        foreach (var mappable in _simulation.Mappables)
        {
            if (initialSymbols.ContainsKey(mappable.Position))
            {
                initialSymbols[mappable.Position] = 'X'; // Konflikt pozycji
            }
            else
            {
                initialSymbols[mappable.Position] = mappable.Symbol;
            }
        }
        initialSymbols[TreasureLocation] = '$';
        


        TurnLogs.Add(new SimulationTurnLog
        {
            Mappable = "Start",
            Move = "Initial positions",
            Symbols = initialSymbols
        });


        int currentTurn = 0;
        int maxTurns = _simulation.Moves.Length;
        

        while (currentTurn < maxTurns && !_simulation.TreasureFound)
        {
            var currentMappable = _simulation.CurrentMappable;
            var currentPosition = _simulation.CurrentMappable.Position;
            var symbolsBeforeMove = new Dictionary<Point, char>();

            

            TurnLogs.Add(new SimulationTurnLog
            {
                Mappable = $"{_simulation.CurrentMappable.ToString()}  ({currentPosition.X}, {currentPosition.Y})",
                Move = _simulation.CurrentMoveName,
                Symbols = symbolsBeforeMove
            });

            _simulation.Turn();
            

            foreach (var mappable in _simulation.Mappables)
            {
                if (symbolsBeforeMove.ContainsKey(mappable.Position))
                {
                    symbolsBeforeMove[mappable.Position] = 'X'; // Konflikt pozycji
                }
                else
                {
                    symbolsBeforeMove[mappable.Position] = mappable.Symbol;
                }
            }
            symbolsBeforeMove[_simulation.TreasureLocation] = '$'; // Skarb

            if (currentMappable.Position == _simulation.TreasureLocation)
            {
                _simulation.SetTreasureFound();
                TreasureFinder = currentMappable; // Zapamiętaj, kto znalazł skarb
                break;
            }
            

            currentTurn++;

        }
        if (TreasureFinder != null)
        {
            ResultMessage = $"Gratulacje! {TreasureFinder} znalazł skarb w turze {currentTurn}.";
        }
        else
        {
            ResultMessage = "Tym razem nikomu nie udało się znaleźć skarbu.";
        }

    }

    }


