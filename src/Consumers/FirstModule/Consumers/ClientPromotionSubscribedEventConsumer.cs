using Contracts.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace FirstModule.Consumers
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
            Console.WriteLine($"{nameof(ClientPromotionSubscribedEventConsumer)} triggered from module X");
        }
    }
}
