using System.Data.SQLite; // Inkluderar nödvändiga paket för att arbeta med SQLite-databaser

namespace NummerJakten 
{
    public class DatabaseHelper // Definierar en klass som hanterar databasoperationer
    {
        private const string DbFilePath = "nummerjakten.db"; // Definierar sökvägen för databasfilen

        public DatabaseHelper() // Konstruktorn för DatabaseHelper-klassen
        {
            // Anropar metoden för att kontrollera och initiera databasen och tabeller
            InitializeDatabase();
        }

        private void InitializeDatabase() // Metod för att skapa databasen och dess tabeller om de inte redan finns
        {
            // Skapar databasen om filen inte existerar
            if (!File.Exists(DbFilePath))
            {
                SQLiteConnection.CreateFile(DbFilePath); // Skapar en ny databasfil
            }

            // Skapar en ny SQLite-anslutning till databasen
            using (var connection = new SQLiteConnection($"Data Source={DbFilePath};Version=3;"))
            {
                connection.Open(); // Öppnar anslutningen till databasen
                // SQL-fråga för att skapa tabellen om den inte redan finns
                string createTableQuery = @"CREATE TABLE IF NOT EXISTS Scores (
                                                Id INTEGER PRIMARY KEY AUTOINCREMENT, // Automatisk ID-ökning för varje post
                                                LatestWin INTEGER, // Kolumn för att lagra senaste vinsten
                                                HighestWin INTEGER // Kolumn för att lagra högsta vinsten
                                            )";
                // Använder SQLiteCommand för att köra SQL-frågan
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery(); // Exekverar SQL-frågan utan att returnera något resultat
                }

                // Kontrollera om det redan finns data i tabellen
                string checkDataQuery = "SELECT COUNT(*) FROM Scores"; // SQL-fråga för att räkna antalet poster
                using (var command = new SQLiteCommand(checkDataQuery, connection))
                {
                    long count = (long)command.ExecuteScalar(); // Hämtar antalet poster
                    if (count == 0) // Om tabellen är tom
                    {
                        // Infogar en standardpost med nollvinster
                        string insertInitialData = "INSERT INTO Scores (LatestWin, HighestWin) VALUES (0, 0)";
                        using (var insertCommand = new SQLiteCommand(insertInitialData, connection))
                        {
                            insertCommand.ExecuteNonQuery(); // Exekverar infogningsfrågan
                        }
                    }
                }
            }
        }

        public void SaveLatestWin(int latestWin) // Metod för att spara senaste vinsten i databasen
        {
            // Skapar en ny SQLite-anslutning
            using (var connection = new SQLiteConnection($"Data Source={DbFilePath};Version=3;"))
            {
                connection.Open(); // Öppnar anslutningen till databasen
                // SQL-fråga för att uppdatera senaste vinsten
                string updateQuery = "UPDATE Scores SET LatestWin = @LatestWin WHERE Id = 1";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@LatestWin", latestWin); // Lägger till parametervärdet
                    command.ExecuteNonQuery(); // Exekverar uppdateringsfrågan
                }
            }
        }

        public void SaveHighestWin(int highestWin) // Metod för att spara högsta vinsten i databasen
        {
            // Skapar en ny SQLite-anslutning
            using (var connection = new SQLiteConnection($"Data Source={DbFilePath};Version=3;"))
            {
                connection.Open(); // Öppnar anslutningen till databasen
                // SQL-fråga för att uppdatera högsta vinsten
                string updateQuery = "UPDATE Scores SET HighestWin = @HighestWin WHERE Id = 1";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@HighestWin", highestWin); // Lägger till parametervärdet
                    command.ExecuteNonQuery(); // Exekverar uppdateringsfrågan
                }
            }
        }

        public int LoadLatestWin() // Metod för att hämta senaste vinsten från databasen
        {
            // Skapar en ny SQLite-anslutning
            using (var connection = new SQLiteConnection($"Data Source={DbFilePath};Version=3;"))
            {
                connection.Open(); // Öppnar anslutningen till databasen
                // SQL-fråga för att hämta senaste vinsten
                string query = "SELECT LatestWin FROM Scores WHERE Id = 1";
                using (var command = new SQLiteCommand(query, connection))
                {
                    var result = command.ExecuteScalar(); // Exekverar frågan och hämtar resultatet
                    return result != null ? Convert.ToInt32(result) : 0; // Returnera resultatet som int eller 0 om null
                }
            }
        }

        public int LoadHighestWin() // Metod för att hämta högsta vinsten från databasen
        {
            // Skapar en ny SQLite-anslutning
            using (var connection = new SQLiteConnection($"Data Source={DbFilePath};Version=3;"))
            {
                connection.Open(); // Öppnar anslutningen till databasen
                // SQL-fråga för att hämta högsta vinsten
                string query = "SELECT HighestWin FROM Scores WHERE Id = 1";
                using (var command = new SQLiteCommand(query, connection))
                {
                    var result = command.ExecuteScalar(); // Exekverar frågan och hämtar resultatet
                    return result != null ? Convert.ToInt32(result) : 0; // Returnera resultatet som int eller 0 om null
                }
            }
        }
    }
}
