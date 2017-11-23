using System.Collections.Generic;
using Autofac;
using Lodgify.AppSettings;
using Lodgify.Ioc.Autofac.Options;
using Messaging;
using Microsoft.Extensions.Configuration;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var configurationRoot = new ConfigurationBuilder()
                .AddAppSettingsConfiguration()
                .AddInMemoryCollection(
                    new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("config:messaging:errorQueueName", "__Lodgify_INMEMORY_Errors")
                    }
                )
                .Build();

            var builder = new ContainerBuilder();

            builder.ConfigureOptions<MessagingSettings>(configurationRoot);

            builder
                .RegisterType<RabbitMqPublisherFactory>()
                .As<IBusPublisherFactory>();

            var container = builder.Build();

            var rabbitMqPublisherFactory = container.Resolve<IBusPublisherFactory>();
            rabbitMqPublisherFactory.Create();

            System.Console.ReadKey();
        }
    }
}
