using PokeConsole.Commands.Base;

namespace PokeConsole.Commands;

public class MapCommand : Command
{
    public override string Name { get; } = "map";
    public override string Description { get; } = "Displays the first 20 locations on the map.";
    public override async Task ExecuteAsync(params string[] args)
    {
        Console.WriteLine("Loading map...");

        var locationAreas = await PokeApiService.GetLocationAreas();

        Console.WriteLine("Location areas:");
        foreach (var name in locationAreas)
        {
            Console.WriteLine($"- {name}");
        }
    }
}