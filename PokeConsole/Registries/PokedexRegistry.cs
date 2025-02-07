using PokeConsole.Models;

namespace PokeConsole.Registries;

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