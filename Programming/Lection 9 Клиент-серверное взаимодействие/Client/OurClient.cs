using System.Net.Sockets; // библиотека TCP для работы с протоколом обмена с сервером
using System.Text;

namespace Client
{
    class OurClient
    {
        TcpClient client;
        StreamWriter sReader;

        public OurClient()
        {
            client = new TcpClient("127.0.0.1", 5555); // 127.0.0.1 - наш ip, а 5555 - порт, как в гавани
            sReader = new StreamWriter(client.GetStream(), Encoding.UTF8); // когда вызываем паблик в главном
            // файле, здесь клиенту приписывается ip и порт. GetStream() - вытащить поток из client, то есть создаем поток для клиента

            HandleCommunication();
        }
        void HandleCommunication()
        {
            while(true)
            {
                Console.WriteLine("> ");
                string message = Console.ReadLine();
                sReader.WriteLine(message); //sReader - поток, передаем сообщение ОТ КЛИЕНТА по данному потоку СЕРВЕРУ
                sReader.Flush(); // передаем сообщение НЕМЕДЛЕННО
            }
        }

        OurClient(string ipAddress, int portNum)
        {

        }
    }
}