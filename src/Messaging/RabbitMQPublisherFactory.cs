using System;
using Lodgify.Configuration.Contracts;
using Microsoft.Extensions.Options;
using ObjectDumper;

namespace Messaging
{
    public interface IBusPublisherFactory
    {
        object Create();
    }

    [Configuration("messageBus")]
    public class MessageBusSettings
    {
        public string ConnectionString { get; set; }

        public string ErrorQueueName { get; set; }

        public RetryPolicySettings RetryPolicySettings { get; set; }
    }

    public class RetryPolicySettings
    {
        public int MaxRetries { get; set; }

        public int RetryDelayMilliseconds { get; set; }

        public string FinalExceptionRegex { get; set; }
    }

    public class RabbitMqPublisherFactory : IBusPublisherFactory
    {
        private readonly MessageBusSettings _messagingSettings;

        public RabbitMqPublisherFactory(IOptions<MessageBusSettings> messageBusSettings)
        {
            _messagingSettings = messageBusSettings.Value;
        }

        public object Create()
        {
            Console.WriteLine("Creating a bus publisher for RabbitMQ");

            Dumper.Dump(_messagingSettings, nameof(_messagingSettings), Console.Out);

            return null;
        }
    }
}
