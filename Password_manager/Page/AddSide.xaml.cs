using System.Windows;

namespace Password_manager
{


    /// <summary>
    /// Interaction logic for AddSide.xaml
    /// </summary>
    public partial class AddSide
    {

        public AddSide()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Odjęcie od długości hasła
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        private void MinusSliderValue(object sender, RoutedEventArgs e)
        {
            //Odejmij 1 od właściwości slidera
            this.Slider_Lenght_Password.Value--;

        }

        /// <summary>
        /// Dodanie do długości hasła
        /// </summary>
        /// <param name="sender">Obeikt</param>
        /// <param name="e">Event</param>
        private void PlusSliderValue(object sender, RoutedEventArgs e)
        {
            //Dodaj 1 do właściwości slidera
            this.Slider_Lenght_Password.Value++;
        }


        /// <summary>
        /// Dodaj do bazy
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        public void Button_Add(object sender, RoutedEventArgs e)
        {
            //Obiekt do manipulacji danymi w bazie
            DataBaseManipulation dataBaseManipulation = new();
            //Dodanie rekordu do bazy 
            dataBaseManipulation.AddRecords(Url.Text, Login.Text, Password.Text, Email.Text, (string)((MainWindow)Application.Current.MainWindow).InformativeLabel.Content);

        }

        /// <summary>
        /// Generuj hasło
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        public void Generate(object sender, RoutedEventArgs e)
        {
            //Obiekt PasswordGenerate
            PasswordGenerate passwordGenerate = new();
            //Zapisz wygerenowane hasło w polu tekstowym "RandomPassword"
            RandomPassword.Text = passwordGenerate.GivePassword(int.Parse(RandomPasswordLength.Text), (bool)Numbers.IsChecked, (bool)Low.IsChecked, (bool)Uper.IsChecked, (bool)Special.IsChecked);

            //Skopiuj do schowka wygenerowane hasło
            Clipboard.SetDataObject(RandomPassword.Text);
        }
    }
}
