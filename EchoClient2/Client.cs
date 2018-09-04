using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace EchoClient2
{
    class Client
    {
        public Client()
        {

        }

        public void Start()
        {
            using (TcpClient socket = new TcpClient("localhost", 7))
                
            using (NetworkStream ns = socket.GetStream())

            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))

            {
                sw.WriteLine("Anders er en test og nu laver vi en ny test");
                sw.Flush();

                String line = sr.ReadLine();

                Console.WriteLine(line);
                Console.WriteLine("Antal ord: " + sr.ReadLine());
            } // using slut = close forbindelse til socket / client
        }
    }
}
