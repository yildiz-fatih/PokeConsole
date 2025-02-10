using PokeConsole.Commands.Base;
using PokeConsole.Helpers;
using PokeConsole.Registries;

namespace PokeConsole.Commands;

public class HelpCommand : Command
{
    public override string Name { get; } = "help";
    public override string Description { get; } = "Show available commands";
    public override Task ExecuteAsync(params string[] args)
    {
        ConsoleHelper.WriteLine("Available Commands:");

        var commands = CommandRegistry.GetAll();

        foreach (var command in commands)
        {
            ConsoleHelper.WriteLine($"- {command.Name}: {command.Description}");
        }
        
        return Task.CompletedTask;
    }
}