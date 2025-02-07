namespace PokeConsole.Commands.Base;

public abstract class Command
{
    public abstract string Name { get; }
    public abstract string Description { get; }
    public abstract void Execute();
}