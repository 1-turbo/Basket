using Basket.Domain.Entities;

namespace Basket.Application.Interfaces
{
    public interface IBasketService
    {
        List<BasketItem> GetBasket(int userId);
        void AddItem(int userId, int packageId);
        bool RemoveItem(int userId, int packageId);
        void ClearBasket(int userId);
    }
}
