using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "192.168.0.150";
            const int port = 5000;

            var tcpEndpoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Connect(tcpEndpoint);
            while (true)
            {
                //Console.WriteLine("Enter message: ");
                //var message = Console.ReadLine();

                //var data = Encoding.UTF8.GetBytes(message);

                
                //tcpSocket.Send(data);

                var buf = new byte[256];
                var size = 0;
                var answer = new StringBuilder();

                do
                {
                    size = 0;
                    size += tcpSocket.Receive(buf);
                    answer.Append(Encoding.UTF8.GetString(buf, 0, size));
                    
                }
                while (tcpSocket.Available > 0);

                Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] -> {answer.ToString()}");
               
            }
            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();
            Console.ReadLine();

        }
    }
}
