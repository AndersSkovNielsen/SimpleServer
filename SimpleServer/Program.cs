using System;

namespace SimpleServer
{
    class Program
    {
        private const int PORT = 7;
        static void Main(string[] args)
        {
            EchoServer server = new EchoServer(PORT);
            server.Start();

            Console.ReadLine();
        }
    }
}
