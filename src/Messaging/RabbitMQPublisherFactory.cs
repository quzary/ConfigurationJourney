using System;

namespace Messaging
{
    public interface IBusPublisherFactory
    {
        object Create();
    }

    public interface IMessagingSettings
    {
        string ConnectionString { get; }

        string ErrorQueueName { get; }
    }

    public class RabbitMqPublisherFactory : IBusPublisherFactory
    {
        private readonly IMessagingSettings _messagingSettings;

        public RabbitMqPublisherFactory(IMessagingSettings messagingSettings)
        {
            _messagingSettings = messagingSettings;
        }

        public object Create()
        {
            Console.WriteLine("Creating a bus publisher for RabbitMQ");

            var connectionString = _messagingSettings.ConnectionString;
            Console.WriteLine($"Using connection string: {connectionString}");

            var errorQueueName = _messagingSettings.ErrorQueueName;
            Console.WriteLine($"Using error queue name: {errorQueueName}");

            return null;
        }
    }
}
