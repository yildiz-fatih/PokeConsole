using PokeConsole.Commands.Base;

namespace PokeConsole.Commands;

public class HelpCommand : Command
{
    public override string Name { get; } = "help";
    public override string Description { get; } = "Displays all available commands";
    public override Task ExecuteAsync(params string[] args)
    {
        Console.WriteLine("Welcome to PokeConsole!");
        Console.WriteLine("Usage:");

        var commands = CommandRegistry.GetAll();

        foreach (var command in commands)
        {
            Console.WriteLine($"{command.Name}: {command.Description}");
        }
        
        return Task.CompletedTask;
    }
}