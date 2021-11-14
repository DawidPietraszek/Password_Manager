using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Password_manager
{
    /// <summary>
    /// Animacje Ellipsy
    /// </summary>
    public class EllipseAnimation
    {

        public EllipseAnimation()
        {

        }

        /// <summary>
        /// Po najechaniu na przycisk pokaż Ellipse
        /// </summary>
        /// <param name="sender">Na jaki object</param>
        public void MouseEnter(object sender)
        {

            //Utworzenie zmiennej elipsy
            Ellipse ellipse = new Ellipse();
            //Pobranie informacji o przypisanej Ellipsie do danego obiektu
            ellipse = (Ellipse)ElipseName(sender);

            //Utworznie zmiennej radiobuttona
            RadioButton radioButton = new RadioButton();
            //Przekonwertowanie obiektu na radiobutton
            radioButton = (RadioButton)sender;

            //Jeśli ten radiobutton nie jest zaznaczony...
            if (false == radioButton.IsChecked)
            {

                //Dodanie animacji pojawiania obiektu
                var fade = new DoubleAnimation()
                {
                    //Od jakiej wartości 
                    From = 0,
                    //Do jakiej wartości
                    To = 1,
                    //Czas trwania animacji w milisecundach
                    Duration = TimeSpan.FromMilliseconds(180),
                };

                //Zmiana wysokości obiektu
                var heightChange = new DoubleAnimation()
                {
                    //Od jakiej wartości
                    From = 0,
                    //Do jakiej wartośći
                    To = 35,
                    //Czas trwania animacji
                    Duration = TimeSpan.FromMilliseconds(180),
                };
                //Przypisanie animacji do danego obektu (radiobuttona)
                Storyboard.SetTarget(fade, ellipse);
                //Nadanie do jakiej właściwości tyczy się ta animacji (Opacity)
                Storyboard.SetTargetProperty(fade, new PropertyPath(RadioButton.OpacityProperty));
                //Przypisanie animacji do danego obiektu
                Storyboard.SetTarget(heightChange, ellipse);
                //Nadanie do jakiej właściwości tyczy się ta animacjia (Height)
                Storyboard.SetTargetProperty(heightChange, new PropertyPath(RadioButton.HeightProperty));

                //Utworzenie zmiennej Storybord
                var sb = new Storyboard();
                //Dodanie animacji zmiany Opacity
                sb.Children.Add(fade);
                //Dodanie animacji zmiany Height
                sb.Children.Add(heightChange);
                //Rozpoczęcie animacji
                sb.Begin();




            }

        }

        /// <summary>
        /// Po usunięciu myszy z obiektu schowaj Ellipse
        /// </summary>
        /// <param name="sender">Jaki obiekt</param>
        public void MouseLeave(object sender)
        {

            //Utworzenie zmienej elipsy
            Ellipse ellipse = new Ellipse();
            //Pobranie informacji o przypisanej Ellipsie do danego obiektu
            ellipse = (Ellipse)ElipseName(sender);

            //Utworzenie zmiennej radiobutton
            RadioButton radioButton = new RadioButton();
            //Zamiana zmiennej Object na Radiobutton
            radioButton = (RadioButton)sender;
            //Jeśli dany radiobutton nie jest zaznaczony...
            if (false == radioButton.IsChecked)
            {
                //Aniamacja pojawiania się obiektu 
                var fadeOut = new DoubleAnimation()
                {
                    //Od danej wartośći
                    From = 1,
                    //Do danej wartości
                    To = 0,
                    //Czas zmiany
                    Duration = TimeSpan.FromMilliseconds(180),
                };

                //Zmiana wysokości obietu
                var heightChangeOut = new DoubleAnimation()
                {
                    //Od danej wysokości
                    From = 35,
                    //Do danej wysokości
                    To = 0,
                    //Czas zmiany
                    Duration = TimeSpan.FromMilliseconds(180),
                };

                //Przypisanie animacji do danej Ellipsy
                Storyboard.SetTarget(fadeOut, ellipse);
                //Nadanie animacji jaką właściwość ma zmieniać (Opacity)
                Storyboard.SetTargetProperty(fadeOut, new PropertyPath(RadioButton.OpacityProperty));
                //Przypisanie animacji do danej elpsy
                Storyboard.SetTarget(heightChangeOut, ellipse);
                //Nadanie animacji jaką właściwość ma zmienić (Height)
                Storyboard.SetTargetProperty(heightChangeOut, new PropertyPath(RadioButton.HeightProperty));

                //Utworzenie zmiennej Storybordu
                var sb2 = new Storyboard();
                //Dodanie animacji znikania do Storybordu
                sb2.Children.Add(fadeOut);
                //Dodanie animacji zmiany wysokości do Styrobordu
                sb2.Children.Add(heightChangeOut);
                //Rozpoczęcie animacji
                sb2.Begin();

            }




        }

        /// <summary>
        /// Po kliknięciu na przycisk schowaj Ellipse drugiego przycisku
        /// </summary>
        /// <param name="sender">Który przycisk</param>
        public void Click(object sender)
        {
            //Utworzenie zmiennej RadioButton
            RadioButton radioButton = new RadioButton();

            //Utworzenie zmiennej Ellipse
            Ellipse ellipse = new Ellipse();
            //Pobranie nazywu przypisanej Ellipsy do danego przycisku
            ellipse = (Ellipse)ElipseName(sender);
            //Utworzenie zmiennej storyboard
            var sb2 = new Storyboard();

            //Jeśli nazwa danej Ellipsy równa się nazwy pierwszej Elipsy...
            if (ellipse.Name == ((MainWindow)Application.Current.MainWindow).FirstCircle.Name)
            {
                //Animacjia zniakania
                var fadeOut = new DoubleAnimation()
                {
                    //Od danej wartośći
                    From = 1,
                    //Do danej wartośći
                    To = 0,
                    //Czas trwania
                    Duration = TimeSpan.FromMilliseconds(90),
                };
                //Dodanie animacji do drugiej Ellipsy (SEcoundCircle)
                Storyboard.SetTarget(fadeOut, ((MainWindow)Application.Current.MainWindow).SecoundCircle);
                //Nadanie animacji jąką wartość ma zmieniać
                Storyboard.SetTargetProperty(fadeOut, new PropertyPath(RadioButton.OpacityProperty));

                //Dodanie do storybordu
                sb2.Children.Add(fadeOut);
                //Rozpoczęcie animacji
                sb2.Begin();

            }
            //W innym wypadku...
            else
            {

                //Animacja znikania
                var fadeOut = new DoubleAnimation()
                {
                    //Od danej wartości
                    From = 1,
                    //Do danej wartości
                    To = 0,
                    //Czas trwania
                    Duration = TimeSpan.FromMilliseconds(90),
                };
                //Przypisanie animacji do obiektu (FirstCircle)
                Storyboard.SetTarget(fadeOut, ((MainWindow)Application.Current.MainWindow).FirstCircle);
                //Nadanie animacji wartośći którą ma zmieniać (Opacity)
                Storyboard.SetTargetProperty(fadeOut, new PropertyPath(RadioButton.OpacityProperty));

                //
                sb2.Children.Add(fadeOut);
                sb2.Begin();

            }

        }


        /// <summary>
        /// Poddaje obiect przypisany do danego przycisku
        /// </summary>
        /// <param name="sender">Obiekt który na który została najechana mysz</param>
        /// <returns>Object przypisany do przycisku</returns>
        private object ElipseName(object sender)
        {
            //Utworzenie zmiennej RadioButton
            RadioButton radioButton = new RadioButton();
            //Zamiana typu Object na RadioButton
            radioButton = (RadioButton)sender;

            //Jeśli nazwa danego radiobuttona jest równa "App"
            if (radioButton.Name == ((MainWindow)Application.Current.MainWindow).App.Name)
            {
                //Zwróć zmienną Object SecoundCircle;
                return ((MainWindow)Application.Current.MainWindow).SecoundCircle;
            }
            //W innym wypadku
            else
            {
                //Zwróć zmienną Object FirstCircle
                return ((MainWindow)Application.Current.MainWindow).FirstCircle;
            }

        }


    }
}
