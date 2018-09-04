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
                sw.WriteLine("Anders");
                sw.Flush();

                String line = sr.ReadLine();

                Console.WriteLine(line);
            } // using slut = close forbindelse til socket / client
        }
    }
}
