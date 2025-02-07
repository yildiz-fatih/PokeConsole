using System.Net.Http.Json;
using System.Text.Json;
using PokeConsole.Commands.Base;

namespace PokeConsole.Commands;

public class MapCommand : Command
{
    public override string Name { get; } = "map";
    public override string Description { get; } = "Displays the first 20 locations on the map.";
    public override async Task ExecuteAsync(params string[] args)
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://pokeapi.co/api/v2/location-area/");
        var responseBody = await response.Content.ReadFromJsonAsync<JsonElement>();

        foreach (var location in responseBody.GetProperty("results").EnumerateArray())
        {
            Console.WriteLine(location.GetProperty("name").GetString());
        }
    }
}