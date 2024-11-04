using System;

namespace NummerJakten
{
    public class KvittEllerDubbelt
    {
        public int Spela(int winnings)
        {
            Console.Clear();
            Console.WriteLine("=== Kvitt eller Dubbelt ===");
            int saldo = winnings; // Startsaldo för kvitt eller dubbelt

            while (true)
            {
                Random random = new Random();
                int currentNumber = random.Next(1, 11); // Slumpar ett tal mellan 1-10
                Console.WriteLine($"Nuvarande nummer: {currentNumber}");
                
                // Fråga om nästa nummer ska vara högre eller lägre
                Console.WriteLine("Kommer nästa nummer att vara högre eller lägre? (h/l)");
                string? guess = Console.ReadLine();

                int nextNumber = random.Next(1, 11); // Slumpar nästa nummer
                Console.WriteLine($"Det slumpade numret var: {nextNumber}");

                // Kontrollera om gissningen var korrekt
                if ((guess?.ToLower() == "h" && nextNumber > currentNumber) || (guess?.ToLower() == "l" && nextNumber < currentNumber))
                {
                    saldo *= 2; // Dubbla vinsten
                    Console.ForegroundColor = ConsoleColor.Green; // Sätt färg till grön för vinster
                    Console.WriteLine($"Grattis! Du vann! Ditt vinst är nu: {saldo} mynt.");
                    Console.ResetColor(); // Återställ färgen till standard
                }
                else
                {
                    saldo = 0; // Förlora vinsten
                    Console.ForegroundColor = ConsoleColor.Red; // Sätt färg till röd för förluster
                    Console.WriteLine($"Tyvärr, du förlorade. Din vinst är förlorad.");
                    Console.ResetColor(); // Återställ färgen till standard
                    break; // Avsluta spelet
                }

                // Fråga om spelaren vill fortsätta spela kvitt eller dubbelt
                Console.WriteLine("Vill du spela kvitt eller dubbelt igen? (j/n)");
                string? fortsattaVal = Console.ReadLine();

                if (fortsattaVal?.ToLower() != "j")
                {
                    break; // Avbryt loopen om spelaren inte vill fortsätta
                }
            }

            return saldo; // Återvända det uppdaterade saldot
        }
    }
}
