using PokeConsole.Commands;
using PokeConsole.Registries;

namespace PokeConsole;

public class Program
{
    public static async Task Main()
    {
        await StartPokeConsole();
    }

    private static async Task StartPokeConsole()
    {
        RegisterCommands();
        PrintWelcomeMessage();
        
        while (true)
        {
            Console.Write("PokeConsole > ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }
            
            var args = input.Trim().ToLower().Split(' ');
            
            var commandName = args[0];
            var command = CommandRegistry.Get(commandName);

            if (command == null)
            {
                Console.WriteLine("Unknown command!\n" +
                                  "Type 'help' for a list of available commands.");
                continue;
            }
            
            await command.ExecuteAsync(args);
        }
    }

    private static void PrintWelcomeMessage()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n" +
                          "  Welcome to PokeConsole!\n" +
                          "  Type 'help' for commands.\n" +
                          "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    }

    /* registers commands to the 'database of commands' (but in memory!) */
    private static void RegisterCommands()
    {
        CommandRegistry.Register(new PokeconsoleCommand());
        CommandRegistry.Register(new HelpCommand());
        CommandRegistry.Register(new ExitCommand());
        CommandRegistry.Register(new MapCommand());
        CommandRegistry.Register(new MapBackCommand());
        CommandRegistry.Register(new ExploreCommand());
        CommandRegistry.Register(new CatchCommand());
        CommandRegistry.Register(new InspectCommand());
    }


}