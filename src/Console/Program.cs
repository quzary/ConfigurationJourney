using Lodgify.AppSettings.ConfigSection;
using Messaging;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var rabbitMqPublisherFactory = new RabbitMqPublisherFactory(new AppSettingsProvider(new ConfigurationManagerWrapper()));

            rabbitMqPublisherFactory.Create();

            System.Console.ReadKey();
        }
    }
}
