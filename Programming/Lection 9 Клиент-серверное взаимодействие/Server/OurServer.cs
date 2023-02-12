using System.Net.Sockets; // библиотека TCP для работы с протоколом обмена с сервером
using System.Net;
using System.Text;

namespace Server
{
    class OurServer
    {
        TcpListener server; // принимает запросы от клиентов - называем server

        public OurServer()
        {
            // server = new TcpListener(IPAddress.Parse("127.0.0.1", 5555));// IPAddress - это тип данных,
            server.Start();      // с помощью Parse текст "127.0.0.1" становится типом данных IPAddress

            LoopClients();
        }
        void LoopClients()
        {
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();// как только клиент обращается к серверу, сразу создается клиент, которого мы будем обрабатывать на сервере 
                        // server. - обращаемся к серверу (TcpListener)
            }
        }
    }

} // 54:49