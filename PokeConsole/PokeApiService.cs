using System.Net.Http.Json;
using System.Text.Json;
using PokeConsole.Models;

namespace PokeConsole;

public static class PokeApiService
{
    private const string BaseUrl = "https://pokeapi.co/api/v2/";
    private static readonly HttpClient HttpClient = new();

    public static async Task<Pokemon> GetPokemon(string pokemonName)
    {
        var url = $"{BaseUrl}pokemon/{pokemonName}";
        var response = await HttpClient.GetAsync(url);
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

    public static async Task<List<string>> GetPokemonsInLocationArea(string locationAreaName)
    {
        var pokemons = new List<string>();

        var response = await HttpClient.GetAsync($"{BaseUrl}location-area/{locationAreaName}");
        var responseBody = await response.Content.ReadFromJsonAsync<JsonElement>();
        
        var pokemonEncounters = responseBody.GetProperty("pokemon_encounters").EnumerateArray();
        
        foreach (var encounter in pokemonEncounters)
        {
            var name = encounter.GetProperty("pokemon").GetProperty("name").GetString();
            pokemons.Add(name);
        }
        
        return pokemons;
    }

    public static async Task<LocationAreasResult> GetLocationAreas(string url)
    {
        var response = await HttpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
    
        var responseBody = await response.Content.ReadFromJsonAsync<JsonElement>();
        var result = new LocationAreasResult();

        foreach (var location in responseBody.GetProperty("results").EnumerateArray())
        {
            result.Names.Add(location.GetProperty("name").GetString());
        }

        // Get the "next" property from the JSON response.
        JsonElement nextElement = responseBody.GetProperty("next");
        if (nextElement.ValueKind != JsonValueKind.Null)
        {
            result.NextUrl = nextElement.GetString();
        }

        // Get the "previous" property from the JSON response.
        JsonElement previousElement = responseBody.GetProperty("previous");
        if (previousElement.ValueKind != JsonValueKind.Null)
        {
            result.PreviousUrl = previousElement.GetString();
        }


        return result;
    }
}