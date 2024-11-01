using System; // Inkluderar System-namespacet för grundläggande funktioner

namespace NummerJakten // Definierar ett namespace för spelet
{
    class Player // Definierar en klass som heter Player, som representerar spelaren
    {
        public int Mynt { get; private set; } // Offentlig egenskap för att lagra mängden mynt som spelaren har
         public int SenasteVinsten { get; private set; } // Offentlig egenskap för att lagra senaste vinsten

        // Konstruktorn för Player-klassen. Körs när en ny instans av Player skapas
        public Player() 
        {
            Mynt = 0; // Initierar mängden mynt till 0
            SenasteVinsten = 0; // Initierar senaste vinsten till 0
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
         // Metod för att uppdatera senaste vinsten
          public void UppdateraSenasteVinsten(int vinst)
           {
              SenasteVinsten = vinst; // Spara vinsten
            }
        // Metod för att visa senaste vinsten
        public void VisaSenasteVinsten() 
        {
            Console.Clear(); // Rensar konsolen för en fräsch vy
            Console.WriteLine("=== Senaste Vinsten ==="); // Skriver ut rubriken för senaste vinsten
            Console.WriteLine(SenasteVinsten > 0 ? $"Din senaste vinst är {SenasteVinsten} mynt." : "Ingen vinst har registrerats ännu."); // Visa senaste vinsten
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
      public void StartaSpelet(SlotMachine slotMachine)
{
    // Fråga efter spelarens namn
    Console.Clear();
    Console.WriteLine("Ange ditt namn: ");
    string? namn = Console.ReadLine(); // Läser in spelarens namn

    // Rensar konsolen och frågar hur många mynt spelaren vill lägga in
    Console.Clear();
    Console.WriteLine($"Välkommen, {namn}!");

    // Fråga om antal mynt att lägga in
    int totalMynt = 0;
    bool giltigtTotalMynt = false;

    while (!giltigtTotalMynt)
    {
        Console.WriteLine("Hur många mynt vill du lägga in?");
        string? inputTotalMynt = Console.ReadLine();

        // Kontrollera om inmatningen är ett giltigt heltal
        if (int.TryParse(inputTotalMynt, out totalMynt) && totalMynt > 0)
        {
            giltigtTotalMynt = true;
            Console.WriteLine($"Du har lagt in {totalMynt} mynt.");
        }
        else
        {
            Console.WriteLine("Ogiltigt antal. Ange ett positivt heltal för mynt.");
        }
    }

    // Rensar konsolen och frågar om antal mynt att satsa
    Console.Clear();
    int satsning = 0;
    bool giltigSatsning = false;

    while (!giltigSatsning)
    {
        Console.WriteLine($"Hur många mynt vill du satsa för den första rundan? (Du har {totalMynt} mynt tillgängliga)");
        string? inputSatsning = Console.ReadLine();

        // Kontrollera om inmatningen är ett giltigt heltal och att satsningen inte överstiger tillgängliga mynt
        if (int.TryParse(inputSatsning, out satsning) && satsning > 0 && satsning <= totalMynt)
        {
            giltigSatsning = true;
            Console.WriteLine($"Du har satsat {satsning} mynt.");
        }
        else
        {
            Console.WriteLine("Ogiltig satsning. Ange ett positivt heltal som inte överstiger dina tillgängliga mynt.");
        }
    }

    // Vänta på att spelaren trycker på valfri tangent för att börja spelet
    Console.WriteLine("Tryck på valfri tangent för att starta spelet.");
    Console.ReadKey(); // Väntar på att användaren ska trycka på en tangent

   // Anropa spelmaskinen här
    var (nyttSaldo, winnings) = slotMachine.Play(satsning, totalMynt); // Få både saldo och vinster

    // Uppdatera senaste vinsten i Player
    UppdateraSenasteVinsten(winnings);

    // Uppdatera saldo
    Mynt = nyttSaldo; // Uppdaterar saldo efter spelet
    // Visa det nya saldot efter spelet
    Console.WriteLine($"Ditt nya saldo är: {Mynt} mynt."); // Visa det nya saldot

    Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
    Console.ReadKey(); // Väntar på att användaren ska trycka på en tangent
}

}}
