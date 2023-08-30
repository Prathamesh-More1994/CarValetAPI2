using CarValetAPI2.Shared.Dtos;
using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Application.Application.Interfaces
{
    public interface IPaymentIntentApplication
    {
        Task CreatePaymentAsync(Payment payment);
        Task<IEnumerable<Payment>> GetPaymentsAsync();
        Task<PaymentDto> GetPaymentsByOwnerAsync(Company company);
        Task<Payment> GetPaymentById(string id);
    }
}