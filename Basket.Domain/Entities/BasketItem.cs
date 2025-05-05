using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Domain.Entities
{
    public class BasketItem
    {
        public int PackageId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
