namespace Contracts.Events
{
    public class ClientPaymentSucceededEvent
    {
        public string ReferenceId { get; set; }

        public decimal Amount { get; set; }
    }
}
