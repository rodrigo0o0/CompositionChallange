using CompositionChallange.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionChallange.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus status { get; set; }
        public List<OrderItem> items { get; set; } = new List<OrderItem>();
        public Order() { }

        public Order(OrderStatus status)
        {
            Moment = DateTime.Now;
            this.status = status;
        }

        public void AddItem(OrderItem oi)
        {
            items.Add(oi);
        }
        public void RemoveItem(OrderItem oi)
        {
            items.Remove(oi);
        }
        public double Total()
        {
            double total = 0.0;
            foreach (OrderItem oi in items)
            {
                total += oi.SubTotal();
            }
            return total;
        }
    }
}
