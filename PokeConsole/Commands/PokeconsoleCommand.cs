using PokeConsole.Commands.Base;

namespace PokeConsole.Commands;

public class PokeconsoleCommand : Command
{
    public override string Name { get; } = "pokeconsole";
    public override string Description { get; } = "Lists all Pokemon in the PokeConsole";
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