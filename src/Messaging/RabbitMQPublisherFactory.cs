using System;
using Lodgify.Configuration.Contracts;

namespace Messaging
{
    public interface IBusPublisherFactory
    {
        object Create();
    }

    public class RabbitMqPublisherFactory : IBusPublisherFactory
    {
        private readonly ISettingsProvider _settingsProvider;

        public RabbitMqPublisherFactory(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public object Create()
        {
            Console.WriteLine("Creating a bus publisher for RabbitMQ");

            var connectionString = _settingsProvider.Get<string>("RabbitConnectionString");
            Console.WriteLine($"Using connection string: {connectionString}");

            var errorQueueName = _settingsProvider.Get<string>("ErrorQueueName");
            Console.WriteLine($"Using error queue name: {errorQueueName}");

            return null;
        }
    }
}
