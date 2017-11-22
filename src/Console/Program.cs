using Lodgify.AppSettings.ConfigSection;
using Lodgify.Configuration.Contracts;
using Messaging;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurationManagerWrapper = new ConfigurationManagerWrapper();
            var appSettingsProvider = new AppSettingsProvider(configurationManagerWrapper);
            var messagingSettingsProvider = new MessagingSettingsProvider(appSettingsProvider);
            var rabbitMqPublisherFactory = new RabbitMqPublisherFactory(messagingSettingsProvider);

            rabbitMqPublisherFactory.Create();

            System.Console.ReadKey();
        }
    }

    internal class MessagingSettingsProvider : IMessagingSettings
    {
        private readonly ISettingsProvider _settingsProvider;

        public MessagingSettingsProvider(ISettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public string ConnectionString => _settingsProvider.Get<string>("RabbitConnectionString");

        public string ErrorQueueName => _settingsProvider.Get<string>("ErrorQueueName");
    }
}
