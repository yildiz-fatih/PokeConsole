using PokeConsole.Commands.Base;

namespace PokeConsole.Commands;

public class ExploreCommand : Command
{
    public override string Name { get; } = "explore";
    public override string Description { get; } = "Displays all Pokemon in a specified location area";
    public override async Task ExecuteAsync(params string[] args)
    {
        var locationArea = args[1];
        Console.WriteLine($"Exploring {locationArea}...");

        var pokemons = await PokeApiService.GetPokemonsInLocationArea(locationArea);

        Console.WriteLine("Found Pokemon:");
        foreach (var name in pokemons)
        {
            Console.WriteLine($"- {name}");
        }
    }
}