using CarValetAPI2.Application.Application.Interfaces;
using CarValetAPI2.Shared.Dtos;
using CarValetAPI2.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace CarValetAPI2.Controller
{
    //Get Payments
    [ApiController]
    [Route("Payment")]
    public class PaymentIntentController : ControllerBase
    {
        private readonly IPaymentIntentApplication paymentIntentApplication;
        public PaymentIntentController(IPaymentIntentApplication paymentIntentApplication)
        {
            this.paymentIntentApplication = paymentIntentApplication;
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(PaymentIntentCreateRequest request)
        {
            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = paymentIntentService.Create(new PaymentIntentCreateOptions
            {
                Amount = request.Amount * 100,
                Currency = "eur",

                Description = request.ProductName,
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                },
            });

            return new JsonResult(new { clientSecret = paymentIntent.ClientSecret });
        }

        [HttpGet]
        public IActionResult GetAllTransactions()
        {
            var paymentIntentService = new PaymentIntentService();
            var paymentIntentListOption = new PaymentIntentListOptions
            {
                Limit = 100
            };

            var paymentIntentList = paymentIntentService.List(paymentIntentListOption).Where(x => x.Status.Equals("Succeeded"));
            return new JsonResult(new { paymentIntentList = paymentIntentList });
        }


        [HttpPost]
        [Route("owner")]
        public async Task<PaymentDto> GetPaymentsByOwnerAsync(Company company)
        {
            return await this.paymentIntentApplication.GetPaymentsByOwnerAsync(company);
        }

        [HttpPost]
        [Route("GetAll")]
        public async Task<IEnumerable<Payment>> GetPaymentsAsync()
        {
            return await this.paymentIntentApplication.GetPaymentsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPaymentById(string id)
        {
            return await this.paymentIntentApplication.GetPaymentById(id);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult SavePayment(Payment payment)
        {
            this.paymentIntentApplication.CreatePaymentAsync(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = payment.PaymentId }, new { payment });
        }
    }
}