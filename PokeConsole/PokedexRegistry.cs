using System.Text;

namespace PokeConsole;

public static class PokedexRegistry
{
    private static readonly Dictionary<string, Pokemon> Pokemons = new();
    public static void Register(Pokemon pokemon)
    {
        Pokemons.Add(pokemon.Name, pokemon);
    }

    public static Pokemon? Get(string pokemonName)
    {
        return Pokemons.ContainsKey(pokemonName) ? Pokemons[pokemonName] : null;
    }

    public static List<Pokemon> GetAll()
    {
        return Pokemons.Values.ToList();
    }
}

public class Pokemon
{
    public string Name { get; init; }
    public double Height { get; init; }
    public double Weight { get; init; }
    public Dictionary<string, int> Stats { get; init; } = new();
    public List<string> Types { get; init; } = new();

    public override string ToString()
    {
        StringBuilder messageBuilder = new();
        messageBuilder.AppendLine($"Name: {Name}");
        messageBuilder.AppendLine($"Height: {Height}");
        messageBuilder.AppendLine($"Weight: {Weight}");
        messageBuilder.AppendLine($"Stats:");
        foreach (var stat in Stats)
        {
            messageBuilder.AppendLine($"-{stat.Key}: {stat.Value}");
        }
        messageBuilder.AppendLine($"Types:");
        foreach (var type in Types)
        {
            messageBuilder.AppendLine($"- {type}");
        }
        
        return messageBuilder.ToString();
    }
}