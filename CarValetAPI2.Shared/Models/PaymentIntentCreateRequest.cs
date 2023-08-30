namespace CarValetAPI2.Shared.Models
{
    public class PaymentIntentCreateRequest
    {
        public long Amount { get; set; }
        public string? ProductName { get; set; }
        public string? Customer { get; set; }
    }
}