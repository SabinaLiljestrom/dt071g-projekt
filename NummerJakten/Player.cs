using System; // Inkluderar System-namespacet för grundläggande funktioner

namespace NummerJakten // Definierar ett namespace för spelet
{
    class Player // Definierar en klass som heter Player, som representerar spelaren
    {
        public int Mynt { get; private set; } // Offentlig egenskap för att lagra mängden mynt som spelaren har

        // Konstruktorn för Player-klassen. Körs när en ny instans av Player skapas
        public Player() 
        {
            Mynt = 0; // Initierar mängden mynt till 0
        }

        // Metod för att visa menyn för spelaren
        public void VisaMeny() 
        {
            Console.Clear(); // Rensar konsolen för en fräsch vy
            Console.WriteLine("=== NummerJakten ==="); // Skriver ut rubriken för spelet
            Console.WriteLine("Välj ett alternativ:"); // Ber användaren att välja ett alternativ
            Console.WriteLine("1. Starta spelet"); // Alternativ för att starta spelet
            Console.WriteLine("2. Visa senaste vinsten"); // Alternativ för att visa senaste vinsten
            Console.WriteLine("3. Visa högsta vinsten"); // Alternativ för att visa högsta vinsten
            Console.WriteLine("4. Avsluta spelet"); // Alternativ för att avsluta spelet
            Console.Write("Ditt val: "); // Ber användaren att ange sitt val
        }

        // Metod för att visa senaste vinsten
        public void VisaSenasteVinsten() 
        {
            Console.Clear(); // Rensar konsolen för en fräsch vy
            Console.WriteLine("=== Senaste Vinsten ==="); // Skriver ut rubriken för senaste vinsten
            Console.WriteLine("Ingen vinst har registrerats ännu."); // Meddelar att ingen vinst har registrerats
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn."); // Ber användaren att trycka på en tangent
            Console.ReadKey(); // Väntar på att användaren ska trycka en tangent
        }

        // Metod för att visa högsta vinsten
        public void VisaHogstaVinsten() 
        {
            Console.Clear(); // Rensar konsolen för en fräsch vy
            Console.WriteLine("=== Högsta Vinsten ==="); // Skriver ut rubriken för högsta vinsten
            Console.WriteLine("Ingen högsta vinst har registrerats ännu."); // Meddelar att ingen högsta vinst har registrerats
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn."); // Ber användaren att trycka på en tangent
            Console.ReadKey(); // Väntar på att användaren ska trycka en tangent
        }

        // Metod för att starta spelet
        public void StartaSpelet()
        {
            Console.Clear(); // Rensar konsolen för en fräsch vy
            Console.WriteLine("=== Spelet har startat ==="); // Skriver ut rubriken för spelet
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn."); // Ber användaren att trycka på en tangent
            Console.ReadKey(); // Väntar på att användaren ska trycka en tangent
        }
    }
}
