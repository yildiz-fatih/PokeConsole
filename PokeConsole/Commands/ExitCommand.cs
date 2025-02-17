using PokeConsole.Commands.Base;
using PokeConsole.Helpers;

namespace PokeConsole.Commands;

public class ExitCommand : Command
{
    public override string Name { get; } = "exit";
    public override string Description { get; } = "Exit the application";
    public override Task ExecuteAsync(params string[] args)
    {
        ConsoleHelper.WriteLine("Closing PokeConsole... Goodbye!");
        Environment.Exit(0);
        
        return Task.CompletedTask;
    }
}