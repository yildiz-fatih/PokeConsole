using PokeConsole.Commands.Base;
using PokeConsole.Helpers;

namespace PokeConsole.Commands;

public class RainbowCommand : Command
{
    public override string Name { get; } = "rainbow";
    public override string Description { get; } = "Toggle colored output";
    public override Task ExecuteAsync(params string[] args)
    {
        AppState.IsColoredOutput = !AppState.IsColoredOutput;
        var status = AppState.IsColoredOutput ? "ENABLED 🌈" : "DISABLED 👋";
        ConsoleHelper.WriteLine($"Colored output {status}!");
        
        return Task.CompletedTask;

    }
}