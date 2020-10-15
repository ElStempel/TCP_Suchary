using System;

namespace TCPserver
{
    /// <summary>
    /// Klasa Program serwera TCP
    /// </summary>
    class Program
    {

        /// <summary>
        /// Metoda Main uruchamiająca serwer z klasy Server w bibliotece klas
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            TCPserverLibrary.Server server = new TCPserverLibrary.Server();
            server.Run();
        }
    }
}
