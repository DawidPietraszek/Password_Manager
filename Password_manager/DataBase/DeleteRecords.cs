using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Password_manager
{
    class DeleteRecords
    {

        //Pozycja myszy
        private Point mousePosition;
        //Czy się porusza przycisk
        public bool _isMoving;
        //Dokładna pozyzja przycisku x i y
        private Point? _buttonPosition;
        //Pozycja X 
        private double deltaX;
        //Zmiana pozycji
        private TranslateTransform _currentTT;



        /// <summary>
        /// Po naciśnieciu przycisku zezwól na przesuwanie tego obiektu
        /// </summary>
        /// <param name="button">Przycisk</param>
        /// <param name="StackPanelSide">Miejsce gdzie znajduje się przycisk</param>
        public void Chosebutton_PreviewMouseDown(RadioButton button, StackPanel StackPanelSide)
        {

            //Jęśli pozycja przyciska jest nie znana
            if (_buttonPosition == null)
                //Ustal pozycję przycisku na x=0 y=0 względem Stack Panelu w którym się znajduje
                _buttonPosition = button.TransformToAncestor(StackPanelSide).Transform(new Point(0, 0));

            //Pozycja myszki względem siatki grid
            mousePosition = Mouse.GetPosition(StackPanelSide);
            //
            deltaX = mousePosition.X - _buttonPosition.Value.X;

            //Zaznacz że się przesuwa
            _isMoving = true;


        }


        /// <summary>
        /// Przesunięcie przycisku względem miejsca gdzie w którym się znajduje
        /// </summary>
        /// <param name="button">Przycisk</param>
        /// <param name="StackPanelSide">Miejsce gdzie znajduje się przycisk</param>
        public void Chosebutton_PreviewMouseMove(RadioButton button, StackPanel StackPanelSide)
        {
            //Jeśli się nie rusza zwróć nic
            if (!_isMoving) return;

            //Pobierz gdzie znajduje się myszka względem głównego gridu
            var mousePoint = Mouse.GetPosition(StackPanelSide);

            //Zapisz przesunięcie X.
            //Jeśli aktualna pozycja się nie zmieniła zapisz pozycję X przycisku. W innym wypadku odejmij od pozycji przycisku wartość przesuniecia.
            var offsetX = (_currentTT == null ? _buttonPosition.Value.X : _buttonPosition.Value.X - _currentTT.X) + deltaX - mousePoint.X;

            //Przemieść ten przycisk o tą wartość
            button.RenderTransform = new TranslateTransform(-offsetX, 0);

        }

        /// <summary>
        /// Po puszczeniu przycisku wyświetl komunikat o usunięciu jeśli przycisk został przesunięty   
        /// </summary>
        /// <param name="button">Przycisk</param>
        /// <param name="StackPanelSide">Miejsce gdzie znajduje się przycisk</param>
        public void Chosebutton_PreviewMouseUp(RadioButton button, StackPanel StackPanelSide)
        {

            //Wróć przycisk do pozycji początkowej
            button.RenderTransform = new TranslateTransform(0, 0);
            _currentTT = button.RenderTransform as TranslateTransform;

            //Zaznacz że się nie przesuwa
            _isMoving = false;

            //Jeśli przycisk się poruszył..
            if (mousePosition.X != Mouse.GetPosition(StackPanelSide).X)
            {
                //Wyświetl komunikat czy napewno chcesz usunąć
                MessageBoxResult messageBoxResult = MessageBox.Show("Do you want to delete this?", "Delete", MessageBoxButton.YesNo);

                //Jeśli została wybran opcja YES...
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    //Utwórz obiekt do manipulowania danymi w bazie
                    DataBaseManipulation dataBaseManipulation = new();
                    //Usunięcie odpowiednich danych z bazy
                    dataBaseManipulation.DeleteRecords(button.Tag.ToString(), (string)((MainWindow)Application.Current.MainWindow).InformativeLabel.Content);

                }
            }
        }
    }

}

