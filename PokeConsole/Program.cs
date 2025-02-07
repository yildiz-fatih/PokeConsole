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
        while (true)
        {
            Console.Write("PokeConsole > ");
            var command = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(command))
            {
                continue;
            }
            var commandSplit = command.Trim().ToLower().Split(' ');
            if (commandSplit[0] == "exit")
            {
                break;
            }
            else if (commandSplit[0] == "help")
            {
                Console.WriteLine("Welcome to PokeConsole!");
                Console.WriteLine("Usage:");
                Console.WriteLine("help: Displays a help message");
                Console.WriteLine("exit: Exit PokeConsole");
            }
            else
            {
                Console.WriteLine($"Unknown command: {command}");
            }
        }
    }
}