using PokeConsole.Commands.Base;

namespace PokeConsole.Commands;

public class ExitCommand : Command
{
    public override string Name { get; } = "exit";
    public override string Description { get; } = "Exits PokeConsole";
    public override void Execute()
    {
        Console.WriteLine("Closing PokeConsole... Goodbye!");
        Environment.Exit(0);
    }
}