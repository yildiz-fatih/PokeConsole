namespace PokeConsole;

public static class PokedexRegistry
{
    private static readonly Dictionary<string, Pokemon> Pokemons = new();
    public static void Register(Pokemon pokemon)
    {
        Pokemons.Add(pokemon.Name, pokemon);
    }
}

public class Pokemon
{
    public string Name;
    public double Height;
    public double Weight;
    public Dictionary<string, int> Stats = new();
    public List<string> Types = new();
}