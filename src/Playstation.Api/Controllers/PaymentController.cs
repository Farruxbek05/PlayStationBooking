using Microsoft.AspNetCore.Mvc;
using Playstation.Application.Models.Payment;
using Playstation.Application.Services;

namespace Playstation.Api.Controllers
{
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet("GetAllPayment")]
        public async Task<IActionResult> GetAllPayment()
        {
            var res = await _paymentService.GetAllPaymentAsync();
            return Ok(res);
        }
        [HttpGet("GetPayment/{id}")]
        public async Task<IActionResult> GetPayment(Guid id)
        {
            var res = await _paymentService.GetByIdPaymentAsync(id);
            return Ok(res);
        }
        [HttpPost("CreatePayment")]
        public async Task<IActionResult> CreatePayment(PaymentCM paymentCM)
        {
            var res = await _paymentService.CreatePaymentAsync(paymentCM);
            return Ok(res);
        }
        [HttpPut("UpdatePayment")]
        public async Task<IActionResult> UpdatePayment(PaymentUM paymentUM)
        {
            var res = await _paymentService.UpdatePaymentAsync(paymentUM);
            return Ok(res);
        }
        [HttpDelete("DeletePayment")]
        public async Task<IActionResult> DeletePayment(Guid guid)
        {
            var res = await _paymentService.DeletePaymentAsync(guid);
            return Ok(res);
        }
    }
}
