using Messaging;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var rabbitMqPublisherFactory = new RabbitMqPublisherFactory();
            rabbitMqPublisherFactory.Create();

            System.Console.ReadKey();
        }
    }
}
