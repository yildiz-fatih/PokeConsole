using PokeConsole.Commands;

namespace PokeConsole;
/*
 * STEP 2: Add support for commands:
 *          help: prints a help message describing how to use the REPL
 *          exit: exits the program
 */
public class Program
{
    public static void Main()
    {
        StartPokeConsole();
    }

    private static void StartPokeConsole()
    {
        /* registers commands to the 'database of commands' (but in memory!) */
        CommandRegistry.Register(new HelpCommand());
        CommandRegistry.Register(new ExitCommand());
        
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
            
            command.Execute();
        }
    }
}