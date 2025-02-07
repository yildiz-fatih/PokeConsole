using PokeConsole.Commands.Base;

namespace PokeConsole.Commands;

public class MapCommand : Command
{
    public override string Name { get; } = "map";
    public override string Description { get; } = "Show next 20 location areas (paginated results)";
    public override async Task ExecuteAsync(params string[] args)
    {
        Console.WriteLine("Loading map...");

        var url = AppState.NextLocationsUrl ?? "https://pokeapi.co/api/v2/location-area/";
        var result = await PokeApiService.GetLocationAreas(url);

        AppState.NextLocationsUrl = result.NextUrl;
        AppState.PreviousLocationsUrl = result.PreviousUrl;
        
        Console.WriteLine("Location areas:");
        foreach (var name in result.Names)
        {
            Console.WriteLine($"- {name}");
        }
    }
}