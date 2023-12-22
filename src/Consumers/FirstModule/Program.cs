// See https://aka.ms/new-console-template for more information

using Contracts.Events;
using FirstModule.Consumers;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// configure the first module queues

services.AddMassTransit(busConfiguration =>
{
    busConfiguration.AddConsumer<OrderPlacedEventConsumer>();
    busConfiguration.AddConsumer<ClientPromotionSubscribedEventConsumer>();

    busConfiguration.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host("localhost", 5672, "/",
            hostConfigurator =>
            {
                hostConfigurator.Username("guest");
                hostConfigurator.Password("guest");
            });

        configurator.ReceiveEndpoint($"x_{nameof(OrderPlacedEvent)}", c =>
        {
            c.ConfigureConsumer<OrderPlacedEventConsumer>(context);
        });

        configurator.ReceiveEndpoint($"x_{nameof(ClientPromotionSubscribedEvent)}", c =>
        {
            c.ConfigureConsumer<ClientPromotionSubscribedEventConsumer>(context);
        });

        configurator.ConfigureEndpoints(context);
    });
});

var busControl = services.BuildServiceProvider().GetRequiredService<IBusControl>();
await busControl.StartAsync();
Console.WriteLine("Press any key to exit");
Console.ReadKey();
await busControl.StopAsync();
