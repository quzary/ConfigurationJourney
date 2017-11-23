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
                .Build();

            var configurationSection = configurationRoot.GetSection("config:messaging");

            var builder = new ContainerBuilder();

            builder.ConfigureOptions<MessagingSettings>(configurationSection);

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
