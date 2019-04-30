using System.Collections.Generic;

namespace samples.DomainModels
{
    public class Order
    {
        public int Id { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
