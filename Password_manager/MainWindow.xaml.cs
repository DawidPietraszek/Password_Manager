using Password_manager.Page;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Password_manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

            //Jeśli baza nie istnieje...
            if (!File.Exists("./database.db"))
            {
                //Utwórz obiekt strony do rejestracji
                RegistrationPage registrationPage = new();
                //Wyświetlenie strony do rejestracji
                loginFrame.Navigate(registrationPage);
            }
            //W innym wypadku...
            else
            {
                //Utwórz obiekt strony do logowania
                LoginPage loginPage = new();
                //Wyświetlenie strony do rejestracji
                loginFrame.Navigate(loginPage);
            }
 
        }



        /// <summary>
        /// Przesuwanie okna 
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Przesówanie okna
            DragMove();
        }

        #region Nawigacja okna -[]X
        /// <summary>
        /// Wyłączenie aplikacji.
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Wyłączenie aktualniej aplikacji
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Zmiana rozmiaru okna. W oknie lub pełen ekran
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        private void Button_Maximization(object sender, RoutedEventArgs e)
        {
            //Jęsli aplikacja jest w oknie...
            if (Application.Current.MainWindow.WindowState == WindowState.Normal)
            {
                //Powiększ jąna pełen ekran
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            //W innym wypadku...
            else
                //Wyświetl aplikację w oknie 
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

        /// <summary>
        /// Minimalizacja aplikacji do paska
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        private void Button_Minimalization(object sender, RoutedEventArgs e)
        {
            //Minimalizowanie okna do paska
            Application.Current.MainWindow.WindowState = WindowState.Minimized;

        }

        #endregion

        #region Manipulacja danymi
        /// <summary>
        /// Wyświetla okno dodawania zmiennych do bazy.
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        private void Button_AddData(object sender, RoutedEventArgs e)
        {
            //Wyświetl okno dodawania zmiennych do bazy w odpowiedniej ramce
            SideAddReadFrame.Content = new AddSide();
        }

        /// <summary>
        /// Wyświetla okno do odczytu danych z bazy
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        public void Button_LoadData(object sender, RoutedEventArgs e)
        {
            //Wyświetla okndo odczytu danych z bazy w odpowiedniej ramce
            SideAddReadFrame.Content = new LoginData((sender as RadioButton).Tag.ToString());
        }

        /// <summary>
        /// Ładuje i wyświetla dane z danej tabeli
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        private void Button_LoadTable(object sender, RoutedEventArgs e)
        {
            //Utwórz zmienną RadioButto i przypisz do niego obiekt który został naciśnięty
            RadioButton radioButton = (RadioButton)sender;
            //Ustaw nazwe tabeli w lewym górny rogu aplikacji
            InformativeLabel.Content = radioButton.Name;

            //Jeśli nazwa przycisku który został naciśnięty jest równa "App"...
            if (radioButton.Name == "App")
            {
                //Ustaw ikonkę GlyphDesktop w lewym górnym rogu
                InformativeImage.Source = new BitmapImage(new Uri(@"/Icons/IconGlyphDesktop.png", UriKind.Relative));
            }
            else
            {
                //Ustaw ikonkę GlyphWeb w lewym górnym rogu
                InformativeImage.Source = new BitmapImage(new Uri(@"/Icons/IconGlyphWeb.png", UriKind.Relative));
            }

            //Utworzenie obiektu bazy.   
            DataBase databaseObject = new();
            //Utowrzenie obiektu do zarządzania komendami SQL
            DataBaseManipulation dataBaseManipulation = new();
            //Pobranie danych z bazy dla odpowiedniej tabeli
            dataBaseManipulation.LoadDataFormBase(databaseObject, (string)InformativeLabel.Content);

            //Utworzenie obiektu EllipseAnimation
            EllipseAnimation ellipseAnimation = new EllipseAnimation();
            //Zmiana wizualnego przedstawienia która tabela jest wybrana
            ellipseAnimation.Click(sender);

        }
        #endregion


        #region Move and delete records

        //Obiekt DeleteRecords do usuwania danych z bazy
        DeleteRecords deleteRecords = new();

        /// <summary>
        /// Po puszczeniu przycisku 
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        public void RadioButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            //Przekonwertowanie obiektu na RadioButton
            RadioButton radioButton = (RadioButton)sender;
            //Usunięcie danych z bazy jeśli przycisk został przesunięty
            deleteRecords.Chosebutton_PreviewMouseUp(radioButton, StackPanelSide);
        }

        /// <summary>
        /// Przesuwanie obiektu 
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        public void RadioButton_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            //Przekonwertowanie obiektu na RadioButton
            RadioButton radioButton = (RadioButton)sender;
            //Przesuwanie obiektu
            deleteRecords.Chosebutton_PreviewMouseMove(radioButton, StackPanelSide);
        }

        /// <summary>
        /// Po naciśnięciu przycisku 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RadioButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            deleteRecords.Chosebutton_PreviewMouseDown(radioButton, StackPanelSide);
        }

        #endregion

        /// <summary>
        /// Przetwarzanie danych wprowadzonych w text boxie
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        private void Search(object sender, RoutedEventArgs e)
        {
            //Pobranie danych wprowadzonyc w text boxie
            var search = SearchBox.Text;
            //Pobranie informacji z której tabeli mają być wyszukiwane dane
            var table = (string)InformativeLabel.Content;
            //Obiekt bazy do przetwarzania danych
            DataBaseManipulation dataBaseManipulation = new();
            //Wyszukanie danej frazy w danej tabeli z bazy 
            dataBaseManipulation.Search(search, table);

        }

        /// <summary>
        /// Po naciśnięciu jakiegoś przycisku.
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            //Jeśli przycisk to Enter...
            if (e.Key == Key.Enter)
            {
                //Przetwarzaj dane wprowadzone w tesxtboxie
                Search(sender, e);
            }
        }


        /// <summary>
        /// Poczas zamykania aplikacji
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        private void Window_Closed(object sender, EventArgs e)
        {

            //Szyfruj baze
            DecryptOnClose();

        }

        /// <summary>
        /// Szyfrowanie bazy danych
        /// </summary>
        private void DecryptOnClose()
        {
            //Informacje na temat pliku z bazą
            FileInfo fileInfo = new("./database.db");
            //Utworzenie obiektu bazy
            DataBase dataBase = new();
            //Czy plik jest zablokowany
            bool isFileLocked;
            do
            {
                //Zamknięcie połączenia 
                dataBase.sqlConnection.Close();
                //Wyczyszczenie niepotrzebnych elementów
                GC.Collect();
                //Czeka aż wszystko zostanie wykonane do tego momentu
                GC.WaitForPendingFinalizers();
                //Sprwdź czy plik jest zablokowany
                isFileLocked = IsFileLocked(fileInfo);

                //Jeśli plik nie jest zablokowany
                if (isFileLocked == false)
                {
                    //Zaszyfruj bazę
                    DecryptionAndEncryption decryptionAndEncryption = new();
                    decryptionAndEncryption.Decrypt("./database.db");
                }

                //Dopóki plik jest zablokowany powtarzaj...
            } while (isFileLocked == true);
        }
        /// <summary>
        /// Sprawdź czy plik jest zablokowany
        /// </summary>
        /// <param name="file">FileInfo - plik </param>
        /// <returns>Czy plik jest zablokowany</returns>
        protected virtual bool IsFileLocked(FileInfo file)
        {
            try
            {
                //Spróbuj otworzyć plik i go zamknąć
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            //jeśli coś pójdzie nie tak...
            catch (IOException)
            {
                //Zwródź true
                return true;
            }

            //Jeśli się uda zwróć tak.
            return false;
        }

        /// <summary>
        /// Po najechaniu myszką na obiekt
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        private void RaddioButtonMouseEnter(object sender, MouseEventArgs e)
        {
            //Obiekt animacji Ellipsy
            EllipseAnimation ellipseAnimation = new();
            //Pokaż ellipse przy danym przycisku
            ellipseAnimation.MouseEnter(sender);

        }

        /// <summary>
        /// Po opuszczeniu myszki z przycisku
        /// </summary>
        /// <param name="sender">Obiekt</param>
        /// <param name="e">Event</param>
        private void RaddioButtonMouseLeave(object sender, MouseEventArgs e)
        {
            //Obiekt animacji ellipsy
            EllipseAnimation ellipseAnimation = new();
            //Schowaj elpise
            ellipseAnimation.MouseLeave(sender);

        }
    }
}
