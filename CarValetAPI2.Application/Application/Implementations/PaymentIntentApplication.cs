using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Data.Repositories.Interfaces;
using CarValetAPI2.Shared.Dtos;
using CarValetAPI2.Shared.Models;

namespace CarValetAPI2.Application.Application.Implementations
{
    public class PaymentIntentApplication : IPaymentIntentApplication
    {

        public readonly IPaymentIntentRepository paymentRepository;

        public PaymentIntentApplication(IPaymentIntentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }


        public async Task CreatePaymentAsync(Payment payment)
        {
            await paymentRepository.CreatePaymentAsync(payment);
        }

        public async Task<Payment> GetPaymentById(string id)
        {
            return await paymentRepository.GetPaymentById(id);
        }

        public async Task<IEnumerable<Payment>> GetPaymentsAsync()
        {
            return await paymentRepository.GetPaymentsAsync();
        }

        public async Task<PaymentDto> GetPaymentsByOwnerAsync(Company company)
        {
            var payments = await paymentRepository.GetPaymentsAsync();
            var ownerPayment = payments.Where(x => x.CompanyId.Equals(company.CompanyId));
            var monthlyPayment = ownerPayment.Where(x => x.CreatedDate.Month == DateTime.Now.Month).Sum(z => z.Amount);
            var yearlyPayment = ownerPayment.Where(x => x.CreatedDate.Year == DateTime.Now.Year).Sum(z => z.Amount);
            var reponse = new PaymentDto
            {
                Payments = ownerPayment.ToList(),
                MonthlyRevenue = monthlyPayment,
                YearlyRevenue = yearlyPayment
            };
            return reponse;
        }
    }
}