using System; // Inkluderar System-namespacet för grundläggande funktioner

namespace NummerJakten // Definierar ett namespace för spelet
{
    class Player // Definierar en klass som heter Player, som representerar spelaren
    {
        public int Mynt { get; private set; } // Offentlig egenskap för att lagra mängden mynt som spelaren har
        public int SenasteVinsten { get; private set; } // Offentlig egenskap för att lagra senaste vinsten
        public int HogstaVinsten { get; private set; }
        private DatabaseHelper dbHelper = new DatabaseHelper(); // Skapar instans av DatabaseHelper

        public Player() 
        {
            // Laddar tidigare vinster från databasen
            SenasteVinsten = dbHelper.LoadLatestWin();
            HogstaVinsten = dbHelper.LoadHighestWin();
            Mynt = 0;
        }

        // Metod för att visa menyn för spelaren
        public void VisaMeny() 
        {
            Console.Clear(); // Rensar konsolen för en fräsch vy
            Console.WriteLine("=== NummerJakten ===");
            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("1. Starta spelet");
            Console.WriteLine("2. Visa senaste vinsten");
            Console.WriteLine("3. Visa högsta vinsten");
            Console.WriteLine("4. Avsluta spelet");
            Console.Write("Ditt val: ");
        }

        public void UppdateraSenasteVinsten(int vinst)
        {
            SenasteVinsten = vinst;
            dbHelper.SaveLatestWin(vinst); // Sparar senaste vinsten i databasen

            // Uppdatera högsta vinsten om den nya vinsten är högre
            if (vinst > HogstaVinsten)
            {
                HogstaVinsten = vinst;
                dbHelper.SaveHighestWin(vinst); // Sparar högsta vinsten i databasen
            }
        }

        public void VisaSenasteVinsten() 
        {
            Console.Clear();
            Console.WriteLine("=== Senaste Vinsten ===");
            Console.WriteLine(SenasteVinsten > 0 ? $"Din senaste vinst är {SenasteVinsten} mynt." : "Ingen vinst har registrerats ännu.");
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
            Console.ReadKey();
        }

        public void VisaHogstaVinsten() 
        {
            Console.Clear();
            Console.WriteLine("=== Högsta Vinsten ===");
            Console.WriteLine(HogstaVinsten > 0 ? $"Din högsta vinst är {HogstaVinsten} mynt." : "Ingen högsta vinst har registrerats ännu.");
            Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
            Console.ReadKey();
        }

      public void FortsaettSpela(SlotMachine slotMachine)
{
    while (Mynt > 0) // Kontrollera om spelaren har mynt kvar
    {
        int satsning = 0;
        bool giltigSatsning = false;

        while (!giltigSatsning)
        {
            Console.WriteLine($"Hur många mynt vill du satsa? (Du har {Mynt} mynt tillgängliga)");
            string? inputSatsning = Console.ReadLine();

            // Kontrollera om inmatningen är giltig
            if (int.TryParse(inputSatsning, out satsning) && satsning > 0 && satsning <= Mynt)
            {
                giltigSatsning = true;
                Console.WriteLine($"Du har satsat {satsning} mynt.");
            }
            else
            {
                Console.WriteLine("Ogiltig satsning. Ange ett positivt heltal som inte överstiger dina tillgängliga mynt.");
            }
        }

        // Anropa spelmaskinen för att spela en ny runda
        var (nyttSaldo, winnings) = slotMachine.Play(satsning, Mynt);
        UppdateraSenasteVinsten(winnings);
        Mynt = nyttSaldo; // Uppdatera saldo

        // Visa det nya saldot
        Console.WriteLine($"Ditt nya saldo är: {Mynt} mynt.");

        // Kontrollera om spelaren vann något
        if (winnings > 0)
        {
            Console.WriteLine($"Du vann {winnings} mynt! Vill du spela 'kvitt eller dubbelt' med din vinst? (j/n)");
            string? val = Console.ReadLine();

            if (val?.ToLower() == "j")
            {
                // Skapa instans av KvittEllerDubbelt och spela
                KvittEllerDubbelt kvittEllerDubbelt = new KvittEllerDubbelt();
                Mynt += kvittEllerDubbelt.Spela(winnings); // Uppdatera spelarens saldo
                Console.WriteLine($"Ditt nya saldo efter 'kvitt eller dubbelt' är: {Mynt} mynt.");
            }
        }

        if (Mynt <= 0)
        {
            Console.WriteLine("Du har inga mynt kvar! Vänligen återvänd till menyn.");
            break; // Avbryt loopen om spelaren inte har några mynt kvar
        }

      string? fortsattaVal;
while (true)
{
    Console.WriteLine("Vill du fortsätta spela? (j/n)");
    fortsattaVal = Console.ReadLine()?.ToLower();

    if (fortsattaVal == "j")
    {
        // Om spelaren vill fortsätta, bryt ur loopen och fortsätt spelet
        break;
    }
    else if (fortsattaVal == "n")
    {
        // Om spelaren inte vill fortsätta, avsluta funktionen och spelet
        Console.WriteLine("Spelet är slut. Tack för att du spelade!");
        Console.ReadKey(); // Väntar på att användaren ska trycka på en tangent innan programmet avslutas
        return; // Avslutar metoden för att återgå till huvudmenyn eller avsluta spelet
    }
    else
    {
        // Felmeddelande om inmatningen är ogiltig
        Console.WriteLine("Ogiltigt alternativ. Vänligen välj 'j' för att fortsätta eller 'n' för att avsluta.");
    }
}
    }
    Console.WriteLine("Tryck på valfri tangent för att återgå till menyn.");
    Console.ReadKey();
}

        public void StartaSpelet(SlotMachine slotMachine)
        {
            // Fråga efter spelarens namn
            Console.Clear();
            Console.WriteLine("Ange ditt namn: ");
            string? namn = Console.ReadLine();

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
                    Mynt = totalMynt; // Sätt antalet mynt till spelarens saldo
                    Console.WriteLine($"Du har lagt in {totalMynt} mynt.");
                }
                else
                {
                    Console.WriteLine("Ogiltigt antal. Ange ett positivt heltal för mynt.");
                }
            }

            // Spela spelet
            FortsaettSpela(slotMachine);
        }
    }
}
