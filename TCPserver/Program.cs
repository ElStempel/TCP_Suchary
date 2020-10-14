using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPserver
{
    /// <summary>
    /// Klasa Program serwera TCP
    /// </summary>
    class Program
    {

        /// <summary>
        /// Metoda Main obsługująca łączenie klienta i pętlę działania serwera
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Setup serwera
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8008);
            server.Start();
            Console.Write("Odpalam server\n");

            //Komunikaty i obiekt sucharów
            string negatyw = "Ja tylko serwuje suchary\n";
            byte[] bytes = Encoding.ASCII.GetBytes(negatyw);
            Joke suchy = new Joke();

            //Pętla serwera
            while (true)
            {
                //Łączenie z klientem
                TcpClient client = server.AcceptTcpClient();
                Console.Write("Polaczono\n");

                //Odbieranie wiadomości
                byte[] buffer = new byte[1024];
                client.GetStream().Read(buffer);
                string text = Encoding.UTF8.GetString(buffer).Replace("\n", "").Replace("\0", "");
                Console.Write(text);

                //Rozpoznawanie otrzymanego komunikatu i odpowiedzi
                if (text == "suchar")
                {
                    Console.Write("Potwierdzam\n");
                    String sucharek = suchy.genJoke();
                    byte[] pozytyw = Encoding.ASCII.GetBytes(sucharek);
                    client.GetStream().Write(pozytyw, 0, pozytyw.Length);

                } else
                {
                    Console.Write("Odrzucam\n");
                    client.GetStream().Write(bytes, 0, bytes.Length);
                }
                client.Close();
            }
        }
    }
}
