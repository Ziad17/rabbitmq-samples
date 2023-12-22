namespace Contracts.Events
{
    public class ClientPromotionSubscribedEvent
    {
        public Guid ClientId { get; set; }

        public bool Subscribe { get; set; }
    }
}
