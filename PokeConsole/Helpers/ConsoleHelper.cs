using Lolcat;

namespace PokeConsole.Helpers;

public static class ConsoleHelper
{
    private static readonly Rainbow Rainbow = new(new RainbowStyle
    {
        EscapeSequence = EscapeSequence.Spectre,
        Frequency = 0.3,
        Spread = 3.0,
        Seed = 42
    });

    public static void WriteLine(string message, bool forceColor = false)
    {
        if (AppState.IsColoredOutput || forceColor)
        {
            Rainbow.WriteLineWithMarkup(message);
        }
        else
        {
            Console.WriteLine(message);
        }
    }

    public static void Write(string message, bool forceColor = false)
    {
        if (AppState.IsColoredOutput || forceColor)
        {
            Rainbow.WriteWithMarkup(message);
        }
        else
        {
            Console.Write(message);
        }
    }
}