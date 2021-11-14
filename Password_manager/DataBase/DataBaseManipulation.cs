using System;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Password_manager
{
    public class DataBaseManipulation
    {



        #region Main Methods
        /// <summary>
        /// Wczytanie danych z bazy.
        /// </summary>
        /// <param name="databaseObject">Obiekt bazy danych</param>
        public void LoadDataFormBase(DataBase databaseObject, string table)
        {

            //Obecne, główne okno by móc wprowadzać zmiany
            var mainWindow = ((MainWindow)Application.Current.MainWindow);
            //Usunięcie wszystkich obiektów z stackpanelu
            mainWindow.StackPanelSide.Children.Clear();
            //Komenda SQL do wczytania wszystkicha danych z danej tabeli
            var query2 = "SELECT * FROM " + table;
            //Zapisanie komendy wraz z połączeniem do bazy.
            SQLiteCommand myCommand2 = new(query2, databaseObject.sqlConnection);

            //Pobranie stanu bazy (włączona/wyłączona)
            var state = databaseObject.sqlConnection.State.ToString();

            //Jeśli baza danych jest zamknięta...
            if (state == "Closed")
                //Połącz się z bazą.
                databaseObject.sqlConnection.Open();



            //Wykonanie komendy SQL, zapisanie wyników
            SQLiteDataReader result = myCommand2.ExecuteReader();


            //Jeśli wynik ma wiersze..
            if (result.HasRows)
            {

                //Dopuki znajduje się coś w wynikach...
                while (result.Read())
                {
                    //Utworzenie nowego przycisku 
                    RadioButton radioButton = new();
                    //Dodanie do grupy "Side"
                    radioButton.GroupName = "Side";
                    //Nadanie stylu ToggleButton_Chose
                    radioButton.Style = (Style)mainWindow.Resources["ToggleButton_Chose"];
                    //Nadanie eventu Click
                    radioButton.Click += mainWindow.Button_LoadData;
                    //Nadanie tag (indywidualna nazwa) jako numer ID
                    radioButton.Tag = result["Id"];

                    //Nadanie evenutów do przesównia i usuwania.
                    radioButton.PreviewMouseDown += mainWindow.RadioButton_PreviewMouseDown;
                    radioButton.PreviewMouseMove += mainWindow.RadioButton_PreviewMouseMove;
                    radioButton.PreviewMouseUp += mainWindow.RadioButton_PreviewMouseUp;

                    //Utworzenie zmiennej string
                    var url = "";
                    //Jeśli tabela to "Web"...
                    if (table == "Web")
                    {
                        //Pobranie nazwy strony
                        url = GetWebName((string)result["Url"]);
                        //Pobieranie favicon ze strony
                        ToggleButtonProperties.SetImageSource(radioButton, new BitmapImage(new Uri("https://www." + url + "/favicon.ico")));
                    }
                    //W innym wypadku...
                    else
                    {
                        //Pobierze nazwe programu
                        url = (string)result["Name"];
                    }

                    //Ustawienie pierwszego tekstu (nazwa strony/programu)
                    ToggleButtonProperties.SetFirstText(radioButton, url);
                    //Ustawienie dugiego tekstu (login)
                    ToggleButtonProperties.SetSecondText(radioButton, (string)result["Login"]);


                    //Dodanie przyckisku do stackpanelu 
                    mainWindow.StackPanelSide.Children.Add(radioButton);




                }
            }
            //Zamknięcie połączenia z bazą
            databaseObject.sqlConnection.Close();

        }

        /// <summary>
        ///Wprowadzanie danych do bazy
        /// </summary>
        /// <param name="url">Nazwa strony/programu</param>
        /// <param name="login">Nazwa użytkownika</param>
        /// <param name="password">Hasło</param>
        /// <param name="email">E-mail</param>
        /// <param name="table">Tabela</param>
        public void AddRecords(string url, string login, string password, string email, string table)
        {
            //Utworzenie obiektu bazy
            DataBase databaseObject = new DataBase();

            string query = "";

            //Jeśli tabela to "Web"...
            if (table == "Web")
                //Komenda SQL do wprowadzania danych do tabeli "Web"
                query = "INSERT INTO " + table + " (`Url`,`Login`,`Password`,`Email`) VALUES (@url,@login,@password,@email)";
            else
                //Komenda SQL do wprowadzania danych do tabeli "App"
                query = "INSERT INTO " + table + " (`Name`,`Login`,`Password`,`Email`) VALUES (@name,@login,@password,@email)";

            //Zapisanie komendy wraz z połączeniem do bazy.
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.sqlConnection);
            //Połączenie się z bazą.
            databaseObject.sqlConnection.Open();
            //Jeśli tabela to "Web"...
            if (table == "Web")
                //Dodaj nazwe strony
                myCommand.Parameters.AddWithValue("@url", url);
            //W innym wypadku...
            else
                //Dodaj nazwe programu
                myCommand.Parameters.AddWithValue("@name", url);

            //Dodanie pozostałych parametrów
            myCommand.Parameters.AddWithValue("@login", login);
            myCommand.Parameters.AddWithValue("@password", password);
            myCommand.Parameters.AddWithValue("@email", email);

            //Wykonanie komendy
            myCommand.ExecuteNonQuery();

            //Zamknięcie połączenia
            myCommand.Connection.Close();

            //Wczytanie informacji z bazy
            LoadDataFormBase(databaseObject, table);
        }

        /// <summary>
        /// Usunięcie danych z bazy
        /// </summary>
        /// <param name="tag">Unikalna nazwa zmiennej (id)</param>
        /// <param name="table">Tabela</param>
        public void DeleteRecords(string tag, string table)
        {
            //Utworzenie obiektu bazy
            DataBase databaseObjects = new DataBase();

            //Komenda SQL do usunięcia record'u o danym numerze ID
            string query = "DELETE FROM " + table + " WHERE id = @id";

            //Zapisanie komendy wraz z połączeniem do bazy
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObjects.sqlConnection);

            //Połączenie z bazą
            databaseObjects.sqlConnection.Open();

            //Wprowadzenie unikalnej zmiennej 
            myCommand.Parameters.AddWithValue("@id", tag);
            //Wykonanie komendy
            myCommand.ExecuteNonQuery();

            //Zamknięcie połączenia
            myCommand.Connection.Close();
            //Wczytanie danych z bazy
            LoadDataFormBase(databaseObjects, table);
        }

        /// <summary>
        /// Wygenerowanie całego wiersza o danym numerze Id
        /// </summary>
        /// <param name="id">Unikalna zmienna (ID)</param>
        /// <returns>Cały wiersz danych </returns>
        public SQLiteDataReader SelectRecord(DataBase databaseObject,string id, string table)
        {
            
            //Komenda SQL wyszukująca wiersz o danym numerze ID
            var query2 = "SELECT * FROM " + table + " WHERE id = @id";
            //Zapisanie komendy wraz z połączeniem do bazy
            SQLiteCommand myCommand2 = new(query2, databaseObject.sqlConnection);

            //Sprawdzenie czy jest już połączenie
            var state = databaseObject.sqlConnection.State.ToString();

            //Jęśli nie ma połączenia...
            if (state == "Closed")
                //Połącz z bazą
                databaseObject.sqlConnection.Open();

            // Wprowadzenie unikalnej zmiennej
            myCommand2.Parameters.AddWithValue("@id", id);
            //Wykonanie komendy i zapisanie danych
            SQLiteDataReader result = myCommand2.ExecuteReader();
            //Wczytanie pierwszego wiersza (ROW).
            result.Read();

            

            //Zwrócenie danych z danego wiersza
            return result;




        }
        #endregion

        /// <summary>
        /// Znajdź daną parametr w bazie
        /// </summary>
        /// <param name="search">Parametr który ma zostać znaleziony</param>
        /// <param name="table">z jakiej tabeli</param>
        public void Search(string search, string table)
        {

            //Ścieszka do głównego okna by móc wprowadzać zmiany
            var mainWindow1 = ((MainWindow)Application.Current.MainWindow);
            //Obiekt bazy
            DataBase databaseObject = new();

            var query3 = "";

            //Jeśli tabela to "Web"...
            if (table == "Web")
            {
                //Komenda SQL szukająca danego wyrazu w każdej kolumnie
                query3 = "SELECT * FROM Web WHERE Url LIKE '%" + search + "%' OR Login LIKE '%" + search + "%' OR Password LIKE '%" + search + "%'  OR Email LIKE '%" + search + "%'  ";
            }
            //W innym wypadku...
            else
            {
                //Komenda SQL szukająca danego wyrazu w każdej kolumnie
                query3 = "SELECT * FROM  App WHERE Name LIKE '%" + search + "%' OR Login LIKE '%" + search + "%' OR Password LIKE '%" + search + "%'  OR Email LIKE '%" + search + "%'  ";
            }

            //Zapisanie komendy wraz z połączeniem do bazy.
            SQLiteCommand myCommand2 = new(query3, databaseObject.sqlConnection);

            //Sprawdzenie czy jest już połączenie
            var state = databaseObject.sqlConnection.State.ToString();

            //Jęśli nie ma połączenia...
            if (state == "Closed")
                //Połącz z bazą
                databaseObject.sqlConnection.Open();


            //Wykonanie komendy SQL i zapisanie wyniku.
            SQLiteDataReader result = myCommand2.ExecuteReader();

            //Jeśli wynik ma wiersze..
            if (result.HasRows)
            {
                //Wyczyść dane w stakpanelu
                mainWindow1.StackPanelSide.Children.Clear();
                //Dopóki jest jeszcze coś do przeczytania w zmiennej..
                while (result.Read())
                {
                    //Utworzenie nowego przycisku 
                    RadioButton radioButton = new();
                    //Dodanie do grupy "Side"
                    radioButton.GroupName = "Side";
                    //Nadanie stylu ToggleButton_Chose
                    radioButton.Style = (Style)mainWindow1.Resources["ToggleButton_Chose"];
                    //Nadanie eventu Click
                    radioButton.Click += mainWindow1.Button_LoadData;
                    //Nadanie tag (indywidualna nazwa) jako numer ID
                    radioButton.Tag = result["Id"];

                    //Nadanie evenutów do przesównia i usuwania.
                    radioButton.PreviewMouseDown += mainWindow1.RadioButton_PreviewMouseDown;
                    radioButton.PreviewMouseMove += mainWindow1.RadioButton_PreviewMouseMove;
                    radioButton.PreviewMouseUp += mainWindow1.RadioButton_PreviewMouseUp;

                    var url = "";
                    //Jeśli tabela to "Web"...
                    if (table == "Web")
                    {
                        //Pobranie nazwy Url
                        url = GetWebName((string)result["Url"]);
                        //Wprowadzenie ścieszki do obrazka (Source)
                        ToggleButtonProperties.SetImageSource(radioButton, new BitmapImage(new Uri("https://www." + url + "/favicon.ico")));
                    }
                    //W innym wypadku
                    else
                    {
                        //Zapisanie nazwy programu
                        url = (string)result["Name"];
                    }

                    //Wpisanie tesku (Strona)
                    ToggleButtonProperties.SetFirstText(radioButton, url);
                    //Wpisanie tekstu (login)
                    ToggleButtonProperties.SetSecondText(radioButton, (string)result["Login"]);


                    //Dodanie przyckisku do odpowiedniego stakpanelu by był widoczny. 
                    mainWindow1.StackPanelSide.Children.Add(radioButton);




                }
            }
            databaseObject.sqlConnection.Close();


        }

        #region Help Methods
        /// <summary>
        /// Przemienienie nazwy strony
        /// </summary>
        /// <param name="web">Strona</param>
        /// <returns>nazwa strony z rozszerzeniem </returns>
        private static string GetWebName(string web)
        {
            //Zamień wszystkie litery na małe.
            web = web.ToLower();

            var https = "https://";
            var http = "http://";
            var www = "www.";

            //Zamień "https://" na puste 
            web = web.Replace(https, "");
            //Zamień "http://" na puste
            web = web.Replace(http, "");
            //Zamień "www." na puste
            web = web.Replace(www, "");

            //Zwróć nazwe strony.
            return web;
        }
        #endregion

    }

}
