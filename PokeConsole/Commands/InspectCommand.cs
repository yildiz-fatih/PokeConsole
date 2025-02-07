using PokeConsole.Commands.Base;
using PokeConsole.Registries;

namespace PokeConsole.Commands;

public class InspectCommand : Command
{
    public override string Name { get; } = "inspect";
    public override string Description { get; } = "Gets info about a Pokemon";
    public override Task ExecuteAsync(params string[] args)
    {
        var pokemonName = args[1];
        var pokemon = PokedexRegistry.Get(pokemonName);
        if (pokemon == null)
        {
            Console.WriteLine($"You have not caught {pokemonName} (yet)!");
        }
        else
        {
            Console.WriteLine($"{pokemonName} was caught!");
            Console.WriteLine(pokemon.ToString());
        }
        
        return Task.CompletedTask;
    }
}