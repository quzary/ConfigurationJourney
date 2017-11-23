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
    }

    [Configuration("messageBus/retryPolicy")]
    public class RetryPolicySettings
    {
        public int MaxRetries { get; set; }

        public int RetryDelayMilliseconds { get; set; }

        public string FinalExceptionRegex { get; set; }
    }

    public class RabbitMqPublisherFactory : IBusPublisherFactory
    {
        private readonly MessageBusSettings _messagingSettings;

        private readonly RetryPolicySettings _retryPoliciesSettings;

        public RabbitMqPublisherFactory(IOptions<MessageBusSettings> messageBusSettings, IOptions<RetryPolicySettings> retryPoliciesSettings)
        {
            _messagingSettings = messageBusSettings.Value;
            _retryPoliciesSettings = retryPoliciesSettings.Value;
        }

        public object Create()
        {
            Console.WriteLine("Creating a bus publisher for RabbitMQ");

            Dumper.Dump(_messagingSettings, nameof(_messagingSettings), Console.Out);
            Dumper.Dump(_retryPoliciesSettings, nameof(_retryPoliciesSettings), Console.Out);

            return null;
        }
    }
}
