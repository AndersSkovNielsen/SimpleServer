using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleServer
{
    internal class EchoServer
    {
        private readonly int pORT;

        public EchoServer(int pORT)
        {
            this.pORT = pORT;
        }

        internal void Start()
        {
            TcpListener serverListener = new TcpListener(IPAddress.Loopback, pORT);
            serverListener.Start();
            
            //while (true) bruges til at kunne håndtere flere klienter
            while (true)
            {
                //Refaktorering så flere klienter kan håndteres samtidig
                TcpClient socket = serverListener.AcceptTcpClient();
                Task.Run(() => { TcpClient tempSocket = socket; DoClient(tempSocket); });
                //DoClient(/*TcpClient socket =*/ serverListener.AcceptTcpClient());
            }
        }

        public void DoClient(TcpClient socket /*= serverListener.AcceptTcpClient*/)
        {
            //using (TcpClient socket = serverListener.AcceptTcpClient())
            //Unødvendig da denne nu ligger i metodens parameter

            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))

            {
                String incomingString = sr.ReadLine();

                Thread.Sleep(5000);

                Console.WriteLine($"String in = {incomingString}");

                sw.WriteLine(incomingString);
                sw.Flush();

                CountWords(incomingString, sw);

            } // using slut = close forbindelse til socket / client
        }

        public void CountWords(string incomingString, StreamWriter sw)
        {
            int count = 0;

            var strings = incomingString.Split(" ");

            sw.WriteLine(strings.Length);
            sw.Flush();
        }
    }
}