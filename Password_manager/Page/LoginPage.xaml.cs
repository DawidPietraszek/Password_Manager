using System.Windows;

namespace Password_manager.Page
{
    /// <summary>
    /// Logika interakcji dla klasy LoginPage.xaml
    /// </summary>
    public partial class LoginPage
    {
        public LoginPage()
        {
            InitializeComponent();

            //Utworzenie obiektu bazy
            DataBase dataBase = new();
            //Pobierz dane z bazy
            dataBase.DataBaseLoad();





        }

        private void Button_Login(object sender, RoutedEventArgs e)
        {


            //Pobierz login zapisany w programie
            var passwordAccess = Properties.Settings.Default.passwordAccess;
            //Pobierz hasło zapisane w programie
            var loginAccess = Properties.Settings.Default.loginAccess;

            //Jeśli dane wprowadzone są równe danym zapisanym...
            if (password.Password == passwordAccess && Login.Text == loginAccess)
            {
                //Utworzenie zmiennej główne okno.
                var mainWindow = ((MainWindow)Application.Current.MainWindow);
                //Usunięcie danych z ramki
                mainWindow.loginFrame.Content = null;
                //Wyłączenie możliwości cofniecia okna
                mainWindow.loginFrame.NavigationService.RemoveBackEntry();
            }
            //W innym wypadku
            else
                //Wyświetl informacje o złych danych logowania
                labelWrongLoginData.Content = "Złe dane logowania";
        }

        /// <summary>
        /// Usunięcie lub wprowadzenia przykładowego napisu.
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {

            //Tag jest przekształcany na ghost text

            //Jeśli w polu do wprowadzania hasła nic się nie znajduje...
            if (password.Password == "")
            {
                //Zastąp Tag napisem "Password"
                password.Tag = "Password";
            }
            //W innym wypadku
            else
            {
                //Usuń tag
                password.Tag = "";
            }
        }
    }
}
