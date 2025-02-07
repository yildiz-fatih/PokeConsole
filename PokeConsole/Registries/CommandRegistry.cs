using PokeConsole.Commands.Base;

namespace PokeConsole.Registries;

public static class CommandRegistry
{
    private static readonly Dictionary<string, Command> Commands = new();

    public static void Register(Command command)
    {
        Commands.Add(command.Name, command);
    }

    public static Command? Get(string commandName)
    {
        return Commands.ContainsKey(commandName) ? Commands[commandName] : null;
    }

    public static List<Command> GetAll()
    {
        return Commands.Values.ToList();
    }
}