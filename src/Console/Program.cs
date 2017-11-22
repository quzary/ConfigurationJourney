using System.Configuration;
using Messaging;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.AppSettings["RabbitConnectionString"];

            var rabbitMqPublisherFactory = new RabbitMqPublisherFactory();
            rabbitMqPublisherFactory.Create(connectionString);

            System.Console.ReadKey();
        }
    }
}
