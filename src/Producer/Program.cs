using Contracts.Events;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;

var services = new ServiceCollection();

// configure the default producer connection

services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", 5672, "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });
});

var bus = services.BuildServiceProvider().GetRequiredService<IBus>();

while (true)
{
    Console.WriteLine("1. OrderPlacedEvent");
    Console.WriteLine("2. ClientPromotionSubscribedEvent");
    Console.WriteLine("3. ClientPaymentSucceededEvent");

    var eventNumber = int.Parse(Console.ReadLine());

    switch (eventNumber)
    {
        case 1:
            await bus.Publish(new OrderPlacedEvent()
            {
                OrderId = Guid.NewGuid(),
                OrderPrice = 120
            });
            break;
        case 2:
            await bus.Publish(new ClientPromotionSubscribedEvent()
            {
                ClientId = Guid.NewGuid(),
                Subscribe = true
            });
            break;
        case 3:
            await bus.Publish(new ClientPaymentSucceededEvent()
            {
                ReferenceId = Guid.NewGuid().ToString("D"),
                Amount = 120
            });
            break;
    }
}

