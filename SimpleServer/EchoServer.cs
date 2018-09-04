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

            DoClient(/*TcpClient socket =*/ serverListener.AcceptTcpClient());
        }

        public void DoClient(TcpClient socket /*= serverListener.AcceptTcpClient*/)
        {
            //using (TcpClient socket = serverListener.AcceptTcpClient())
            //Unødvendig da denne nu ligger i metodens parameter

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