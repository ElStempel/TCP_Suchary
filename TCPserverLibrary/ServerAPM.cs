using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPserverLibrary
{

    public class ServerAPM : ServerAbstract
    {

        static string negatyw = "Ja tylko serwuje suchary\n";
        static string instrukcja = "\n\n\"suchar\" wysyla suchara, \"quit\" rozlacza, \"shutdown\" zamyka serwer\n";
        byte[] instr = Encoding.ASCII.GetBytes(instrukcja);
        byte[] bytes = Encoding.ASCII.GetBytes(negatyw);

        Joke suchy = new Joke();

        bool shutdown = false;

        public delegate void TransmissionDataDelegate(NetworkStream stream);

        public ServerAPM(IPAddress IP, int port) : base(IP, port)
        {

        }

        protected override void AcceptClient()
        {

            while (true)
            {

                TcpClient tcpClient = TcpListener.AcceptTcpClient();
                Stream = tcpClient.GetStream();
                TransmissionDataDelegate transmissionDelegate = new TransmissionDataDelegate(BeginDataTransmission);
                transmissionDelegate.BeginInvoke(Stream, TransmissionCallback, tcpClient);

            }

        }

        private void TransmissionCallback(IAsyncResult ar)
        {

        }

        protected override void BeginDataTransmission(NetworkStream stream)
        {

            byte[] buffer = new byte[Buffer_size];

            while (true)
            {
                tcpClient.GetStream().Write(instr, 0, instr.Length);
                //Odbieranie wiadomości
           
                tcpClient.GetStream().Read(buffer);
                string text = Encoding.UTF8.GetString(buffer).Replace("\n", "").Replace("\0", "");
                Console.Write(text);

                //Rozpoznawanie otrzymanego komunikatu i odpowiedzi
                if (text == "shutdown")
                {
                    Console.WriteLine("Zamykam serwer\n");
                    tcpClient.Close();
                    shutdown = true;
                    break;
                }
                else if (text == "quit")
                {
                    Console.WriteLine("Rozłączam\n");
                    tcpClient.Close();
                    break;
                }
                else if (text == "suchar")
                {
                    Console.WriteLine("Potwierdzam\n");
                    String sucharek = suchy.genJoke();
                    byte[] pozytyw = Encoding.ASCII.GetBytes(sucharek);
                    tcpClient.GetStream().Write(pozytyw, 0, pozytyw.Length);

                }
                else
                {
                    Console.WriteLine("Odrzucam\n");
                    tcpClient.GetStream().Write(bytes, 0, bytes.Length);
                }
            }

        }

        public override void Start()
        {

            StartListening();
            //transmission starts within the accept function
            AcceptClient();

        }



    }

}