using API.DTOs;
using API.Extensions;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Stripe;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : BaseApiController
    {
        private readonly PaymentService _paymentService;
        private readonly BaseDbContext _baseDbContext;
        private readonly IConfiguration _configuration;

        public PaymentsController(PaymentService paymentService, BaseDbContext baseDbContext, IConfiguration configuration)
        {
            _paymentService = paymentService;
            _baseDbContext = baseDbContext;
            _configuration = configuration;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateOrUpdatePaymentIntent()
        {
            var basket = await _baseDbContext.Baskets
                                .RetrieveBasketWithItems(User.Identity.Name)
                                .FirstOrDefaultAsync();

            if (basket == null) return NotFound();

            var intent = await _paymentService.CreateOrUpdatePaymentIntent(basket);

            if (intent == null) return BadRequest(new ProblemDetails { Title = "Problem occured while creating payment intent" });

            basket.PaymentIntentId = basket.PaymentIntentId ?? intent.Id;
            basket.ClientSecret = basket.ClientSecret ?? intent.ClientSecret;

            _baseDbContext.Update(basket);

            var result = await _baseDbContext.SaveChangesAsync() > 0;

            if (!result) return BadRequest(new ProblemDetails { Title = "Problem occured while updating basket with intent" });

            return basket.MapBasketToDto();

        }

        [HttpPost("webhook")]
        public async Task<ActionResult> StripeWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            var stripeEvent = EventUtility.ConstructEvent(json, Request.Headers["Stripe-Signature"], _configuration["StripeSettings:WhSecret"]);

            var charge = (Charge)stripeEvent.Data.Object;

            var order = await _baseDbContext.Orders.FirstOrDefaultAsync(x => x.PaymentIntentId == charge.PaymentIntentId);

            await _baseDbContext.SaveChangesAsync();

            return new EmptyResult();

        }
    }
}
