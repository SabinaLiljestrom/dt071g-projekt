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
            PrintGrid(grid);

            // Kontrollera vinstkombinationer
            int winnings = CalculateWinnings(grid, satsning);

            saldo += winnings - satsning; // Uppdaterar saldo efter vinst eller förlust
            Console.WriteLine(winnings > 0 ? $"Grattis! Du vann {winnings} mynt!" : "Tyvärr, ingen vinst.");
            Console.WriteLine($"Ditt nya saldo är {saldo} mynt.");

            return saldo;
        }

        private void PrintGrid(int[,] grid)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
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
