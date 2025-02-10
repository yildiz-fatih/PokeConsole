using PokeConsole.Commands.Base;
using PokeConsole.Helpers;
using PokeConsole.Registries;

namespace PokeConsole.Commands;

public class InspectCommand : Command
{
    public override string Name { get; } = "inspect";
    public override string Description { get; } = "Show caught Pokemon details";
    public override Task ExecuteAsync(params string[] args)
    {
        var pokemonName = args[1];
        var pokemon = PokedexRegistry.Get(pokemonName);
        if (pokemon == null)
        {
            ConsoleHelper.WriteLine($"You have not caught {pokemonName} (yet)!");
        }
        else
        {
            ConsoleHelper.WriteLine($"{pokemonName} was caught!");
            ConsoleHelper.WriteLine(pokemon.ToString());
        }
        
        return Task.CompletedTask;
    }
}