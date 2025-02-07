using PokeConsole.Commands.Base;
using PokeConsole.Registries;

namespace PokeConsole.Commands;

public class CatchCommand : Command
{
    public override string Name { get; } = "catch";
    public override string Description { get; } = "Attempt to catch a Pokemon";
    public override async Task ExecuteAsync(params string[] args)
    {
        var pokemonName = args[1];
        Console.WriteLine($"Throwing a Pokeball at {pokemonName}...");

        bool caught = new Random().Next(2) == 0;
        
        if (!caught)
        {
            await Task.Delay(1500);
            Console.WriteLine($"{pokemonName} escaped!");
        }
        else
        {
            var pokemon = await PokeApiService.GetPokemon(pokemonName);

            PokedexRegistry.Register(pokemon);
            
            Console.WriteLine($"{pokemonName} was caught!");
        }
    }
}