using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionChallange.Entities
{
    internal class OrderItem
    {
        public Product product { get; set; }
        public int Quantity { get; set; }
        public OrderItem()
        {
        }

        public OrderItem(Product product,int quantity)
        {
            Quantity = quantity;
            this.product = product;
            
        }

        public double SubTotal()
        {
            return Quantity * product.Price;
        }
    }
}
