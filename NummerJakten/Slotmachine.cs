using System;

namespace NummerJakten
{
    class SlotMachine
    {
        private static readonly Random random = new Random();

        public int Play(int satsning, int saldo)
        {
            int[,] grid = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = random.Next(0, 10); // Genererar slumpmässiga siffror mellan 0 och 9
                }
            }

            Console.Clear();
            Console.WriteLine("=== Nummer Jakten ===");
            PrintGrid(grid); // Skriver ut spelplanen

            // Kontrollera vinstkombinationer
            int winnings = CalculateWinnings(grid, satsning);

            saldo += winnings - satsning; // Uppdaterar saldo efter vinst eller förlust
         if (winnings > 0)
{
    Console.ForegroundColor = ConsoleColor.Green; // Sätt färg till grön för vinster
    Console.WriteLine($"Grattis! Du vann {winnings} mynt!");
}
else
{
    Console.ForegroundColor = ConsoleColor.Red; // Sätt färg till röd för förluster
    Console.WriteLine("Tyvärr, ingen vinst.");
}

Console.ResetColor(); // Återställ till standardfärger
            return saldo;
        }

        private void PrintGrid(int[,] grid)
        {
            Console.WriteLine("┌───┬───┬───┐"); // Översta ramen

            // Skriv ut den första raden med vertikala streck
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"│ {grid[0, j]} "); // Skriv ut siffran med utrymme
            }
            Console.WriteLine("│"); // Avsluta raden

            Console.WriteLine("├───┼───┼───┤"); // Linje mellan raderna

            // Skriv ut den andra raden med vertikala streck
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"│ {grid[1, j]} "); // Skriv ut siffran med utrymme
            }
            Console.WriteLine("│"); // Avsluta raden

            Console.WriteLine("├───┼───┼───┤"); // Linje mellan raderna

            // Skriv ut den tredje raden med vertikala streck
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"│ {grid[2, j]} "); // Skriv ut siffran med utrymme
            }
            Console.WriteLine("│"); // Avsluta raden

            Console.WriteLine("└───┴───┴───┘"); // Nedersta ramen
        }

        private int CalculateWinnings(int[,] grid, int satsning)
        {
            int winnings = 0;

            // Kontroll för mitten
            if (grid[1, 1] == grid[0, 0] && grid[1, 1] == grid[2, 2]) winnings += satsning * 5;

            // Kontroll för tre lika på övre raden
            if (grid[0, 0] == grid[0, 1] && grid[0, 1] == grid[0, 2]) winnings += satsning * 2;

            // Kontroll för tre lika på nedre raden
            if (grid[2, 0] == grid[2, 1] && grid[2, 1] == grid[2, 2]) winnings += satsning * 2;

            // Kontroll för fyra lika i hörnen
            if (grid[0, 0] == grid[0, 2] && grid[0, 2] == grid[2, 0] && grid[2, 0] == grid[2, 2]) winnings += (int)(satsning * 0.5);

            // Kontroll för lika på båda diagonalerna
            if ((grid[0, 0] == grid[1, 1] && grid[1, 1] == grid[2, 2]) ||
                (grid[0, 2] == grid[1, 1] && grid[1, 1] == grid[2, 0]))
            {
                winnings += satsning;
            }

            return winnings;
        }
    }
}
