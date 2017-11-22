using System.Collections.Generic;
using Lodgify.AppSettings;
using Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurationRoot = new ConfigurationBuilder()
                .AddAppSettingsConfiguration()
                .Build();

            var configurationSection = configurationRoot.GetSection("config:messaging");

            var configureFromConfigurationOptions = new ConfigureFromConfigurationOptions<MessagingSettings>(configurationSection);
            var setups = new List<IConfigureOptions<MessagingSettings>> { configureFromConfigurationOptions };

            var postConfigureOptions = new PostConfigureOptions<MessagingSettings>(Options.DefaultName, settings => { });
            var postConfigures = new List<IPostConfigureOptions<MessagingSettings>> { postConfigureOptions };

            var optionsFactory = new OptionsFactory<MessagingSettings>(setups, postConfigures);

            var optionsManager = new OptionsManager<MessagingSettings>(optionsFactory);

            var rabbitMqPublisherFactory = new RabbitMqPublisherFactory(optionsManager);
            rabbitMqPublisherFactory.Create();

            System.Console.ReadKey();
        }
    }
}
