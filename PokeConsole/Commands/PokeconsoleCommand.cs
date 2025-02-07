using PokeConsole.Commands.Base;
using PokeConsole.Registries;

namespace PokeConsole.Commands;

public class PokeconsoleCommand : Command
{
    public override string Name { get; } = "pokeconsole";
    public override string Description { get; } = "Show all Pokemon in your PokeConsole";
    public override Task ExecuteAsync(params string[] args)
    {
        Console.WriteLine("Your PokeConsole:");
        foreach (var pokemon in PokedexRegistry.GetAll())
        {
            Console.WriteLine($"- {pokemon.Name}");
        }
        
        return Task.CompletedTask;
    }
}