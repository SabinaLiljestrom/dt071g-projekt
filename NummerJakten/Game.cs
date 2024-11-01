using System; // Inkluderar System-namespacet för grundläggande funktioner

namespace NummerJakten // Definierar ett namespace för spelet
{
    class Game // Definierar en klass som heter Game
    {
        private Player player = new Player(); // Skapar en instans av Player-klassen

        // Metod för att köra spelet
        public void Run() 
{
    bool spela = true; // Variabel för att styra spel-loopen
    while (spela) // Fortsätter så länge spelaren vill spela
    {
        player.VisaMeny(); // Visar menyn för spelaren en gång i början av varje iteration
        string? val = Console.ReadLine()?.Trim(); // Läser användarens val och tar bort eventuella mellanslag

        // Hanterar ogiltiga val
        while (val != "1" && val != "2" && val != "3" && val != "4") // Kontrollerar om valet är ogiltigt
        {
            Console.WriteLine("Ogiltigt val. Försök igen."); // Visar felmeddelandet
            Console.Write("Ditt val: "); // Ber användaren att ange sitt val igen utan att visa hela menyn
            val = Console.ReadLine()?.Trim(); // Läser inmatningen igen
        }

        // Hanterar giltiga val
        switch (val) // Använder switch-sats för att hantera val
        {
            case "1": // Om spelaren väljer 1
                player.StartaSpelet(); // Använder player-instansen för att starta spelet
                break; // Avslutar switch-satsen
            case "2": // Om spelaren väljer 2
                player.VisaSenasteVinsten(); // Visar senaste vinsten med player-instansen
                break; // Avslutar switch-satsen
            case "3": // Om spelaren väljer 3
                player.VisaHogstaVinsten(); // Visar högsta vinsten med player-instansen
                break; // Avslutar switch-satsen
            case "4": // Om spelaren väljer 4
                spela = false; // Sätter spela till false för att avsluta loopen
                Console.WriteLine("Tack för att du spelade! Hej då!"); // Tackar spelaren
                break; // Avslutar switch-satsen
        }
    }
}
    }}
            