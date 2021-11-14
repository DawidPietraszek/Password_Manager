using System;
using System.Text;

namespace Password_manager
{
    public class PasswordGenerate
    {


        /// <summary>
        /// Generuje losowe hasło
        /// </summary>
        /// <param name="length">długość hasła</param>
        /// <param name="numbers">Czy ma posiadać liczby</param>
        /// <param name="low">Czy ma posiadać małe litery</param>
        /// <param name="uper">Czy ma posiadać duże litery</param>
        /// <param name="special">Czy ma posiadać znaki specjalne</param>
        /// <returns></returns>
        public string GivePassword(int length, bool numbers, bool low, bool uper, bool special)
        {

            //Jeśli długość jest większa niż 0 i jakieś właściwości są "True"...
            if (length > 0 && numbers == true || low == true || uper == true || special == true)
            {
                //Zmienna znaków do użycia
                string characters = "";

                //Jeśli numbers == True ... Dodaj liczby do znaków
                if (numbers) characters += "1234567890";
                //Jeśli low == True ... Dodaj małe litery do znaków
                if (low) characters += "abcdefghijklmnopqrstuvwxyz";
                //Jeśli uper == True ... Dodaj duże litery do znaków
                if (uper) characters += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                //Jeśli special == True ... Dodaj znaki specjalne do znaków
                if (special) characters += "!@#$%^&*()_+=-";


                //Obiekt StringBuldera
                var res = new StringBuilder();
                //Obiekt Random
                var rnd = new Random();

                //Dopuki długość hasła jest większa niż zero... 
                while (0 < length--)
                {
                    //Dodaj losowy znak ze zmiennej characters.
                    res.Append(characters[rnd.Next(characters.Length)]);
                }
                //Zwróć cały String
                return res.ToString();
            }
            //W innym wypadku zwróć pusty string
            else return "";
        }
    }
}
