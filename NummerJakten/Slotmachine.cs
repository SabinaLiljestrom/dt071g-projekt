using System;

namespace NummerJakten
{
    class SlotMachine
    {
        private static readonly Random random = new Random();
        private int omgangsnummer = 0; // Räknar antalet spelomgångar

        public (int saldo, int winnings) Play(int satsning, int saldo)
        {
            // Öka omgångsnumret vid varje spelomgång
            omgangsnummer++;

            int[,] grid;

            // Sätt en högre chans att vinna i början eller med låg balans
    double vinstchans = (omgangsnummer <= 5 || saldo < 5) ? 0.7 : 0.3;

    // Kontrollera om vi ska generera ett vinnande rutnät baserat på vinstchansen
    if (random.NextDouble() < vinstchans)
            {
                grid = GenereraVinnandeRutnat();
            }
            else
            {
                // Generera slumpmässigt rutnät
                grid = new int[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        grid[i, j] = random.Next(0, 10); // Slumpmässiga siffror mellan 0 och 9
                    }
                }
            }

            Console.Clear();
            Console.WriteLine("=== Nummer Jakten ===");
            PrintGrid(grid); // Skriver ut spelplanen

            // Kontrollera vinstkombinationer
            int winnings = CalculateWinnings(grid, satsning);

            // Uppdaterar saldo efter vinst eller förlust
            saldo += winnings - satsning;

            if (winnings > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green; // Grön färg för vinster
                Console.WriteLine($"Grattis! Du vann {winnings} mynt!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; // Röd färg för förluster
                Console.WriteLine("Tyvärr, ingen vinst.");
            }

            Console.ResetColor(); // Återställ standardfärger
            return (saldo, winnings);
        }

        private int[,] GenereraVinnandeRutnat()
{
    int[,] grid = new int[3, 3];
    int vinnandeNummer = random.Next(0, 10);

    // Slumpa vilken typ av vinstkombination som ska skapas
    int vinstTyp = random.Next(0, 5);

    switch (vinstTyp)
    {
        case 0: // Tre lika på övre raden
            grid[0, 0] = vinnandeNummer;
            grid[0, 1] = vinnandeNummer;
            grid[0, 2] = vinnandeNummer;
            break;
        case 1: // Tre lika på mittenraden
            grid[1, 0] = vinnandeNummer;
            grid[1, 1] = vinnandeNummer;
            grid[1, 2] = vinnandeNummer;
            break;
        case 2: // Tre lika på nedre raden
            grid[2, 0] = vinnandeNummer;
            grid[2, 1] = vinnandeNummer;
            grid[2, 2] = vinnandeNummer;
            break;
        case 3: // Diagonal från vänster upp till höger ned
            grid[0, 0] = vinnandeNummer;
            grid[1, 1] = vinnandeNummer;
            grid[2, 2] = vinnandeNummer;
            break;
        case 4: // Diagonal från höger upp till vänster ned
            grid[0, 2] = vinnandeNummer;
            grid[1, 1] = vinnandeNummer;
            grid[2, 0] = vinnandeNummer;
            break;
    }

    // Fyll resterande positioner med slumpmässiga nummer
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (grid[i, j] == 0) // Endast om positionen inte redan är ifylld
            {
                grid[i, j] = random.Next(0, 10);
            }
        }
    }

    return grid;
}


        private void PrintGrid(int[,] grid)
        {
            Console.WriteLine("┌───┬───┬───┐"); // Översta ramen

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"│ {grid[i, j]} "); // Skriv ut siffran med utrymme
                }
                Console.WriteLine("│");

                if (i < 2)
                {
                    Console.WriteLine("├───┼───┼───┤"); // Linje mellan raderna
                }
            }

            Console.WriteLine("└───┴───┴───┘"); // Nedersta ramen
        }

        private int CalculateWinnings(int[,] grid, int satsning)
        {
             int winnings = 0;

    // Kontrollera tre lika på varje rad
    if (grid[0, 0] == grid[0, 1] && grid[0, 1] == grid[0, 2])
        winnings += satsning * 5;
    if (grid[1, 0] == grid[1, 1] && grid[1, 1] == grid[1, 2])
        winnings += satsning * 5;
    if (grid[2, 0] == grid[2, 1] && grid[2, 1] == grid[2, 2])
        winnings += satsning * 5;

    // Kontrollera diagonaler
    if (grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2])
        winnings += satsning * 10;
    if (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0])
        winnings += satsning * 10;

    // Kontrollera hörn
    if (grid[0, 0] == grid[0, 2] && grid[0, 2] == grid[2, 0] && grid[2, 0] == grid[2, 2])
        winnings += (int)(satsning * 0.5);

            return winnings;
        }
    }
}
