using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

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

            using (TcpClient socket = serverListener.AcceptTcpClient())
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))

            {
                String incomingString = sr.ReadLine();

                Console.WriteLine($"String in = {incomingString}");

                sw.WriteLine(incomingString);
                sw.Flush();

            } // using slut = close forbindelse til socket / client
        }
    }
}