using System.Windows;
using System.Windows.Media;

namespace Password_manager
{

    public static class ToggleButtonProperties
    {
        public static ImageSource GetImageSource(DependencyObject dependencyObject)
        {
            return (ImageSource)dependencyObject.GetValue(ImageSourceProperty);
        }

        public static void SetImageSource(DependencyObject dependencyObject, ImageSource value)
        {
            dependencyObject.SetValue(ImageSourceProperty, value);
        }

        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.RegisterAttached(
           "ImageSource", typeof(ImageSource), typeof(ToggleButtonProperties));

        public static string GetFirstText(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(FirstTextProperty);
        }

        public static void SetFirstText(DependencyObject dependencyObject, string value)
        {
            dependencyObject.SetValue(FirstTextProperty, value);
        }

        public static readonly DependencyProperty FirstTextProperty = DependencyProperty.RegisterAttached(
           "FirstText", typeof(string), typeof(ToggleButtonProperties));

        public static string GetSecondText(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(SecondTextProperty);
        }

        public static void SetSecondText(DependencyObject dependencyObject, string value)
        {
            dependencyObject.SetValue(SecondTextProperty, value);
        }

        public static readonly DependencyProperty SecondTextProperty = DependencyProperty.RegisterAttached(
           "SecondText", typeof(string), typeof(ToggleButtonProperties));
    }

}