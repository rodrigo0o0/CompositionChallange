using CompositionChallange.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CompositionChallange.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus status { get; set; }
        public List<OrderItem> items { get; set; } = new List<OrderItem>();
        public Client client { get; set; }
        public Order() { }

        public Order(Client client,OrderStatus status)
        {
            this.client = client;
            this.status = status;
            Moment = DateTime.Now;
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order Moment : " + Moment);
            sb.AppendLine("Order Status : " + status.ToString());
            sb.AppendLine($"Client :  {client.Name} ({client.BirthDate.ToShortTimeString()} - {client.Email})");
            sb.AppendLine("Order Items : ");
            foreach (OrderItem oi in items)
            {
                sb.AppendLine($"{oi.product.Name} Quantity : {oi.Quantity}, SubTotal: R$ {oi.SubTotal().ToString("F2",CultureInfo.InvariantCulture)}");
            }
            sb.AppendLine("Total price : $" + Total().ToString("F2",CultureInfo.InvariantCulture));
            return sb.ToString();
            
        }
    }
}
