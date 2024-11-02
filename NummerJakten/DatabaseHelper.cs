using System.Data.SQLite; //  Inkluderar nödvändigt paket för databas

namespace NummerJakten
{
    public class DatabaseHelper  // Definierar en klass som hanterar databasoperationer
    {
        private const string DbFilePath = "nummerjakten.db"; // Definierar databassökvägen

        public DatabaseHelper()  // Konstruktorn för DatabaseHelper-klassen
        {
            // Kontrollera och skapa databasen och tabellen om de inte finns
            InitializeDatabase();
        }

        private void InitializeDatabase() // Metod för att skapa databasen och dess tabeller om de inte redan finns
        {
            // Skapar databasen om filen inte finns
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
                                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                                LatestWin INTEGER,
                                                HighestWin INTEGER
                                            )";
                 // Använder SQLiteCommand för att köra SQL-frågan
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();  // Exekverar SQL-frågan utan att returnera något resultat
                }

                // Kontrollera om någon post redan finns, annars lägg till en standardpost
                string checkDataQuery = "SELECT COUNT(*) FROM Scores";  // SQL-fråga för att räkna antalet poster
                using (var command = new SQLiteCommand(checkDataQuery, connection))
                {
                    long count = (long)command.ExecuteScalar();  // Hämtar antalet poster
                    if (count == 0)  // Om tabellen är tom
                    {
                          // Infogar en standardpost med nollvinster
                        string insertInitialData = "INSERT INTO Scores (LatestWin, HighestWin) VALUES (0, 0)";
                        using (var insertCommand = new SQLiteCommand(insertInitialData, connection))
                        {
                            insertCommand.ExecuteNonQuery();  // Exekverar infogningsfrågan
                        }
                    }
                }
            }
        }

        public void SaveLatestWin(int latestWin)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbFilePath};Version=3;"))
            {
                connection.Open();
                string updateQuery = "UPDATE Scores SET LatestWin = @LatestWin WHERE Id = 1";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@LatestWin", latestWin);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void SaveHighestWin(int highestWin)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbFilePath};Version=3;"))
            {
                connection.Open();
                string updateQuery = "UPDATE Scores SET HighestWin = @HighestWin WHERE Id = 1";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@HighestWin", highestWin);
                    command.ExecuteNonQuery();
                }
            }
        }

        public int LoadLatestWin()
        {
            using (var connection = new SQLiteConnection($"Data Source={DbFilePath};Version=3;"))
            {
                connection.Open();
                string query = "SELECT LatestWin FROM Scores WHERE Id = 1";
                using (var command = new SQLiteCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }

        public int LoadHighestWin()
        {
            using (var connection = new SQLiteConnection($"Data Source={DbFilePath};Version=3;"))
            {
                connection.Open();
                string query = "SELECT HighestWin FROM Scores WHERE Id = 1";
                using (var command = new SQLiteCommand(query, connection))
                {
                    var result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }
    }
}