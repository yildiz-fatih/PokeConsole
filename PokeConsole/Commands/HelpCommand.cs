using PokeConsole.Commands.Base;
using PokeConsole.Registries;

namespace PokeConsole.Commands;

public class HelpCommand : Command
{
    public override string Name { get; } = "help";
    public override string Description { get; } = "Show available commands";
    public override Task ExecuteAsync(params string[] args)
    {
        Console.WriteLine("Available Commands:");

        var commands = CommandRegistry.GetAll();

        foreach (var command in commands)
        {
            Console.WriteLine($"- {command.Name}: {command.Description}");
        }
        
        return Task.CompletedTask;
    }
}