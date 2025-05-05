using Basket.Application.Interfaces;
using Basket.Domain.Entities;

namespace Basket.Infrastructure.Services
{
    public class InMemoryBasketService : IBasketService
    {
        private static readonly Dictionary<int, List<BasketItem>> _baskets = new();

        public List<BasketItem> GetBasket(int userId)
        {
            _baskets.TryGetValue(userId, out var basket);
            return basket ?? new List<BasketItem>();
        }

        public void AddItem(int userId, int packageId)
        {
            if (!_baskets.ContainsKey(userId))
                _baskets[userId] = new List<BasketItem>();

            var item = _baskets[userId].FirstOrDefault(x => x.PackageId == packageId);
            if (item != null)
                item.Quantity++;
            else
                _baskets[userId].Add(new BasketItem { PackageId = packageId });
        }

        public bool RemoveItem(int userId, int packageId)
        {
            if (!_baskets.ContainsKey(userId)) return false;

            var item = _baskets[userId].FirstOrDefault(x => x.PackageId == packageId);
            if (item == null) return false;

            item.Quantity--;
            if (item.Quantity <= 0)
                _baskets[userId].Remove(item);

            return true;
        }

        public void ClearBasket(int userId)
        {
            _baskets.Remove(userId);
        }
    }
}
