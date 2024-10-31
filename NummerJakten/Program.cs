using System;

namespace NummerJakten
{
    // Program-klassen är startpunkten för applikationen
    class Program
    {
        // Main-metoden körs när programmet startas
        static void Main(string[] args)
        {
            // Skapa en instans av Game-klassen
            Game game = new Game();
            // Anropa Run-metoden för att starta spelet
            game.Run();
        }
    }
}