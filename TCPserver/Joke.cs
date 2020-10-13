using System;
namespace TCPserver
{
    /// <summary>
    /// Klasa Joke - przechowuje i wybiera suchary.
    /// </summary>
    public class Joke
    {

        private string[] suchary = new string[5];
        
        public Joke()
        {
            suchary[0] = "\nGdzie podpisano traktat wersalski? \n - Na samym dole, pod tekstem.";
            suchary[1] = "\n- Co sie po jednej stronie glaszcze a po drugiej lize?? \n- Nie wiem. \n-... znaczek pocztowy!!";
            suchary[2] = "\nCo sie stanie jak walec drogowy przejedzie czlowieka? \n- Konwersja obrazu z 3D na 2D";
            suchary[3] = "\nJak sie nazywa mnich odpowiedzialny za podatki? \n- Brat PIT.";
            suchary[4] = "\n-Jaka jest ulubiona zabawa dzieci grabarza?  \n- W chowanego.";
        }


        /// <summary>
        /// Metoda wybierająca suchary z puli.
        /// </summary>
        /// <returns></returns>
        public string genJoke()
        {
            Random rnd = new Random();
            int indeks = rnd.Next(0, suchary.Length);
            string suchar = suchary[indeks];

            return suchar;
        }
    }
}
