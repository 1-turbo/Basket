using Basket.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly BasketManager _basketManager;

        public BasketController(BasketManager basketManager)
        {
            _basketManager = basketManager;
        }

        [HttpGet]
        public IActionResult GetBasket([FromQuery] int userId)
        {
            var basket = _basketManager.GetUserBasket(userId);
            return Ok(basket);
        }

        [HttpPost("add")]
        public IActionResult AddItem([FromQuery] int userId, [FromQuery] int packageId)
        {
            if (packageId <= 0) return BadRequest("Invalid package ID.");
            _basketManager.AddToBasket(userId, packageId);
            return Ok(new { Message = "Item added." });
        }

        [HttpDelete("{packageId}")]
        public IActionResult RemoveItem(int packageId, [FromQuery] int userId)
        {
            var result = _basketManager.RemoveFromBasket(userId, packageId);
            return result ? Ok(new { Message = "Item removed." }) : NotFound("Item not found.");
        }

        [HttpPost("checkout")]
        public IActionResult Checkout([FromQuery] int userId)
        {
            var basket = _basketManager.GetUserBasket(userId);
            if (!basket.Any()) return BadRequest("Basket is empty.");

            _basketManager.Checkout(userId);
            return Ok(new { Message = "Booking Confirmed!" });
        }
    }
}
