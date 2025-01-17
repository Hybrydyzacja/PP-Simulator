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
        for (int i = 0; i < _simulation.Moves.Length; i++)
        {
            
            var symbols = new Dictionary<Point, char>();

            foreach (var mappable in _simulation.Mappables)
            {
                
                if (symbols.ContainsKey(mappable.Position))
                {
                    symbols[mappable.Position] = 'X';
                }
                else
                {
                    symbols[mappable.Position] = mappable.Symbol;
                }
            }
  
            TurnLogs.Add(new SimulationTurnLog
            {
                Mappable = _simulation.CurrentMappable.ToString(),
                Move = _simulation.CurrentMoveName.ToString(),
                Symbols = symbols
            });

            // Wykonujemy kolejny ruch w symulacji
            _simulation.Turn();
        }
    }
}
