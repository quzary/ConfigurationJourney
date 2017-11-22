using System;
using System.Configuration;

namespace Messaging
{
    public interface IBusPublisherFactory
    {
        object Create();
    }

    public class RabbitMqPublisherFactory : IBusPublisherFactory
    {
        public object Create()
        {
            Console.WriteLine("Creating a bus publisher for RabbitMQ");

            var connectionString = ConfigurationManager.AppSettings["RabbitConnectionString"];
            Console.WriteLine($"Using connection string: {connectionString}");
            
            return null;
        }
    }
}
