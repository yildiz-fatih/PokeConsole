# PokeConsole

A simple "Pokedex" clone console application in C#

## Installation & Running

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or newer

### Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/yildiz-fatih/PokeConsole.git
   ```
2. Navigate to project directory:
   ```bash
   cd PokeConsole
   ```
3. Run the application:
   ```bash
   dotnet run
   ```

## Available Commands

- **`help`** - Show available commands  
  Example: `help`

- **`exit`** - Exit the application  
  Example: `exit`

- **`map`** - Show next 20 location areas (paginated results)  
  Example: `map`

- **`mapb`** - Show previous 20 location areas (paginated results)  
  Example: `mapb`

- **`explore <location>`** - Show Pokemon in location area  
  Example: `explore forest`

- **`catch <pokemon>`** - Attempt to catch a Pokemon  
  Example: `catch pikachu`

- **`inspect <pokemon>`** - Show caught Pokemon details  
  Example: `inspect charizard`

- **`pokeconsole`** - Show all Pokemon in your PokeConsole  
  Example: `pokeconsole`