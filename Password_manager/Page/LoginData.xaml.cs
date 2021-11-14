using System.Data.SQLite;
using System.Windows;

namespace Password_manager.Page
{
    /// <summary>
    /// Interaction logic for LoginData.xaml
    /// </summary>
    public partial class LoginData
    {
        public LoginData(string id)
        {


            InitializeComponent();

            //Obiekt bazy
            DataBase databaseObject = new();

            //Jaka jest teraz tabela wybrana
            var table = (string)((MainWindow)Application.Current.MainWindow).InformativeLabel.Content;

            //Utworzenie instancji do manipulowania danymi z bazy
            DataBaseManipulation dataBaseManipulation = new();

            //Pobranie danych z danej tabeli
            SQLiteDataReader resoult = dataBaseManipulation.SelectRecord(databaseObject,id, table);

            //Pobranie informacji o nawie drugiej kolumny
            var name = resoult.GetName(1);

            //Jeśli nazwa to "Url"...
            if (name == "Url")
            {
                //Wypisz Url
                ShowUrl.Text = (string)resoult["Url"];

            }
            //W innym wypadku...
            else
                //Wypisz nazwe Programu
                ShowUrl.Text = (string)resoult["Name"];

            //Wypisz Login
            ShowLogin.Text = (string)resoult["Login"];
            //Wypisz Hasło
            ShowPassword.Text = (string)resoult["Password"];
            //Wypisz Email
            ShowEmail.Text = (string)resoult["Email"];


            databaseObject.sqlConnection.Close();
        }
    }
}
