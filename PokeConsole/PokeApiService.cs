using System.Net.Http.Json;
using System.Text.Json;

namespace PokeConsole;

public static class PokeApiService
{
    private const string BaseUrl = "https://pokeapi.co/api/v2/";
    private static readonly HttpClient HttpClient = new();

    public static async Task<Pokemon> GetPokemon(string pokemonName)
    {
        var url = $"{BaseUrl}{pokemonName}";
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(url);
        var responseBody = await response.Content.ReadFromJsonAsync<JsonElement>();
        
        return ParsePokemon(responseBody);
    }

    private static Pokemon ParsePokemon(JsonElement data)
    {
        // parse stats
        var stats = new Dictionary<string, int>();
        JsonElement statsArray = data.GetProperty("stats");
        foreach (JsonElement statElement in statsArray.EnumerateArray())
        {
            var statName = statElement.GetProperty("stat").GetProperty("name").GetString();
            var baseStat = statElement.GetProperty("base_stat").GetInt32();
                
            stats.Add(statName, baseStat);
        }

        // parse types
        var types = new List<string>();
        JsonElement typesArray = data.GetProperty("types");
        foreach (JsonElement typeElement in typesArray.EnumerateArray())
        {
            var typeName = typeElement.GetProperty("type").GetProperty("name").GetString();
    
            types.Add(typeName);
        }
            
        return new Pokemon()
        {
            Name = data.GetProperty("name").GetString(),
            Height = data.GetProperty("height").GetDouble(),
            Weight = data.GetProperty("weight").GetDouble(),
            Stats = stats,
            Types = types
        };
    }
}