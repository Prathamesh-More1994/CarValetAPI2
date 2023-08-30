using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Shared.Dtos
{
    public class PaymentDto
    {
        public List<Payment> Payments { get; set; }
        public long MonthlyRevenue { get; set; }
        public long YearlyRevenue { get; set; }
    }
}