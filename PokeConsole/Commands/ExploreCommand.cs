using PokeConsole.Commands.Base;
using PokeConsole.Helpers;

namespace PokeConsole.Commands;

public class ExploreCommand : Command
{
    public override string Name { get; } = "explore";
    public override string Description { get; } = "Show Pokemon in location area";
    public override async Task ExecuteAsync(params string[] args)
    {
        var locationArea = args[1];
        ConsoleHelper.WriteLine($"Exploring {locationArea}...");

        var pokemons = await PokeApiService.GetPokemonsInLocationArea(locationArea);

        ConsoleHelper.WriteLine("Found Pokemon:");
        foreach (var name in pokemons)
        {
            ConsoleHelper.WriteLine($"- {name}");
        }
    }
}