using PokeConsole.Commands.Base;

namespace PokeConsole.Commands;

public class MapBackCommand : Command
{
    public override string Name { get; } = "mapb";
    public override string Description { get; } = "Show previous 20 location areas (paginated results)";
    public override async Task ExecuteAsync(params string[] args)
    {
        Console.WriteLine("Loading map...");
        
        if (string.IsNullOrEmpty(AppState.PreviousLocationsUrl))
        {
            Console.WriteLine("You're on the first page.");
            return;
        }
        
        var result = await PokeApiService.GetLocationAreas(AppState.PreviousLocationsUrl);
        AppState.NextLocationsUrl = result.NextUrl;
        AppState.PreviousLocationsUrl = result.PreviousUrl;

        Console.WriteLine("Location areas:");
        foreach (var name in result.Names)
        {
            Console.WriteLine($"- {name}");
        }
    }
}