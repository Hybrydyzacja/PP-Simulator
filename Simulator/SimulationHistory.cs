using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;

namespace Simulator;
public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
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

        TurnLogs.Add(new SimulationTurnLog
        {
            Mappable = "Start",
            Move = "Initial positions",
            Symbols = initialSymbols
        });

        // Przechodź przez kolejne ruchy
        while (!_simulation.Finished)
        {
            var currentPosition = _simulation.CurrentMappable.Position;
            var symbolsBeforeMove = new Dictionary<Point, char>();

            TurnLogs.Add(new SimulationTurnLog
            {
                Mappable = $"{_simulation.CurrentMappable.ToString()}  ({currentPosition.X}, {currentPosition.Y})",
                Move = _simulation.CurrentMoveName.ToString(),
                Symbols = symbolsBeforeMove
            });


            _simulation.Turn();
            // Najpierw zapisz log PRZED wykonaniem ruchu
            
            
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
  
        }
    }

}
