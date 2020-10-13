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
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8008);
            server.Start();
            Console.Write("Odpalam server\n");
            string negatyw = "Ja tylko serwuje suchary\n";
            byte[] bytes = Encoding.ASCII.GetBytes(negatyw);
            Joke suchy = new Joke();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.Write("Polaczono\n");
                byte[] buffer = new byte[1024];
                client.GetStream().Read(buffer);
                string text = Encoding.UTF8.GetString(buffer).Replace("\n", "").Replace("\0", "");
                Console.Write(text);
                if (check(text))
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

        /// <summary>
        /// Sprawdzanie czy text jest zgodny
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static bool check(String text)
        {
            if(text == "suchar")
            {
                return true;
            } else
            {
                return false;
            }
            
        }

    }
}
