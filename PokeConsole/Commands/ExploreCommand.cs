using System.Net.Http.Json;
using System.Text.Json;
using PokeConsole.Commands.Base;

namespace PokeConsole.Commands;

public class ExploreCommand : Command
{
    public override string Name { get; } = "explore";
    public override string Description { get; } = "Displays all Pokemon in a specified location area";
    public override async Task ExecuteAsync(params string[] args)
    {
        var locationArea = args[1];
        Console.WriteLine($"Exploring {locationArea}...");

        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://pokeapi.co/api/v2/location-area/" + locationArea);
        var responseBody = await response.Content.ReadFromJsonAsync<JsonElement>();
        
        var pokemonEncounters = responseBody.GetProperty("pokemon_encounters").EnumerateArray();
        
        Console.WriteLine("Found Pokemon:");
        foreach (var encounter in pokemonEncounters)
        {
            var name = encounter.GetProperty("pokemon").GetProperty("name").GetString();
            Console.WriteLine($"- {name}");
        }
    }
}