using Contracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FirstModule.Consumers
{
    internal class OrderPlacedEventConsumer : IConsumer<OrderPlacedEvent>
    {
        private readonly ILogger<OrderPlacedEventConsumer> _logger;

        public OrderPlacedEventConsumer(ILogger<OrderPlacedEventConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<OrderPlacedEvent> context)
        {
            Console.WriteLine($"{nameof(OrderPlacedEventConsumer)} triggered from module X");
        }
    }
}
