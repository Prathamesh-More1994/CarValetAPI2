using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Data.Repositories.Interfaces
{
    public interface IPaymentIntentRepository
    {
        Task CreatePaymentAsync(Payment payment);
        Task<IEnumerable<Payment>> GetPaymentsAsync();
        Task<Payment> GetPaymentById(string id);
    }
}