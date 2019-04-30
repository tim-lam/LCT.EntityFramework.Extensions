using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using samples.DAL;
using samples.DomainModels;

namespace samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var newOrder = new Order();

            newOrder.OrderItems = new[]
            {
                new OrderItem
                {
                    Id = 1,
                    Order = newOrder,
                    Qty = 1,
                    ProductName = "Item 1-changed"
                },
                new OrderItem
                {
                    Order = newOrder,
                    Qty = 1,
                    ProductName = "Item 2"
                }
            };

            using (var unitOfWork = new UnitOfWork())
            {
                var genericRepository = new GenericRepository<Order>(unitOfWork);
                genericRepository.AddOrUpdate(newOrder);
                var savedRecords = unitOfWork.Save();

            }
        }
    }
}
