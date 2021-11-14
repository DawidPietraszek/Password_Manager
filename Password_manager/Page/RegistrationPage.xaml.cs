using System.Windows;

namespace Password_manager.Page
{
    /// <summary>
    /// Logika interakcji dla klasy RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage
    {
        public RegistrationPage()
        {
            InitializeComponent();


        }

        /// <summary>
        /// Rejsetracja
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        private void Button_Register(object sender, RoutedEventArgs e)
        {
            //Zaczytanie wprowadzonego hasła
            var password = Password.Text;
            //Zaczytanie powtórzonego hasła
            var repeatPassword = RepeatPassword.Text;

            //Jeśli hasła są równe...
            if (password == repeatPassword)
            {
                //Wpisz w programie hasło
                Properties.Settings.Default.passwordAccess = password;
                //Wpisz w porgramie login
                Properties.Settings.Default.loginAccess = Login.Text;
                //Zapisz dane
                Properties.Settings.Default.Save();

                //Zmiena MainWidnow do edycji głównego okna
                var mainWindow = ((MainWindow)Application.Current.MainWindow);

                //Zmiena strona logownia
                LoginPage loginData = new();
                //Dodanie Strony loginData do głównej ramki
                mainWindow.loginFrame.Navigate(loginData);
            }
            //W innym wypadku...
            else
                //Wyświetl informacje że hasła nie są identyczne.
                labelWrongPassword.Content = "Hasła nie są takie same. Spróbuj ponownie.";
        }
    }
}
