namespace PokeConsole;
/*
 * STEP 1: Build the basic app:
 *          a loop that parses and cleans an input and prints the first word back to the user
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
            var commandSplit = command.Trim().ToLower().Split(' ');
            Console.WriteLine("Your command was: " + commandSplit[0]);
        }
    }
}