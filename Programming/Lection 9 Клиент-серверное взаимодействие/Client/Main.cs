// пространство от класса отличается тем, что в пространстве может быть несколько классов.
//  Класс - это тип данных, а пространство это набор "переменных", набор типов
namespace Client
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Это наш клиент");
            OurClient ourClient = new OurClient();
        }
    }
}