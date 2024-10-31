using System; // Inkluderar System-namespacet för grundläggande funktioner

namespace NummerJakten // Definierar ett namespace för spelet
{
    class Game // Definierar en klass som heter Game
    {
        private Player player = new Player(); // Skapar en instans av Player-klassen

        // Metod för att köra spelet
        public void Run() 
        {
            bool spela = true; // Variabel för att styra spel-loop
            while (spela) // Fortsätter så länge spelaren vill spela
            {
                Player.VisaMeny(); // Visar menyn för spelaren
                string? val = Console.ReadLine(); // Läser användarens val från konsolen

                // Hanterar ogiltiga val
                while (val != "1" && val != "2" && val != "3" && val != "4") // Kontrollerar om valet är ogiltigt
                {
                    Console.WriteLine("Ogiltigt val. Försök igen."); // Meddelande för ogiltigt val
                    Player.VisaMeny(); // Visar menyn igen
                    val = Console.ReadLine(); // Ber användaren ange sitt val igen
                }

                // Hanterar giltiga val
                switch (val) // Använder switch-sats för att hantera val
                {
                    case "1": // Om spelaren väljer 1
                        Player.StartaSpelet(); // Startar spelet
                        break; // Avslutar switch-satsen
                    case "2": // Om spelaren väljer 2
                        Player.VisaSenasteVinsten(); // Visar senaste vinsten
                        break; // Avslutar switch-satsen
                    case "3": // Om spelaren väljer 3
                        Player.VisaHogstaVinsten(); // Visar högsta vinsten
                        break; // Avslutar switch-satsen
                    case "4": // Om spelaren väljer 4
                        spela = false; // Sätter spela till false för att avsluta loopen
                        Console.WriteLine("Tack för att du spelade! Hej då!"); // Tackar spelaren
                        break; // Avslutar switch-satsen
                }
            }
        }
    }
}
