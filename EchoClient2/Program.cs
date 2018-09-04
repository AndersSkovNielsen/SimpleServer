using System;

namespace EchoClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.Start();

            Console.ReadLine();
        }
    }
}
