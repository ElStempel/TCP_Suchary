using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

//TODO asynchroniczne i bonus funkcjonalności



namespace TCPserverLibrary
{
    public class Server
    {

        /// <summary>
        /// Metoda Run obsługująca łączenie klienta i pętlę działania serwera
        /// </summary>
        public void Run()
        {
            //Setup serwera
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8008);
            server.Start();
            Console.WriteLine("Odpalam server\n");

            //Komunikaty i obiekt sucharów
            string negatyw = "Ja tylko serwuje suchary\n";
            string instrukcja = "\n\n\"suchar\" wysyla suchara, \"quit\" rozlacza, \"shutdown\" zamyka serwer\n";
            byte[] instr = Encoding.ASCII.GetBytes(instrukcja);
            byte[] bytes = Encoding.ASCII.GetBytes(negatyw);
            Joke suchy = new Joke();

            bool shutdown = false;

            //Pętla łączenia
            while (shutdown == false)
            {
                //Łączenie z klientem
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Polaczono\n");

                //Pętla serwera
                while (true)
                {
                    client.GetStream().Write(instr, 0, instr.Length);
                    //Odbieranie wiadomości
                    byte[] buffer = new byte[1024];
                    client.GetStream().Read(buffer);
                    string text = Encoding.UTF8.GetString(buffer).Replace("\n", "").Replace("\0", "");
                    Console.Write(text);

                    //Rozpoznawanie otrzymanego komunikatu i odpowiedzi
                    if (text == "shutdown")
                    {
                        Console.WriteLine("Zamykam serwer\n");
                        client.Close();
                        shutdown = true;
                        break;
                    }
                    else if (text == "quit")
                    {
                        Console.WriteLine("Rozłączam\n");
                        client.Close();
                        break;
                    }
                    else if (text == "suchar")
                    {
                        Console.WriteLine("Potwierdzam\n");
                        String sucharek = suchy.genJoke();
                        byte[] pozytyw = Encoding.ASCII.GetBytes(sucharek);
                        client.GetStream().Write(pozytyw, 0, pozytyw.Length);

                    }
                    else
                    {
                        Console.WriteLine("Odrzucam\n");
                        client.GetStream().Write(bytes, 0, bytes.Length);
                    }
                }
            }
        }
    }
}
