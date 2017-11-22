using System;

namespace Messaging
{
    public interface IBusPublisherFactory
    {
        object Create(string connectionString);
    }

    public class RabbitMqPublisherFactory : IBusPublisherFactory
    {
        public object Create(string connectionString)
        {
            Console.WriteLine("Creating a bus publisher for RabbitMQ");

            Console.WriteLine($"Using connection string: {connectionString}");
            
            return null;
        }
    }
}
