using System.Net.Http.Json;
using System.Text.Json;
using PokeConsole.Commands.Base;

namespace PokeConsole.Commands;

public class CatchCommand : Command
{
    public override string Name { get; } = "catch";
    public override string Description { get; } = "Catch a Pokemon.";
    public override async Task ExecuteAsync(params string[] args)
    {
        var pokemonName = args[1];
        Console.WriteLine($"Throwing a Pokeball at {pokemonName}...");

        bool caught = new Random().Next(2) == 0;
        
        if (!caught)
        {
            await Task.Delay(1500);
            Console.WriteLine($"{pokemonName} escaped!");
        }
        else
        {
            var url = $"https://pokeapi.co/api/v2/pokemon/{pokemonName}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var responseBody = await response.Content.ReadFromJsonAsync<JsonElement>();
            
            /* Extract Pokemon information */
            // extract stats
            var stats = new Dictionary<string, int>();

            JsonElement statsArray = responseBody.GetProperty("stats");
            foreach (JsonElement statElement in statsArray.EnumerateArray())
            {
                var statName = statElement.GetProperty("stat").GetProperty("name").GetString();
                var baseStat = statElement.GetProperty("base_stat").GetInt32();
                
                stats.Add(statName, baseStat);
            }

            // extract types
            var types = new List<string>();

            JsonElement typesArray = responseBody.GetProperty("types");
            foreach (JsonElement typeElement in typesArray.EnumerateArray())
            {
                var typeName = typeElement.GetProperty("type").GetProperty("name").GetString();
    
                types.Add(typeName);
            }
            
            // extract the rest of the properties
            var height = responseBody.GetProperty("height").GetDouble();
            var weight = responseBody.GetProperty("weight").GetDouble();
            
            PokedexRegistry.Register(new Pokemon()
            {
                Name = pokemonName,
                Height = height,
                Weight = weight,
                Stats = stats,
                Types = types
            });
            
            Console.WriteLine($"{pokemonName} was caught!");
        }
    }
}