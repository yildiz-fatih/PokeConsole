using PokeConsole.Commands;

namespace PokeConsole;
/*
 * STEP 3: Add support for the command 'map'
 */
public class Program
{
    public static async Task Main()
    {
        await StartPokeConsole();
    }

    private static async Task StartPokeConsole()
    {
        /* registers commands to the 'database of commands' (but in memory!) */
        CommandRegistry.Register(new HelpCommand());
        CommandRegistry.Register(new ExitCommand());
        CommandRegistry.Register(new MapCommand());
        
        while (true)
        {
            Console.Write("PokeConsole > ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }
            
            var commandSplit = input.Trim().ToLower().Split(' ');
            
            var commandName = commandSplit[0];
            var command = CommandRegistry.Get(commandName);

            if (command == null)
            {
                Console.WriteLine("Unknown command!");
                Console.WriteLine("Type 'help' for a list of available commands.");
                continue;
            }
            
            await command.ExecuteAsync();
        }
    }
}