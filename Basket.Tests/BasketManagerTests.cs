using Basket.Application.Services;
using Basket.Infrastructure.Services;
using Xunit;

namespace Basket.Tests
{
    public class BasketManagerTests
    {
        private readonly BasketManager _manager;

        public BasketManagerTests()
        {
            _manager = new BasketManager(new InMemoryBasketService());
        }

        [Fact]
        public void AddAndRemoveItems_WorksCorrectly()
        {
            int userId = 1, packageId = 101;
            _manager.AddToBasket(userId, packageId);
            _manager.AddToBasket(userId, packageId);

            var items = _manager.GetUserBasket(userId);
            Assert.Single(items);
            Assert.Equal(2, items.First().Quantity);

            _manager.RemoveFromBasket(userId, packageId);
            items = _manager.GetUserBasket(userId);
            Assert.Equal(1, items.First().Quantity);
        }
    }

}
