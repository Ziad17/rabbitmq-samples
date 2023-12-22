using Contracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace SecondModule.Consumers
{
    public class ClientPromotionSubscribedEventConsumer : IConsumer<ClientPromotionSubscribedEvent>
    {
        private readonly ILogger<ClientPromotionSubscribedEventConsumer> _logger;

        public ClientPromotionSubscribedEventConsumer(ILogger<ClientPromotionSubscribedEventConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ClientPromotionSubscribedEvent> context)
        {
            _logger.LogInformation($"{nameof(ClientPromotionSubscribedEventConsumer)} triggered from module Y and will throw exception");

            throw new ArgumentException();
        }
    }
}
