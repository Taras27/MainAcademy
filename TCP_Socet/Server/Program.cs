using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "192.168.0.150";
            const int port = 5000;

            var tcpEndpoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Bind(tcpEndpoint);
            tcpSocket.Listen(5);

            var listener = tcpSocket.Accept();
            var buf = new byte[256];
            var size = 0;
            var data = new StringBuilder();

            while (true)
            {
                do
                {
                    size = listener.Receive(buf);
                    data.Append(Encoding.ASCII.GetString(buf, 0, size));
                } 
                while (listener.Available > 0);

                Console.WriteLine($"{DateTime.Now}: reseived data -> {data}");
                listener.Send(Encoding.ASCII.GetBytes("Data send!\r\n")); 
                
                if(data.ToString() == "Close")
                {
                    listener.Shutdown(SocketShutdown.Both);
                    listener.Close();
                    Console.WriteLine($"{DateTime.Now}: received data -> Server Close!!!");
                }
            }
           
        }
    }
}
