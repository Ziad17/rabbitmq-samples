using Contracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace SecondModule.Consumers
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
            _logger.LogInformation($"{nameof(OrderPlacedEventConsumer)} triggered from module Y");
        }
    }
}
