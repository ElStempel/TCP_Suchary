using System;
using System.Collections;

namespace TCPserver
{
    /// <summary>
    /// Klasa Joke - przechowuje i wybiera suchary.
    /// </summary>
    public class Joke
    {
        /// <summary>
        /// Suchary przechowywane w ArrayList
        /// </summary>
        ArrayList suchary = new ArrayList();


        /// <summary>
        /// Konstruktor domyślny umieszcza suchary w ArrayList
        /// </summary>
        public Joke()
        {
            suchary.Add("\nGdzie podpisano traktat wersalski? \n- Na samym dole, pod tekstem.");
            suchary.Add("\nCo sie po jednej stronie glaszcze a po drugiej lize?? \n- Nie wiem. \n-... znaczek pocztowy!!");
            suchary.Add("\nCo sie stanie jak walec drogowy przejedzie czlowieka? \n- Konwersja obrazu z 3D na 2D");
            suchary.Add("\nJak sie nazywa mnich odpowiedzialny za podatki? \n- Brat PIT.");
            suchary.Add("\nJaka jest ulubiona zabawa dzieci grabarza?  \n- W chowanego.");
            suchary.Add("\nCo robi elektryk na scenie? \n- Buduje napiecie.");
            suchary.Add("\nJaki jest ulubiony owoc zolnierza? \n- Granat.");
        }


        /// <summary>
        /// Metoda wybierająca suchary z puli.
        /// </summary>
        /// <returns></returns>
        public string genJoke()
        {
            Random rnd = new Random();
            int indeks = rnd.Next(0, suchary.Count);
            string suchar = (string)suchary[indeks];

            return suchar;
        }
    }
}
