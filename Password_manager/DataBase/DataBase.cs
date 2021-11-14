using System.Data.SQLite;
using System.IO;

namespace Password_manager
{


    public class DataBase
    {
        //Publiczna zmienna operująca połączeniem z bazą
        public SQLiteConnection sqlConnection;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public DataBase()
        {


            //Jeśli baza database.db nie istnieje...
            if (!File.Exists("./database.db"))
            {

                //Utwórz plik database.db
                SQLiteConnection.CreateFile("database.db");

                //Utwórz połączenie z bazą database.db
                SQLiteConnection sqlConnection2 = new("Data Source=database.db");

                //Query do SQL aby stworzyć tabelę Web (defaultową)
                string sql = @"CREATE TABLE Web (
                                                Id    INTEGER NOT NULL UNIQUE,
                                                Url   TEXT NOT NULL,
	                                            Login TEXT NOT NULL,
	                                            Password  TEXT NOT NULL,
	                                            Email TEXT,
	                                            PRIMARY KEY(Id AUTOINCREMENT
                                                ));
                                CREATE TABLE App (
                                                Id    INTEGER NOT NULL UNIQUE,
                                                Name   TEXT NOT NULL,
	                                            Login TEXT NOT NULL,
	                                            Password  TEXT NOT NULL,
	                                            Email TEXT,
	                                            PRIMARY KEY(Id AUTOINCREMENT
                                                ));	";
                //Połączenia z bazą 
                sqlConnection2.Open();
                //Wprowadzenie Komendy na tworzenie tabeli (komenda, baza)
                var cmd = new SQLiteCommand(sql, sqlConnection2);
                //Wykonanie komendy
                cmd.ExecuteNonQuery();

                //Zamknięcie połączenia. 
                sqlConnection2.Close();

            }

            //Połączenia z bazą (database.db)
            sqlConnection = new SQLiteConnection("Data Source=database.db");


        }

        /// <summary>
        /// Wczytanie bazy danych
        /// </summary>
        public void DataBaseLoad()
        {
            //Jeśli baza istnieje
            if (File.Exists("./database.db"))
            {
                //Odszyfruj.
                DecryptionAndEncryption decryptionAndEncryption = new();
                decryptionAndEncryption.Encrypt("./database.db");
            }
            //Utworzenie obiektu bazy.   
            DataBase databaseObject = new();
            //Utowrzenie obiektu do zarządzania komendami SQL
            DataBaseManipulation dataBaseManipulation = new();
            //Pobranie danych z bazy.
            dataBaseManipulation.LoadDataFormBase(databaseObject, "Web");
        }

    }
}
