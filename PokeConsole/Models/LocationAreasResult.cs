namespace PokeConsole.Models;

public class LocationAreasResult
{
    public List<string> Names { get; set; } = new();
    public string? NextUrl { get; set; }
    public string? PreviousUrl { get; set; }
}