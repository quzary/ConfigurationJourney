using System;
using System.Collections.Generic;
using Autofac;
using Lodgify.Consul.Options;
using Lodgify.Consul.Options.Client;
using Lodgify.Ioc.Autofac.Options;
using Messaging;
using Microsoft.Extensions.Configuration;

namespace Console
{
    public class ClientSettingsProvider : IClientSettingsProvider
    {
        public string Endpoint { get; } = "127.0.0.1";

        public int Port { get; }

        public string DataCenter { get; }

        public string Token { get; }

        public string ConfigurationPrefix { get; } = "local/web/";
    }

    class Program
    {
        static void Main(string[] args)
        {
            var configurationRoot = new ConfigurationBuilder()
               .AddConsulConfiguration(new ClientSettingsProvider())
               // Default strategy getting settings from environment variables
               //.AddConsulConfiguration()
               .Build();

            try
            {
                var builder = new ContainerBuilder();

                builder.ConfigureOptions<MessageBusSettings>(configurationRoot);

                builder
                    .RegisterType<RabbitMqPublisherFactory>()
                    .As<IBusPublisherFactory>();

                var container = builder.Build();

                var rabbitMqPublisherFactory = container.Resolve<IBusPublisherFactory>();
                rabbitMqPublisherFactory.Create();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.GetDetails());
            }

            System.Console.ReadKey();
        }
    }
}
