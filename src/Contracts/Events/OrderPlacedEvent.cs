namespace Contracts.Events
{
    public class OrderPlacedEvent
    {
        public Guid OrderId { get; set; }

        public decimal OrderPrice { get; set; }
    }
}
