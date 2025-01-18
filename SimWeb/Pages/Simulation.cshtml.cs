using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;

namespace SimWeb.Pages;

public class SimulationModel : PageModel
{
    public SimulationHistory History { get; private set; }
    public int CurrentTurn { get; private set; }

    public void OnGet(int? turn)
    {
        // Inicjalizacja symulacji
        var map = new SmallTorusMap(8, 6);
        var mappables = new List<IMappable>
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Rabbits", Size = 10 },
            new Birds { Description = "Eagles" },
            new Birds { Description = "Ostriches", CanFly = false }
        };
        var positions = new List<Point>
        {
            new(2, 2), new(3, 1), new(2, 1), new(1, 4), new(5, 5)
        };
        var moves = "dlrludl";

        var simulation = new Simulation(map, mappables, positions, moves);
        History = new SimulationHistory(simulation);

        // Obs³uga obecnej tury
        CurrentTurn = turn ?? 0;
        if (CurrentTurn < 0) CurrentTurn = 0;
        if (CurrentTurn >= History.TurnLogs.Count) CurrentTurn = History.TurnLogs.Count - 1;
    }
}
