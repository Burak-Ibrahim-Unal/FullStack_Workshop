using API.DTOs;
using API.Extensions;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : BaseApiController
    {
        private readonly PaymentService _paymentService;
        private readonly BaseDbContext _baseDbContext;

        public PaymentsController(PaymentService paymentService, BaseDbContext baseDbContext)
        {
            _paymentService = paymentService;
            _baseDbContext = baseDbContext;
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
    }
}
