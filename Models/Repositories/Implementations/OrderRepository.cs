using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blahazon.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;

        public OrderRepository(AppDbContext dbContext)
        {
            context = dbContext;
        }

        public void Add(Order order)
        {
            context.Add<Order>(order);
            context.SaveChanges();
        }

        public long CheckStatus(long orderId)
        {
            return context.Orders.Find(orderId).StatusCode;
        }

        public void Delete(long orderId)
        {
            Order order = context.Orders.Find(orderId);
            if (order != null)
            {
                context.Orders.Remove(order);
                context.SaveChanges();
            }
        }


        public Order Get(long userId) 
        {
            Order order = context.Orders.Where(order => order.UserId == userId).FirstOrDefault();
            if (order != null)
            {
                return order;
            }
            throw new NullReferenceException("Requested Order Not Found!");
        }
    }
}
