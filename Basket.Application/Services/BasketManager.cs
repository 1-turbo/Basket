using Basket.Application.Interfaces;
using Basket.Domain.Entities;

namespace Basket.Application.Services
{
    public class BasketManager
    {
        private readonly IBasketService _basketService;

        public BasketManager(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public void AddToBasket(int userId, int packageId)
        {
            _basketService.AddItem(userId, packageId);
        }

        public List<BasketItem> GetUserBasket(int userId) => _basketService.GetBasket(userId);

        public bool RemoveFromBasket(int userId, int packageId) => _basketService.RemoveItem(userId, packageId);

        public void Checkout(int userId) => _basketService.ClearBasket(userId);
    }
}
