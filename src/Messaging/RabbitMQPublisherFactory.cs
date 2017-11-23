using System;
using Lodgify.Configuration.Contracts;
using Microsoft.Extensions.Options;

namespace Messaging
{
    public interface IBusPublisherFactory
    {
        object Create();
    }

    [Configuration("config:messaging", ':')]
    public class MessagingSettings
    {
        public string ConnectionString { get; set; }

        public string ErrorQueueName { get; set; }
    }

    public class RabbitMqPublisherFactory : IBusPublisherFactory
    {
        private readonly MessagingSettings _messagingSettings;

        public RabbitMqPublisherFactory(IOptions<MessagingSettings> messagingSettings)
        {
            _messagingSettings = messagingSettings.Value;
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
